using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Finished_Product_Add_StandardworkTime
{
    internal class Get_Excel_All_Columns
    {
        public void GetColumns(string path)
        {
            var columns = MiniExcel.GetColumns(path);
        }
        [ExcelColumn(Name = "FOldNumber")]
        public string Oldcode { get; set; }
        public string Substring8
        {
            get
            {
                
                if (Oldcode.Length > 8)
                {
                    var oldcode = Oldcode.Substring(0, 8);
                    return oldcode;
                }
                else
                {
                    return Oldcode;
                }
            }
        }
        [ExcelColumn(Name = "FStdLaborProcessTime")]
        public string Standardtime { get; set; }
    }
}
