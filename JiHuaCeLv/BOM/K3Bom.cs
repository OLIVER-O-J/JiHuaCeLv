using Mapster;
using MiniExcelLibs.Attributes;
//using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuaCeLv.BOM
{
    public class K3Bom
    {
        public string Itemcode { get; set; }
        public List<K3SubBom> Subs { get; set; } = new List<K3SubBom>();
        public List<int> LineNumbers
        {
            get
            {
                return Subs.Select(it => it.LineNumber).Distinct().ToList();
            }
        }
        public K3Bom(string itemcode)
        {
            Itemcode = itemcode;
        }
        public K3Bom(K3BomLine line)
        {
            Itemcode = line.Itemcode;
            AddSubBom(line);
        }
        public void AddSubBom(K3BomLine line)
        {
            Subs.Add(new K3SubBom
            {
                LineNumber = line.LineNumber,
                MatItemcode = line.MatItemcode,
                Qty = line.Qty,
            });
        }
        public bool EqualTo(K3Bom bom)
        {
            if (bom.Itemcode != Itemcode)
            { //如果父项不同，判断为不同
                return false;
            }
            if (bom.Subs.Count != Subs.Count)
            {//如果子项数量不同，判断不同
                return false;
            }
            foreach (var item in bom.Subs)
            {
                var sub = Subs.Any(it => it.MatItemcode == item.MatItemcode && it.Qty == item.Qty);
                if (!sub) return false; //如果子项没有包含关系，判断为不同
            }
            // 否则，相同
            return true;
        }
        public K3Bom DeepClone()
        {
            var bom = new K3Bom(Itemcode);
            foreach (var item in Subs)
            {
                bom.Subs.Add(new K3SubBom
                {
                    LineNumber = item.LineNumber,
                    MatItemcode = item.MatItemcode,
                    Qty = item.Qty,
                });
            }
            return bom;
        }
        /// <summary>
        /// 将旧BOM信息选取放入引入模板里
        /// </summary>
        /// <returns></returns>
        public List<K3CloudBomLine> Tok3CloudBomLines()
        {
            var list = new List<K3CloudBomLine>();
            foreach (K3SubBom item in Subs)
            {
                //var line = new K3CloudBomLine
                //{
                //    Itemcode = item.MatItemcode,
                //    MatItemcode = item.MatItemcode,
                //    Qty = item.Qty,
                //    // LineNumber = item.LineNumber,
                //};
                var line = item.Adapt<K3CloudBomLine>();
                line.Itemcode = Itemcode;
                list.Add(line);
            }
            return list;
        }
    }
    public class K3SubBom
    {
        public int LineNumber { get; set; }
        public string MatItemcode { get; set; }
        public float Qty { get; set; }
    }

    public class K3BomLine
    {
        [ExcelColumn(Name = "组织")]
        public string zuzhi { get; set; }
        [ExcelColumn(Name = "BOM单号")]
        public string Itemcode { get; set; }
        [ExcelColumn(Name = "BOM行号")]
        public int LineNumber { get; set; }
        [ExcelColumn(Name = "审核日期")]
        public string shengheriqi { get; set; }
        [ExcelColumn(Name = "使用日期")]
        public string shiyongriqi { get; set; }
        [ExcelColumn(Name = "创建日期")]
        public string chuangjianriqi { get; set; }
        [ExcelColumn(Name = "是否跳层")]
        public string shifoutiaocen { get; set; }
        [ExcelColumn(Name = "旧父编码")]
        public string jiufubianma { get; set; }
        [ExcelColumn(Name = "新父编码")]
        public string xinfubianma { get; set; }
        [ExcelColumn(Name = "新父名称")]
        public string xinfumingcheng { get; set; }

        [ExcelColumn(Name = "父项单位")]
        public string fuxiangdanwei { get; set; }
        [ExcelColumn(Name = "旧子编码")]
        public string MatItemcode { get; set; }
        [ExcelColumn(Name = "新子编码")]
        public string zixiangbianma { get; set; }
        [ExcelColumn(Name = "新子名称")]
        public string xinzimingcheng { get; set; }
        [ExcelColumn(Name = "子项单位")]
        public string zixiangdanwei { get; set; }
        [ExcelColumn(Name = "物料类别")]
        public string wuliaoleibie { get; set; }
        [ExcelColumn(Name = "用量")]
        public float Qty { get; set; }
        [ExcelColumn(Name = "默认仓库")]
        public string morencangku { get; set; }
        [ExcelColumn(Name = "工序号")]
        public string gongxuhao { get; set; }
        [ExcelColumn(Name = "工序ID")]
        public string gongxuid { get; set; }
        [ExcelColumn(Name = "是否倒冲")]
        public string shifoudaochong { get; set; }
        [ExcelColumn(Name = "位置号")]
        public string weizhihao { get; set; }

    }
    public class K3CloudBomLine
    {
        private float qty;

        [ExcelColumn(Name = "*单据头(序号)")]
        public string Xuhao { get; set; }
        [ExcelColumn(Name = "*(单据头)创建组织#编码")]
        public string Zuzhibianma { get; set; }
        [ExcelColumn(Name = "*(单据头)使用组织#编码")]
        public string Zuzhishiyong { get; set; }
        [ExcelColumn(Name = "(单据头)使用组织#名称")]
        public string Zuzhimingcheng { get; set; }
        
        [ExcelColumn(Name = "(单据头)使用组织#编码")]
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
        public string zixiangmingxi { get; set; }
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
