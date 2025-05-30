using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;
using static JiHuaCeLv.DangerousMaterical_s_BOM.SeparateBOMService;

namespace JiHuaCeLv.BOMexchangeQTY
{
    internal class Read
    {
        public  class K3BOM
        {
            [ExcelColumn(Name ="父项")]
            public string FMATERIALID {  get; set; }
            [ExcelColumn(Name = "子项")]
            public string FMATERIALIDCHILD { get; set; }
            [ExcelColumn(Name ="分子")]
            public string FNUMERATOR { get; set; }
            [ExcelColumn(Name = "分子修改为")]
            public string FNUMERATORex { get; set; }
            [ExcelColumn(Name ="分母")]
            public string FDENOMINATOR { get;set; }
            [ExcelColumn(Name = "分母修改为")]
            public string FDENOMINATORex { get; set; }
        }
        public  class K3CloudBOM
        {
            [ExcelColumn(Name = "父项物料编码")]
            public string FMATERIALID { get; set; }
            [ExcelColumn(Name = "子项物料编码")]
            public string FMATERIALIDCHILD { get;set; }
            [ExcelColumn(Name = "用量:分子")]
            public string FNUMERATOR { get; set; }
            [ExcelColumn(Name = "用量:分母")]
            public string FDENOMINATOR { get; set; }
        }
        
        
    }
}
