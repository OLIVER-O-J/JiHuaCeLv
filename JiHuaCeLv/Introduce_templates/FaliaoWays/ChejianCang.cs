using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuaCeLv.FaliaoWays
{
    internal class ChejianCang
    {
        [ExcelColumn(Name = "物料代码")]
        public string MaterCode { get; set; }
    }
}
