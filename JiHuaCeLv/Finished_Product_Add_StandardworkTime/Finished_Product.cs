using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Finished_Product_Add_StandardworkTime
{
    internal class Finished_Product
    {
        [ExcelColumn(Name ="代码")]
        public string Oldcode { get; set; }
        [ExcelColumn(Name = "全工序工时（分钟）")]
        public string Standardtime { get; set; }
    }
}
