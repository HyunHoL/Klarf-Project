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
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace Klarf.ViewModel
{    
    public partial class OpenFile : INotifyPropertyChanged
    {

        #region [상수]

        public string fileData;
        WaferMapInfo waferMapInfo;
        #endregion

        #region [인터페이스]
        public ICommand OpenFileCommand { get; }
        #endregion

        #region [속성]

        public ObservableCollection<String> FileName { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public string FileData
        {
            get { return fileData; }

            set
            {
                fileData = value;
                OnPropertyChanged(nameof(FileData));
            }
        }

        #endregion

        #region [생성자]
        public OpenFile()
        {
            waferMapInfo = new WaferMapInfo();
            OpenFileCommand = new RelayCommand(LoadFile);

        }


        #endregion

        #region [public Method]


        public void LoadFile (object parameter)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\hhlee\OneDrive - 에이티아이\바탕 화면\Klarf 과제";
            string selectedFilePath = "";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
            }

            else
            {
                return;
            }

            string fileExtension = Path.GetExtension(selectedFilePath);

            if (fileExtension.Equals(".001", StringComparison.OrdinalIgnoreCase))
            {
                FileData = File.ReadAllText(selectedFilePath);
            }

            Messenger.Default.Send<string>(FileData);
            waferMapInfo.ParalleMovementSampleTestPlan();
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
