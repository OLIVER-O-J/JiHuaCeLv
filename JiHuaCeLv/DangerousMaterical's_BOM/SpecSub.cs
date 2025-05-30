using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.DangerousMaterical_s_BOM
{
    internal class SpecSub
    {
        public class Materical
        {
            [ExcelColumn(Name = "(物料)编码")]
            public string Description { get; set; }
            [ExcelColumn(Name = "*(物料)名称#中文(简体)")]
            public string Name { get; set; }
            public string 型号 { get { return GetSpec(Name); } }
            [ExcelColumn(Name = "(物料)规格型号#中文(简体)")]
            public string Spec { get; set; }
            public string GetSpec { get { return GetSpec(Spec); } }
        }
        public class MyClass
        {
            [ExcelColumn(Name = "名称")]
            public string Name { get; set; }
            [ExcelColumn (Name ="型号")]
            public string Spec { get { return GetSpec(Name); } }
        }
        /// <summary>
        /// 返回非中文字符的字符串                                                                                                                                    
        /// </summary>
        /// <param name="mold"></param>
        /// <returns></returns>
        private static string GetSpec(string mold)
        {
            string pattern = @"^[^,\s\u4e00-\u9fa5]+";
            Regex regex = new Regex(pattern);
            MatchCollection matchs = regex.Matches(mold);
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (Match match in matchs)
            {
                result.Append(match.Value);
            }
            return result.ToString();
        }
    }
}
