using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Klarf.Model
{
    class DefectInfo
    {
        public double defectID, xrel, yrel, xSize, ySize, defectArea, dSize, classNumber, test, clusterNumber, roughBinNumber, fineBinNumber, reviewSample, imageCount, imageList;
        public Point defectXY;
    }

    class DieInfo
    {
        #region [상수]

        public List<DefectInfo> defectList;
        public DefectInfo defectInfo;

        #endregion



        #region [속성]



        #endregion



        #region [생성자]

        public DieInfo()
        {
            defectList = new List<DefectInfo>();
            defectInfo = new DefectInfo();
        }


        #endregion



        #region [public Method]

        public List<DefectInfo> ReadDefectList(string textValue)
        {

            int defectIndex = textValue.IndexOf("DefectList") + "DefectList".Length;
            int endIndex = textValue.IndexOf(';', defectIndex);
            string substringFile = textValue.Substring(defectIndex, endIndex - defectIndex);
            string[] lines = substringFile.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            string[] values = new string[17];

            for (int i = 0; i < lines.Length / 2; i++)
            {

                string[] defectValue;
                defectValue = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < defectValue.Length; k++)
                {
                    values[k] = defectValue[k];
                }

                AddInfo(values);
                defectList.Add(defectInfo);
            }

            return defectList;
        }


        public int[,] ReadDefectXY(string textValue)
        {

            int[,] defectXY = new int[defectList.Count, 2];

            for (int i = 0; i < defectList.Count; i++)
            {
                defectXY[i, 0] = (int)defectList[i].defectXY.X;
                defectXY[i, 1] = (int)defectList[i].defectXY.Y;
            }

            return defectXY;
        }
        #endregion



        #region [private Method]
        private void AddInfo(string[] values)
        {
            for (int j = 0; j < values.Length; j++)
            {
                if (j == 0)
                {
                    defectInfo.defectID = double.Parse(values[j]);
                }

                else if (j == 1)
                {
                    defectInfo.xrel = double.Parse(values[j]);
                }

                else if (j == 2)
                {
                    defectInfo.yrel = double.Parse(values[j]);
                }

                else if (j == 3)
                {
                    defectInfo.defectXY.X = double.Parse(values[j]);
                }

                else if (j == 4)
                {
                    defectInfo.defectXY.Y = double.Parse(values[j]);
                }

                else if (j == 5)
                {
                    defectInfo.xSize = double.Parse(values[j]);
                }

                else if (j == 6)
                {
                    defectInfo.ySize = double.Parse(values[j]);
                }

                else if (j == 7)
                {
                    defectInfo.defectArea = double.Parse(values[j]);
                }

                else if (j == 8)
                {
                    defectInfo.dSize = double.Parse(values[j]);
                }

                else if (j == 9)
                {
                    defectInfo.classNumber = double.Parse(values[j]);
                }

                else if (j == 10)
                {
                    defectInfo.test = double.Parse(values[j]);
                }

                else if (j == 11)
                {
                    defectInfo.clusterNumber = double.Parse(values[j]);
                }

                else if (j == 12)
                {
                    defectInfo.roughBinNumber = double.Parse(values[j]);
                }

                else if (j == 13)
                {
                    defectInfo.fineBinNumber = double.Parse(values[j]);
                }

                else if (j == 14)
                {
                    defectInfo.reviewSample = double.Parse(values[j]);
                }

                else if (j == 15)
                {
                    defectInfo.imageCount = double.Parse(values[j]);
                }

                else
                {
                    defectInfo.imageList = double.Parse(values[j]);
                }
            }
        }



        #endregion
    }
}
