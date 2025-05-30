using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;
using Newtonsoft.Json;

namespace JiHuaCeLv.DangerousMaterical_s_BOM
{
    internal class GetBOMInfo
    {
        public class Unit
        {
            [ExcelColumn(Name = "产品名称")]
            public string Name { get; set; }
            [ExcelColumn(Name = "型号")]
            public string Description { get { return GetMoldSuString(Name); } }
        }
        /// <summary>
        /// 对一串字符就行正则提取，返回非中文字符串
        /// </summary>
        /// <param name="mold"></param>
        /// <returns></returns>
        public static string GetMoldSuString(string mold)
        {
            string pattern = @"[^\u4e00-\u9fff]+";
            Regex regex = new Regex(pattern);
            MatchCollection matchs = regex.Matches(mold);
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (Match match in matchs)
            {
                result.Append(match.Value);
            }
            return result.ToString();
        }
        public class Info
        {
            [ExcelColumn(Name = "父项物料编码")]
            public string FMATERIALID { get; set; }
            [ExcelColumn(Name = "型号")]
            public string Spec { get { return GetMoldSuString(FMATERIALID); } }
            [ExcelColumn(Name = "FReplaceGroup")]//子项序号
            public int Count { get; set; }
            [ExcelColumn(Name = "子项物料编码")]
            public string FMATERIALIDCHILD { get; set; }
            [ExcelColumn(Name = "是否风险产品")]
            public string IsDangerousProduct { get; set; }
        }
        /// <summary>
        /// HTTP接收信息通用的类
        /// </summary>
        public class MagicReapone
        {
            public bool Success { get; set; }
            public int Code { get; set; }
            public string Message { get; set; }
            public string Data { get; set; }

        }
        public class FatherCode
        {
            public string Data { get; set; }//??
           public List<Itemcode> DataDetail { get { return JsonConvert.DeserializeObject<List<Itemcode>>(Data); } }

        }
        public class Itemcode
        {
            public string itemcode { get; set; }
        }
            /// <summary>
            /// 接收对象类型
            /// </summary>
            public class BomInfo
            {
                public string Fid { get; set; }
                public string BomNum { get; set; }
                public string Itemcode { get; set; }
                public string OldCode { get; set; }
                public string ProductName { get; set; }
                public string ItemSpec { get; set; }
                public string BomStatus { get; set; }
                public string ForbidStaus { get; set; }
                public string Seq { get; set; }
                public string MatCode { get; set; }
                public string MatOldCode { get; set; }
                public string MatModelNo { get; set; }
                public string MatSpec { get; set; }
                public string ErpClsId { get; set; }
                public string ErpCls { get; set; }
                public string Unit { get; set; }
                public string Qty { get; set; }
                public string Level { get; set; }
                public string Levels { get; set; }
            }

        }
    }

