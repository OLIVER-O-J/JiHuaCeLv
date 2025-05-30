using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MiniExcelLibs;
using MiniExcelLibs.Attributes;

namespace LittleOption
{
    internal class option
    {
        public class Unit
        {
            [ExcelColumn(Name = "产品名称")]
            public string Name { get; set; }
            [ExcelColumn(Name = "型号")]
            public string Description { get { return GetMoldSuString(Name); } }
        }
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
    }

}
