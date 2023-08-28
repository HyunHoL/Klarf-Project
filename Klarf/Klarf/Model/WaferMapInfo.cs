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
        DieInfo readDefectListInfo;
        public List<Point> newSampleTestPlan;
        public List<Point> sampleTestPlan;

        #endregion

        #region [속성]



        #endregion

        #region [생성자]
        public WaferMapInfo()
        {
            newSampleTestPlan = new List<Point>();
            waferInfo = new WaferInfo();
            readDefectListInfo = new DieInfo();

        }


        #endregion

        #region [public Method]

        public List<Point> ParalleMovementSampleTestPlan(string textValue)
        {

            sampleTestPlan = waferInfo.ReadSampleTestPlan(textValue);
            Point saveValue = new Point();

            for (int i = 0; i < sampleTestPlan.Count; i++)
            {

                saveValue.X = sampleTestPlan[i].X + 9;
                saveValue.Y = Math.Abs(sampleTestPlan[i].Y - 24);
                newSampleTestPlan.Add(saveValue);
            }

            return newSampleTestPlan;
        }

        public int[,] ParalleMovementDefectXY (string textValue)
        {
            int[,] defectXY;
            defectXY = readDefectListInfo.ReadDefectXY(textValue);
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


        #endregion
    }
}
