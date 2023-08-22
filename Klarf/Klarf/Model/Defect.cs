using Klarf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarf.Model
{
    public partial class Defect
    {
        #region [상수]

        public double[,] defectList;
        public int[,] defectXY;
        public int[] imageCount;

        #endregion



        #region [속성]



        #endregion



        #region [생성자]

        public Defect()
        {
            defectList = new double[453, 19];
            defectXY = new int [453, 2];
            imageCount = new int[453];
        }


        #endregion



        #region [public Method]

        // DefectList에서 XINDEX, YINDEX, IMAGECOUNT를 뽑아내는 함수 만들기
        public void ReadXY()
        {

            OpenFile openFile = new OpenFile();
            defectList = openFile.GetDefectList();


        }
        #endregion



        #region [private Method]



        #endregion

    }
}
