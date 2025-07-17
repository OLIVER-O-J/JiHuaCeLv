using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JiHuaCeLv.Service;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Model
{
    internal class GetSpec
    {
        [ExcelColumn(Name = "(物料)编码")]
        public string Newcode { get; set; }

        [ExcelColumn(Name = "(物料)规格型号#中文(简体)")]
        public string Spec { get; set; }

        public string sspec { get { return RemoveRoHSTag(Spec); } }

        public static string RemoveRoHSTag(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return ""; // 修复错误：返回类型应为 string，而不是元组  

            // 使用正则表达式匹配"[符合RoHS]"，忽略大小写  
            string pattern = @"\[符合RoHS\]";
            return Regex.Replace(input, pattern, "", RegexOptions.IgnoreCase).Trim();
        }
    }
}
