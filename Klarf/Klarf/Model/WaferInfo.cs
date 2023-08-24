using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Klarf.ViewModel;
using Microsoft.Win32;

namespace Klarf.Model
{
    public partial class WaferInfo
    {
        #region [상수]

        Point sampleTestPlanData;
        List<Point> sampleTestPlan;

        #endregion

        #region [인터페이스]



        #endregion

        #region [속성]



        #endregion

        #region [생성자]

        public WaferInfo()
        {
            
        }

        #endregion

        #region [public Method]

        public string ReadWaferID(string textValue)
        {

            int waferIDIndex = textValue.IndexOf("WaferID ") + "WaferID".Length + 1;
            int endIndex = textValue.IndexOf(';', waferIDIndex);

            string substringFile = textValue.Substring(waferIDIndex, endIndex - waferIDIndex);
            return substringFile;
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

        public string ReadDevicID(string textValue)
        {

            int deviceIDIndex = textValue.IndexOf("DeviceID ") + "DeviceID".Length + 1;
            if (deviceIDIndex == -1)
            {
                return " ";
            }

            int endIndex = textValue.IndexOf(';', deviceIDIndex);

            string substringFile = textValue.Substring(deviceIDIndex, endIndex - deviceIDIndex);
            return substringFile;
        }

        public List<Point> ReadSampleTestPlan(string textValue)
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
                    sampleTestPlanData.X = value1;
                    sampleTestPlanData.Y = value2;
                    sampleTestPlan.Add(sampleTestPlanData);
                }
            }

            return sampleTestPlan;
        }



        #endregion

        #region [private Method]

        #endregion
    }
}
