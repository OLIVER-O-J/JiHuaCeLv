using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Find_Not_introduced
{
    internal class BOM_Info_Search
    {
        [ExcelColumn(Name = "FBillHead(ENG_BOM)")]
        public int FBillHead { get; set; }
        [ExcelColumn(Name = "FCreateOrgId")]

        public string FCreateOrgId { get; set; } 
        [ExcelColumn(Name = "FCreateOrgId#Name")]
        public string FCreateOrgIdName { get; set; } 
        [ExcelColumn(Name = "FUseOrgId")]
        public string FUseOrgId { get; set; } 
        [ExcelColumn(Name = "FUseOrgId#Name")]
        public string FUseOrgIdName { get; set; }
        [ExcelColumn(Name = "FBILLTYPE")]
        public string FBILLTYPE { get; set; } 
        [ExcelColumn(Name = "FBILLTYPE#Name")]
        public string FBILLTYPEName { get; set; } 
        [ExcelColumn(Name = "FBOMCATEGORY")]
        public string FBOMCATEGORY { get; set; } 
        [ExcelColumn(Name = "FBOMUSE")]
        public string FBOMUSE { get; set; }
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
        public string FMATERIALTYPE { get; set; } 
        [ExcelColumn(Name = "FCHILDUNITID")]
        public string FCHILDUNITID { get; set; }
        [ExcelColumn(Name = "FCHILDUNITID#Name")]
        public string FCHILDUNITIDName { get; set; }

        [ExcelColumn(Name = "FDOSAGETYPE")]
        public string FDOSAGETYPE { get; set; } 
        [ExcelColumn(Name = "FNUMERATOR")]
        public float FNUMERATOR { get; set; }
        [ExcelColumn(Name = "FDENOMINATOR")]
        public string FDENOMINATOR { get; set; }
        [ExcelColumn(Name = "FOverControlMode")]
        public string FBilFOverControlModel { get; set; }
        [ExcelColumn(Name = "FISSkip")]
        public bool FISSkip { get; set; }
        [ExcelColumn(Name = "FEntrySource")]
        public string FEntrySource { get; set; }
        [ExcelColumn(Name = "FEFFECTDATE")]
        public DateTime FEFFECTDATE { get; set; }
        [ExcelColumn(Name = "FEXPIREDATE")]
        public DateTime FEXPIREDATE { get; set; } 
        [ExcelColumn(Name = "FISSUETYPE")]
        public string FISSUETYPE { get; set; }
        [ExcelColumn(Name = "FTIMEUNIT")]
        public string FTIMEUNIT { get; set; }
        [ExcelColumn(Name = "FPOSITIONNO")]
        public string FPOSITIONNO { get; set; }
        [ExcelColumn(Name = "FOWNERTYPEID")]
        public string FOWNERTYPEID { get; set; }
    }
}
