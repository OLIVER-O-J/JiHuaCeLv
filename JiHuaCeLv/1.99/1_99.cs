using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv._1._99
{
    internal class _1_99
    {
        [ExcelColumn(Name ="新代码")]
        public string Newcode {  get; set; }
        [ExcelColumn(Name ="品号")]
        public string Oldcode { get; set; }
        [ExcelColumn(Name ="名称")]
        public string Name {  get; set; }
        [ExcelColumn(Name="规格型号")]
        public string Spec { get { var newspec = Jingcang + ","+ Shengchandanhao+ "," + Cangwei;return newspec; }  }
        [ExcelColumn(Name="仓位")]
        public string Cangwei {  get; set; }
        [ExcelColumn(Name="进仓日期")]
        public string Jingcang {  get; set; }
        [ExcelColumn(Name="生产单号")]
        public string Shengchandanhao {  get; set; }
        [ExcelColumn(Name ="物料属性")]
        public string Unit { get; set; } = "自制";
        [ExcelColumn(Name="基本计量单位")]
        public string Type {  get; set; }
    }
}
