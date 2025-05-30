using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.ExceptFuxiang
{
    internal class Add_Fuxiang_Code
    {
        [ExcelColumn(Name ="新加父项")]
        public string Code { get; set; }
    }
}
