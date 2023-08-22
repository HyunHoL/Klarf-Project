using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klarf.ViewModel;
using Microsoft.Win32;

namespace Klarf.Model
{
    public partial class FilePathData
    {
        #region [상수]



        #endregion

        #region [인터페이스]



        #endregion

        #region [속성]



        #endregion

        #region [생성자]



        #endregion

        #region [public Method]

        public string ReadFileData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\hhlee\OneDrive - 에이티아이\바탕 화면\Klarf 과제";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                return selectedFilePath;
            }

            else
            {
                return "ERROR";
            }
        }

        public void ReadSampleTestPlan(string textValue, int[,] sampleTestPlan)
        {
            int testPlanIndex = textValue.IndexOf("SampleTestPlan") + "SampleTestPlan".Length + 4;
            int endIndex = textValue.IndexOf(';', testPlanIndex);

            string substringFile = textValue.Substring(testPlanIndex, endIndex - testPlanIndex);
            string[] lines = substringFile.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (values.Length == 2 && int.TryParse(values[0], out int value1) && int.TryParse(values[1], out int value2))
                {
                    sampleTestPlan[i, 0] = value1;
                    sampleTestPlan[i, 1] = value2;
                }
            }
        }

        public string ReadFileTimeStamp(string textValue)
        {
            int timeStampIndex = textValue.IndexOf("FileTimestamp ") + "FileTimestamp".Length + 1;
            int endIndex = textValue.IndexOf(';', timeStampIndex);

            string substringFile = textValue.Substring(timeStampIndex, endIndex - timeStampIndex);
            return substringFile;
        }

        public string ReadLotID(string textValue)
        {
            int lotIDIndex = textValue.IndexOf("LotID ") + "LotID".Length + 1;
            int endIndex = textValue.IndexOf(';', lotIDIndex);

            string substringFile = textValue.Substring(lotIDIndex, endIndex - lotIDIndex);
            return substringFile;
        }

        public string ReadWaferID(string textValue)
        {
            int waferIDIndex = textValue.IndexOf("WaferID ") + "WaferID".Length + 1;
            int endIndex = textValue.IndexOf(';', waferIDIndex);

            string substringFile = textValue.Substring(waferIDIndex, endIndex - waferIDIndex);
            return substringFile;
        }

        public void ReadDefectList(string textValue, double[,] defectList)
        {
            int defectIndex = textValue.IndexOf("DefectList") + "DefectList".Length;
            int endIndex = textValue.IndexOf(';', defectIndex);

            string substringFile = textValue.Substring(defectIndex, endIndex - defectIndex);
            string[] lines = substringFile.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string[] values = new string[19];

            for (int i = 0; i < lines.Length; i++)
            {

                string[] defectValue;
                if (i % 2 == 0)
                {
                    defectValue = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < defectValue.Length; k++)
                    {
                        values[k] = defectValue[k];
                    }
                }

                else if (i % 2 != 0)
                {
                    defectValue = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int r = 0; r < defectValue.Length; r++)
                    {
                        values[r + 17] = defectValue[r];
                    }

                    for (int j = 0; j < values.Length; j++)
                    {
                        int r = i / 2;
                        defectList[r, j] = double.Parse(values[j]);
                    }
                }
            }
        }
        #endregion

        #region [private Method]

        #endregion
    }
}
