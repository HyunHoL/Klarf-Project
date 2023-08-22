using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Calc.ViewModel;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using Klarf.Model;

namespace Klarf.ViewModel
{
    public partial class OpenFile : INotifyPropertyChanged
    {

        #region [상수]

        public string textValue, fileTimestamp, lotID, waferID;
        public int[ , ] sampleTestPlan;
        public double[,] defectList;

        #endregion

        #region [인터페이스]
        public ICommand ReadFile { get; }
        public ICommand OpenFileCommand { get; }
        #endregion

        #region [속성]
        public ObservableCollection<String> FileName { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public string TextValue
        {
            get { return textValue; }

            set
            {
                textValue = value;
                OnPropertyChanged(nameof(TextValue));
            }
        }
        #endregion

        #region [생성자]
        public OpenFile()
        {
            defectList = new double[453, 19];
            FileName = new ObservableCollection<string>();
            sampleTestPlan = new int[784, 2];
            OpenFileCommand = new RelayCommand(LoadFile);
        }

        
        #endregion

        #region [public Method]

        public int [,] GetSampleTestPlan()
        {
            return sampleTestPlan;
        }

        public string GetFileTimestamp()
        {
            return fileTimestamp;
        }

        public string GetLotID()
        {
            return lotID;
        }

        public string GetWaferID()
        {
            return waferID;
        }

        public double [,] GetDefectList ()
        {
            return defectList;
        }

        public void LoadFile (object parameter)
        {

            FilePathData filePathData = new FilePathData();
            string selectedFilePath = filePathData.ReadFileData();
            string fileExtension = Path.GetExtension(selectedFilePath);

            if (fileExtension.Equals(".001", StringComparison.OrdinalIgnoreCase))
            {
                TextValue = File.ReadAllText(selectedFilePath);
            }

            else
            {
                return;
            }

            filePathData.ReadSampleTestPlan(TextValue, sampleTestPlan);
            fileTimestamp = filePathData.ReadFileTimeStamp(TextValue);
            lotID = filePathData.ReadLotID(TextValue);
            waferID = filePathData.ReadWaferID(TextValue);
            filePathData.ReadDefectList(TextValue, defectList);
        }

        #endregion

        #region [private Method]


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
