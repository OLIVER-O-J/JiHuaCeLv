using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Serial_number
{
    public class ReadMaterical
    {
        [ExcelColumn(Name = "新代码")]
        public string Newcode { get; set; }
        [ExcelColumn(Name = "代码")]
        public string Oldcode { get; set; }
        [ExcelColumn(Name = "名称")]
        public string Name { get; set; }
        [ExcelColumn(Name = "规格型号")]
        public string Spec { get; set; }
        public string Zhonglei { get { var zhonglei = Spec.PadRight(4); return zhonglei; } }
        [ExcelColumn(Name = "物料属性")]
        public string Unit { get; set; }
        [ExcelColumn(Name = "基本计量单位")]
        public string Type { get; set; }

    }
    public class KinSearchOldcode
    {
        [ExcelColumn(Name = "(物料)旧物料编码")]
        public string Oldcode { get; set; }
    }
    public class K3SearchOldcode
    {
        [ExcelColumn(Name = "新代码")]
        public string Newcode { get; set; }
        [ExcelColumn(Name = "代码")]
        public string Oldcode { get; set; }
        [ExcelColumn(Name = "名称")]
        public string Name { get; set; }
        [ExcelColumn(Name = "规格型号")]
        public string Spec { get; set; }
        public string Zhonglei { get { var zhonglei = Spec.PadRight(4); return zhonglei; } }
        [ExcelColumn(Name = "物料属性")]
        public string Unit { get; set; }
        [ExcelColumn(Name = "基本计量单位")]
        public string Type { get; set; }
    }
}
