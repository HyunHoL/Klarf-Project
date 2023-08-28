using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Klarf.Model;

namespace Klarf.ViewModel
{
    public class WaferMapCoordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    public partial class DrawWaferMap : INotifyPropertyChanged
    {
        #region [상수]

        public List<Point> sampleTestPlan = new List<Point>();
        WaferMapInfo waferMapInfo;
        public List<Point> listValue;
        public Point indexValue;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Point> showWaferMap = new ObservableCollection<Point>();
        // Rectangle rect;

        public ObservableCollection<WaferMapCoordinate> coordinates;
        #endregion

        #region [속성]



        #endregion
        
        #region [생성자]
        public DrawWaferMap()
        {
            indexValue = new Point();
            waferMapInfo = new WaferMapInfo();
            coordinates = new ObservableCollection<WaferMapCoordinate>();
        }

        #endregion


        #region [public Method]

        public ObservableCollection<WaferMapCoordinate> Coordinates
        {
            get { return coordinates; }
            set
            {
                coordinates = value;
                OnPropertyChanged(nameof(Coordinates));
            }
        }

        private Point updatePoint;
        public Point UpdatePoint
        {
            get { return updatePoint; }

            set
            {
                if (updatePoint != value )
                {
                    updatePoint = value;
                    OnPropertyChanged(nameof(UpdatePoint));
                }
            }
        }


        public ObservableCollection<Point> ShowWaferMap
        {
            get { return showWaferMap; }
            set
            {
                showWaferMap = value;
                OnPropertyChanged(nameof(ShowWaferMap));
            }
        }

        //public Point GiveIndex
        //{
        //    get { return indexValue; }

        //    set
        //    {
        //        if (indexValue != value)
        //        {
        //            indexValue = value;
        //            OnPropertyChanged("GiveIndex");
        //        }
        //    }
        //}

        #endregion

        #region [private Method]

        public void LoadSampleTestPlan(List<Point> newSampleTestPlan)
        {
            ShowWaferMap.Clear();

            foreach (var point in newSampleTestPlan)
            {
                // GiveIndex = point;
                ShowWaferMap.Add(new Point(point.X, point.Y));
            }
            ShowWaferMap = ShowWaferMap;
        }

        public void UpdateWaferMap (List<Point> newSampleTestPlan)
        {
            for (int i = 0; i < newSampleTestPlan.Count; i++)
            {
                double x = newSampleTestPlan[i].X;
                double y = newSampleTestPlan[i].Y;
                Coordinates.Add(new WaferMapCoordinate { X = x, Y = y });
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
