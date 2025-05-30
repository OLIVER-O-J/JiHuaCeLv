using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiHuaCeLv.Service;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Model
{
    internal class List_Model
    {
        [ExcelColumn(Name = "编码")]
        public string Newcode { get; set; }
        [ExcelColumn(Name = "名称")]
        public string Name { get; set; }
        [ExcelColumn(Name = "型号")]
        public string Spec { get; set; }
        [ExcelColumn(Name = "规格型号")]
        public string FSpec { get; set; }
    }
}
