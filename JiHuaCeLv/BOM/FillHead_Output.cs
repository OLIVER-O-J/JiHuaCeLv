using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.BOM
{
    internal class FillHead_Output
    {
        //private float qty;
        [ExcelColumn(Name = "FBillHead(ENG_BOM)")]
        public int FBillHead { get; set; }
        [ExcelColumn(Name = "FCreateOrgId")]
        
        public string FCreateOrgId { get; set; } = "K";
        [ExcelColumn(Name = "FCreateOrgId#Name")]
        public string FCreateOrgIdName { get; set; } = "广东健博通科技股份有限公司";
        [ExcelColumn(Name = "FUseOrgId")]
        public string FUseOrgId { get; set; } = "K";
        [ExcelColumn(Name = "FUseOrgId#Name")]
        public string FUseOrgIdName { get; set; }
        [ExcelColumn(Name = "FBILLTYPE")]
        public string FBILLTYPE { get; set; } = "WLQD01_SYS";
        [ExcelColumn(Name = "FBILLTYPE#Name")]
        public string FBILLTYPEName { get; set; } = "物料清单";
        [ExcelColumn(Name = "FBOMCATEGORY")]
        public string FBOMCATEGORY { get; set; } = "标准BOM";
        [ExcelColumn(Name = "FBOMUSE")]
        public string FBOMUSE { get; set; } = "通用";
        [ExcelColumn(Name = "FMATERIALID")]
        public string FMATERIALID { get; set; }
        [ExcelColumn(Name = "FMATERIALID#Name")]
        public string FMATERIALIDName { get; set; }
        [ExcelColumn(Name = "FITEMNAME")]
        public string FITEMNAME { get; set; }
        [ExcelColumn(Name = "FITEMMODEL")]
        public string FITEMMODEL { get; set; }
        [ExcelColumn(Name = "FUNITID")]
        public string FUNITID { get; set; }
        [ExcelColumn(Name = "FUNITID#Name")]
        public string FUNITIDName { get; set; }
       
        [ExcelColumn(Name = "*Split*1")]
        public string Spilt { get; set; }
        [ExcelColumn(Name = "FTreeEntity")]
        public int FTreeEntity { get; set; }
        [ExcelColumn(Name = "FMATERIALIDCHILD")]
        public string FMATERIALIDCHILD { get; set; }
        [ExcelColumn(Name = "FMATERIALIDCHILD#Name")]
        public string FMATERIALIDCHILDName { get; set; }
        [ExcelColumn(Name = "FMATERIALTYPE")]
        public string FMATERIALTYPE { get; set; } = "标准件";
        [ExcelColumn(Name = "FCHILDUNITID")]
        public string FCHILDUNITID { get; set; }
        [ExcelColumn(Name = "FCHILDUNITID#Name")]
        public string FCHILDUNITIDName { get; set; }
        
        [ExcelColumn(Name = "FDOSAGETYPE")]
        public string FDOSAGETYPE { get; set; } = "变动";
        [ExcelColumn(Name = "FNUMERATOR")]
        public float FNUMERATOR { get; set; }
        [ExcelColumn(Name = "FDENOMINATOR")]
        public string FDENOMINATOR { get; set; }
        [ExcelColumn(Name = "FOverControlMode")]
        public string FBilFOverControlModel { get; set; }
        [ExcelColumn(Name = "FISSkip")]
        public bool FISSkip { get { return FMATERIALIDCHILD.StartsWith("5."); } }
        [ExcelColumn(Name = "FEntrySource")]
        public string FEntrySource { get; set; }
        [ExcelColumn(Name = "FEFFECTDATE")]
        public DateTime FEFFECTDATE { get; set; }
        [ExcelColumn(Name = "FEXPIREDATE")]
        public DateTime FEXPIREDATE { get; set; } = DateTime.Parse("9999-12-31");
        [ExcelColumn(Name = "FISSUETYPE")]
        public string FISSUETYPE { get; set; }
        [ExcelColumn(Name = "FTIMEUNIT")]
        public string FTIMEUNIT { get; set; }
        [ExcelColumn(Name = "FPOSITIONNO")]
        public string FPOSITIONNO { get; set; }
        [ExcelColumn(Name = "FOWNERTYPEID")]
        public string FOWNERTYPEID { get; set; } = "业务组织";

    }
}
