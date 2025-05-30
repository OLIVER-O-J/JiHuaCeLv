using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Compare_man_hours
{
    internal class standlardlist
    {
        [ExcelColumn(Name = "FOldNumber")]
        public string Oldcode { get; set; }
        [ExcelColumn(Name = "FStdLaborProcessTime")]
        public string Standardtime { get; set; }
    }
}
