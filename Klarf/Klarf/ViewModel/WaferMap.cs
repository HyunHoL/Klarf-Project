using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight.Messaging;
using Klarf.Model;

namespace Klarf.ViewModel
{
    class WaferMap : INotifyPropertyChanged
    {
        #region [상수]

        public List<Point> sampleTestPlan = new List<Point>();
        WaferMapInfo waferMapInfo;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Point> Dies { get; } = new ObservableCollection<Point>();
        #endregion

        #region [속성]



        #endregion

        #region [생성자]
        public WaferMap()
        {
            foreach (var point in sampleTestPlan)
            {
                Dies.Add(point);
            }

            waferMapInfo = new WaferMapInfo();
            Messenger.Default.Register<List<Point>>(this, LoadSampleTestPlan);
        }

        #endregion


        #region [public Method]


        #endregion

        #region [private Method]

        private void LoadSampleTestPlan(List<Point> newSampleTestPlan)
        {
            sampleTestPlan = newSampleTestPlan;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
    }
}
