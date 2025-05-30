using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuaCeLv
{
    internal class yinrumold
    {
        [ExcelColumn(Name = "新代码")]
        public string NewCode { get; set; }
        [ExcelColumn(Name = "名称")]
        public string Name { get; set; }
        [ExcelColumn(Name = "规格型号")]
        public string Spec { get; set; }
        [ExcelColumn(Name = "代码")]
        public string OldCode { get; set; }
        [ExcelColumn(Name = "中类代码")]
        public string Zhongleicode { get
            {
                var zhonglei = NewCode.Substring(0, 4);
                return zhonglei;
            }
        }
        [ExcelColumn(Name = "研发目标价")]
        public string Goalpice { get; set; }
        [ExcelColumn(Name = "最小订货量(自定)")]
        public string Mindinghuo { get; set; }
        [ExcelColumn(Name = "最小包装量(自定)")]
        public string Minibaozhuang { get; set; }
        [ExcelColumn(Name = "特殊订单审批")]
        public string Specdingdan { get; set; }
        [ExcelColumn(Name = "变更后首次生产")]
        public string Updateshenchan { get; set; }
        [ExcelColumn(Name = "豁免样品认证")]
        public string Yangpinrenz { get; set; }
        [ExcelColumn(Name = "图号")]
        public string Picture { get; set; }
        [ExcelColumn(Name = "物料属性")]
        public string Unit { get; set; }
        [ExcelColumn(Name = "存货类别.编码")]
        public string Categotty { get; set; }
        [ExcelColumn(Name = "基本计量单位")]
        public string Type { get; set; }
        [ExcelColumn(Name = "毛重")]
        public string MAOzhong { get; set; }
        [ExcelColumn(Name = "净重")]
        public string Jingzhong { get; set; }
        [ExcelColumn(Name = "仓库.编码")]
        public string Warenumber { get; set; }
        [ExcelColumn(Name = "启用批号管理")]
        public string Ispihao { get; set; }
        [ExcelColumn(Name = "批号编码规则.编码")]
        public string Pihaorule { get; set; }
        [ExcelColumn(Name="启用保质期管理")]
        public string Isbaozhiqi {  get; set; }
        [ExcelColumn(Name = "保质期单位")]
        public string Baozhiqitype { get; set; }
        [ExcelColumn(Name = "保质期(年)")]
        public string Baozhiqi { get; set; }
        [ExcelColumn(Name = "计划策略")]
        public string Planlv { get; set; }
        [ExcelColumn(Name = "制造策略.编码")]
        public string Cratelv { get; set; }
        [ExcelColumn(Name = "固定提前期")]
        public string Gudingtiqian { get; set; }
        [ExcelColumn(Name = "生产车间.编码")]
        public string Shengchanchejian { get; set; }
        [ExcelColumn(Name = "超发控制方式")]
        public string Overissuecontro { get; set; }
        [ExcelColumn(Name ="发料方式")]
         public string FaliaoWays {  get; set; }
        [ExcelColumn(Name ="标准工时")]
        public  string StandardTime {  get; set; }
        
        
        
        
        
        
    }
}
