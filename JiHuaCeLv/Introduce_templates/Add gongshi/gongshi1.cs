using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuaCeLv
{
    internal class gongshi1
    {
        [ExcelColumn(Name = "物料代码")]
        public string MaterCode { get; set; }
        [ExcelColumn(Name = "标准工时")]
        public string CostTime { get; set; }
    }
}
