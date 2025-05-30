using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace JiHuaCeLv.Model
{
    public class RegularExpression
    {
        public class SubSpec
        {
            [ExcelColumn(Name = "名称")]
            public string Name { get; set; }
            [ExcelColumn(Name = "型号")]
            public string Spec { get { return GetSpec(Name); } }
        }

        private static string GetSpec(string name)
        {
            string pattern = @"^[^,\s\u4e00-\u9fa5]+";
            Regex regex = new Regex(pattern);
            MatchCollection matchs = regex.Matches(name);
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            foreach (Match match in matchs)
            {
                result.Append(match.Value);
            }
            return result.ToString();
        }
    }

}
