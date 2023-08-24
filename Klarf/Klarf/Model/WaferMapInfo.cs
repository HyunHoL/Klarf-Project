using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Klarf.Model
{
    class WaferMapInfo
    {
        #region [상수]
        WaferInfo waferInfo;
        ReadDefectListInfo readDefectListInfo;
        public List<Point> newSampleTestPlan;
        public List<Point> sampleTestPlan;
        public string fileValue;

        #endregion

        #region [속성]



        #endregion

        #region [생성자]
        public WaferMapInfo()
        {
            waferInfo = new WaferInfo();
            readDefectListInfo = new ReadDefectListInfo();
            Messenger.Default.Register<string>(this, LoadFileData);
        }


        #endregion

        #region [public Method]

        public List<Point> ParalleMovementSampleTestPlan()
        {

            sampleTestPlan = waferInfo.ReadSampleTestPlan(fileValue);
            Point saveValue = new Point();

            for (int i = 0; i < sampleTestPlan.Count; i++)
            {

                saveValue.X = sampleTestPlan[i].X + 9;
                saveValue.Y = Math.Abs(sampleTestPlan[i].Y - 24);
                newSampleTestPlan.Add(saveValue);
            }
            Messenger.Default.Send<List<Point>>(newSampleTestPlan);
            return newSampleTestPlan;
        }

        public int[,] ParalleMovementDefectXY ()
        {
            int[,] defectXY;
            defectXY = readDefectListInfo.ReadDefectXY(fileValue);
            int[,] newDefectXY = new int[defectXY.GetLength(0), defectXY.GetLength(1)];

            for (int i = 0; i < defectXY.GetLength(0); i++)
            {
                newDefectXY[i, 0] = defectXY[i, 0] + 9;
                newDefectXY[i, 1] = Math.Abs(defectXY[i, 1] - 24);
            }

            return newDefectXY;
        }

        #endregion

        #region [private Method]

        private void LoadFileData(string fileData)
        {
            fileValue = fileData;
        }


        #endregion
    }
}
