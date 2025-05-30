using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.BOM
{
    
    internal class Fill_Head
    {
        //private float qty;
        //[ExcelColumn(Name ="用量")]
        //public float Qty
        //{
        //    get { return qty; }
        //    set
        //    {
        //        qty = value;
        //        if (value >= 0.01 )
        //        {
        //            FNUMERATOR = value;
        //            FDENOMINATOR = 1 ;
        //        }
        //        else
        //        {
        //            FNUMERATOR = 1;
        //            FDENOMINATOR = (float)Math.Round( 1/value,2);
        //        }
        //    }
        //}
        public int FBillHead{ get; set; }
        [ExcelColumn(Name = "FCreateOrgId")]
        public string FCreateOrgId {  get; set; } = "K";
        [ExcelColumn(Name = "FCreateOrgId#Name")]
        public string FCreateOrgIdName { get; set; } = "广东健博通科技股份有限公司";

        public string FUseOrgId { get; set; } = "K";

        public string FUseOrgIdName { get; set; } = "广东健博通科技股份有限公司";

        public string FBILLTYPE { get; set; } = "WLQD01_SYS";


        public string FBILLTYPEName { get; set; }="物料清单";
       
        public string FBOMCATEGORY { get; set; }= "标准BOM";
        
        public string FBOMUSE { get; set; } = "通用";
        [ExcelColumn(Name = "新父项编码")]
        public string FMATERIALID { get; set; }
        [ExcelColumn(Name = "父编码名称")]
        public string FMATERIALIDName { get; set; }
        
        public string FITEMNAME { get; set; }
        
        public string FITEMMODEL { get; set; }
        [ExcelColumn(Name ="父项单位")]
        public string FUNITID { get; set; }
        
        public string FUNITIDName { get; set; }
        public string Spilt { get; set; }
        public int FTreeEntity { get; set; }
        [ExcelColumn(Name = "新子项编码")]
        public string FMATERIALIDCHILD { get; set; }
        [ExcelColumn(Name = "子编码名称")]
        public string FMATERIALIDCHILDName { get; set; }
        
        public string FMATERIALTYPE { get; set; } = "标准件";
        [ExcelColumn(Name ="子项单位")]
        public string FCHILDUNITID { get; set; }
        
        public string FCHILDUNITIDName { get; set; }
        
        public string FDOSAGETYPE { get; set; } = "变动";
        [ExcelColumn(Name ="用量")]
        public float FNUMERATOR { get; set; }

        public string FDENOMINATOR { get; set; } = "1";
       
        public string FBilFOverControlModel { get; set; }
        
        public bool FISSkip { get { return FMATERIALIDCHILD.StartsWith("5."); } }
        
        public string FEntrySource { get; set; }
        [ExcelColumn(Name = "审核日期")]
        public DateTime FEFFECTDATE { get; set; }
        
        public DateTime FEXPIREDATE { get; set; } = DateTime.Parse("9999-12-31");
       
        public string FISSUETYPE { get; set; }
        
        public string FTIMEUNIT { get; set; }
       
        public string FPOSITIONNO { get; set; }

        public string FOWNERTYPEID { get; set; } = "业务组织";
        
    }
}
