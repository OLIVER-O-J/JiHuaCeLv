using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiHuaCeLv.Service;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Model
{
    internal class Name
    {
        [ExcelColumn(Name = "(物料)编码")]
        public string Code { get; set; }
        [ExcelColumn(Name = "*(物料)名称#中文(简体)")]
        public string name { get; set; }
        [ExcelColumn(Name = "(物料)规格型号#中文(简体)")]
        public string Spec { get; set; }
        [ExcelColumn(Name = "新名称")]
        public string DrawingNO { get { return Regular.SplitAtLastDelimiter(name); } }
    }
}
