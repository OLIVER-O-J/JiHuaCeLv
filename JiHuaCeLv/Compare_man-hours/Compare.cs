using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Compare_man_hours
{
    internal class Compare
    {
        
        [ExcelColumn(Name ="产品代码")]
        public string Oldcode { get; set; }
        [ExcelColumn(Name ="产品名称")]
        public string Name { get; set; }
        [ExcelColumn(Name ="规格型号")]
        public string Spec { get; set; }
        [ExcelColumn(Name ="产品类别")]
        public string Olddate { get; set; }
        [ExcelColumn(Name ="工时")]
        public string Standardtime { get; set; }
        
    }
}
