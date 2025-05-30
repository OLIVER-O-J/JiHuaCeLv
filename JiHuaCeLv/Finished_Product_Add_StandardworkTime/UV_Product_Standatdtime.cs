using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Finished_Product_Add_StandardworkTime
{
    internal class UV_Product_Standatdtime
    {
        [ExcelColumn(Name ="产品代码")]
        public string Oldcode { get; set; }
        [ExcelColumn(Name ="标准工时（分钟）")]
        public string Standardtime { get; set; }
    }
}
