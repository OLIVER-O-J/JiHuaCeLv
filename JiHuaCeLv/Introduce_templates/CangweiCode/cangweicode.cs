using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuaCeLv
{
    internal class cangweicode
    {
        [ExcelColumn(Name ="物料代码")]
        public string matericalcode { get; set; }
        [ExcelColumn(Name ="仓位码")]
        public string cangcode { get; set; }
    }
}
