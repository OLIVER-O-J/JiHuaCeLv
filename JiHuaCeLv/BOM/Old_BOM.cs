using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.BOM
{
    internal class Old_BOM
    {
        [ExcelColumn(Name ="组织")]
        public string zuzhi { get; set; }
        [ExcelColumn(Name ="BOM单号")]
        public string BOMdanhao { get; set; }
        [ExcelColumn(Name = "BOM行号")]
        public string BOMhanghao { get; set; }
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
        [ExcelColumn(Name ="新父编码")]
        public string xinfubianma { get; set; }
        [ExcelColumn(Name ="新父名称")]
        public string xinfumingcheng { get;set; }
        
        [ExcelColumn(Name = "父项单位")]
        public string fuxiangdanwei { get; set; }
        [ExcelColumn(Name ="旧子编码")]
        public string jiuzibianma {  get; set; }
        [ExcelColumn(Name = "新子编码")]
        public string zixiangbianma { get; set; }
        [ExcelColumn(Name ="新子名称")]
        public string xinzimingcheng {  get; set; }
        [ExcelColumn(Name = "子项单位")]
        public string zixiangdanwei { get; set; }
        [ExcelColumn(Name = "物料类别")]
        public string wuliaoleibie { get; set; }
        [ExcelColumn(Name = "用量")]
        public float yongliang { get; set; }
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
}
