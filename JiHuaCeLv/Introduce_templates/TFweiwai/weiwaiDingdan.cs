using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuaCeLv.TFweiwai
{
    internal class weiwaiDingdan
    {
        [ExcelColumn(Name = "加工材料代码")]
        public string materialCode { get; set; }
    }
}
