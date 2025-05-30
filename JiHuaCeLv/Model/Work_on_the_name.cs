using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiHuaCeLv.Service;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Model
{
    internal class Work_on_the_name
    {
        [ExcelColumn(Name = "(物料)编码")]
        public string Newcode { get; set; }
        [ExcelColumn(Name = "*(物料)名称#中文(简体)")]
        public string Name { get; set; }
        
        [ExcelColumn(Name = "(物料)规格型号#中文(简体)")]
        public string Spec { get; set; }
        [ExcelColumn(Name = "图号")]
        public string drawingno { get { return Regular.ProcessBZString(Spec).bzPart; } set; }//将图号提取出来
        [ExcelColumn(Name = "型号")]
        public string sppec { get { return Regular.ProcessBZString(Spec).remainingPart; }  }//图号提取出来之后剩下的部分
    }
}
