using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.BOM
{
    internal class BOM_YinruMold
    {

        private float qty;

        [ExcelColumn(Name = "*单据头(序号)")]
        public int Xuhao { get; set; }
        [ExcelColumn(Name = "*(单据头)创建组织#编码")]
        public string Zuzhibianma { get; set; }
        [ExcelColumn(Name = "*(单据头)使用组织#名称")]
        public string Zuzhishiyong { get; set; }
        [ExcelColumn(Name = "(单据头)使用组织#编码")]
        public string Zuzhimingcheng { get; set; }

        [ExcelColumn(Name = "(单据头)使用组织#名称")]
        public string Zuzhishiyongmingcheng { get; set; }
        [ExcelColumn(Name = "*(单据头)单据类型#编码")]
        public string Danjuleixingbianma { get; set; }
        [ExcelColumn(Name = "(单据头)单据类型#名称")]
        public string Danjuleixingmingcheng { get; set; }
        [ExcelColumn(Name = "*(单据头)BOM分类")]
        public string BOMfenlei { get; set; }
        [ExcelColumn(Name = "*(单据头)BOM用途")]
        public string BOMyongtu { get; set; }
        [ExcelColumn(Name = "*(单据头)父项物料编码#编码")]
        public string Itemcode { get; set; }
        [ExcelColumn(Name = "(单据头)父项物料编码#名称")]
        public string fuxiangmingcheng { get; set; }
        [ExcelColumn(Name = "*(单据头)父项物料单位#编码")]
        public string fuxiangdanwei { get; set; }
        [ExcelColumn(Name = "(单据头)物料名称")]
        public string wuliaomingcheng { get; set; }
        [ExcelColumn(Name = "(单据头)规格型号")]
        public string guigexinghao { get; set; }
        [ExcelColumn(Name = "(单据头)父项物料单位#编码")]
        public string fuxiangdanweibianma { get; set; }
        [ExcelColumn(Name = "(单据头)父项物料单位#名称")]
        public string fuxiangdanweimingcheng { get; set; }
        [ExcelColumn(Name = "*子项明细(序号)")]
        public int zixiangmingxi { get; set; }
        [ExcelColumn(Name = "*(子项明细)子项物料编码#编码")]
        public string MatItemcode { get; set; }
        [ExcelColumn(Name = "(子项明细)子项物料编码#名称")]
        public string zixiangmingcheng { get; set; }
        [ExcelColumn(Name = "*(子项明细)子项类型")]
        public string zixiangleixing { get; set; }
        [ExcelColumn(Name = "*(子项明细)子项单位#编码")]
        public string zixiangdanwei { get; set; }
        [ExcelColumn(Name = "(子项明细)子项单位#名称")]
        public string zixiangdanweimingcheng { get; set; }
        [ExcelColumn(Name = "*(子项明细)用量类型")]
        public string zixiangyongliangleixing { get; set; }
        [ExcelColumn(Name = "用量")]
        public float Qty
        {
            get { return qty; }
            set
            {
                qty = value;
                if (value > 0.01 && value < 1)
                {
                    Fenzi = 1;
                    Fenmu = 1 / value;
                }
                else
                {
                    Fenzi = value;
                    Fenmu = 1;
                }
            }
        }
        [ExcelColumn(Name = "(子项明细)用量:分子")]
        public float Fenzi { get; private set; }
        [ExcelColumn(Name = "(子项明细)用量:分母")]
        public double Fenmu { get; private set; }

        [ExcelColumn(Name = "*(子项明细)超发控制方式")]
        public string zixiangchaofakongzhifangshi { get; set; }
        [ExcelColumn(Name = "(子项明细)跳层")]
        public string tiaocen { get; set; }
        [ExcelColumn(Name = "*(子项明细)子项来源")]
        public string zixianglaiyuan { get; set; }
        [ExcelColumn(Name = "*(子项明细)生效日期")]
        public string zixiangshengxiaoriqi { get; set; }
        [ExcelColumn(Name = "*(子项明细)失效日期")]
        public string zixiangshixiaoriqi { get; set; }
        [ExcelColumn(Name = "*(子项明细)发料方式")]
        public string zixiangfaliaofangshi { get; set; }
        [ExcelColumn(Name = "*(子项明细)时间单位")]
        public string zixiangshijiandanwei { get; set; }
        [ExcelColumn(Name = "(子项明细)位置号")]
        public string zixiangweizhihao { get; set; }
        [ExcelColumn(Name = "*(子项明细)货主类型")]
        public string zixianghuozhuleixing { get; set; }



    }
}
