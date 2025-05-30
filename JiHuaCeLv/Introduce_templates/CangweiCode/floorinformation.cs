using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuaCeLv.fugaiyinru
{
    internal class floorinformation
    {

        [ExcelColumn(Name = "新代码")]
        public string Newcode { get; set; }
        [ExcelColumn(Name = "规格型号")]
        public string Spec { get; set; }
        [ExcelColumn(Name = "代码")]
        public string OldCode { get; set; }
        [ExcelColumn(Name = "物料属性")]
        public string Unit { get; set; }
        [ExcelColumn(Name = "基本计量单位")]
        public string Type { get; set; }
        [ExcelColumn(Name = "中类代码")]
        public string ZhongleiCode
        {
            get
            {
                var zhonglei = Newcode.Substring(0, 4);
                return zhonglei;
            }
        }
        [ExcelColumn(Name = "名称")]
        public string Name { get; set; }
        [ExcelColumn(Name = "是否启用批号")]
        public string IsPihao { get; set; }
        [ExcelColumn(Name = "批号规则")]
        public string PihaoRule { get; set; }
        [ExcelColumn(Name = "是否启用保质期")]
        public string IsProtect { get; set; }
        [ExcelColumn(Name = "生产日期")]
        public string Birthday { get; set; }
        [ExcelColumn(Name = "保质期(年)")]
        public string ProtectYear { get; set; }
        [ExcelColumn(Name = "是否启用序列号")]
        public string SerialNumber { get; set; }
        [ExcelColumn(Name = "存货类别(指向科目)")]
        public string InventoryCategory { get; set; }
        [ExcelColumn(Name = "物料类别")]
        public string MatericalCategory { get; set; }
        [ExcelColumn(Name = "默认仓库")]
        public string WareHouse { get; set; }
        [ExcelColumn(Name = "超发上限(%)")]
        public string OverissueMax { get; set; }
        [ExcelColumn(Name = "超发下限(%)")]
        public string OverissueMin { get; set; }
        [ExcelColumn(Name = "收货上限比例(%)")]
        public string ReceivingMax { get; set; }
        [ExcelColumn(Name = "收货下限比例(%)")]
        public string ReceivingMin { get; set; }
        //[ExcelColumn(Name = "来料检验")]
        //public string MatericalCome { get; set; }
        //[ExcelColumn(Name = "产品检验")]
        //public string ProductCheck { get; set; }
        //[ExcelColumn(Name = "库存检验")]
        //public string WareSave { get; set; }
        [ExcelColumn(Name = "入库超收比例(%)")]
        public string RukuChaoshou { get; set; }
        [ExcelColumn(Name = "入库欠收比例(%)")]
        public string RukuQianshou { get; set; }
        [ExcelColumn(Name = "是否作为BOM子项")]
        public string BOMson { get; set; }
        [ExcelColumn(Name = "发料方式")]
        public string FAliaoWays { get; set; }
        [ExcelColumn(Name = "超发控制")]
        public string OverissueContronl { get; set; }
        [ExcelColumn(Name = "是否关键件")]
        public string IsKey { get; set; }
        [ExcelColumn(Name = "生产车间")]
        public string ShengchanChejian { get; set; }
        [ExcelColumn(Name = "辅料月末是否盘点")]
        public string FUliaoPandian { get; set; }
        [ExcelColumn(Name = "计划策略")]
        public string Planlv { get; set; }
        [ExcelColumn(Name = "制造策略")]
        public string Creatlv { get; set; }
        [ExcelColumn(Name = "标准工时")]
        public string StandardTime { get; set; }
        [ExcelColumn(Name = "仓位码")]
        public string cangweicode { get; set; }
    }
}
