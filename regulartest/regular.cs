using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace regulartest
{
    public class regular
    {
        public static (string bzPart, string remainingPart) ProcessBZString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return ("", "");

            // 分割字符串（支持中英文逗号）
            var parts = input.Split(new[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(p => p.Trim())
                            .ToList();

            // 查找BZ部分
            string fullBzPart = parts.FirstOrDefault(p =>
                p.StartsWith("BZ", StringComparison.OrdinalIgnoreCase)) ?? "";

            if (string.IsNullOrEmpty(fullBzPart))
                return ("", input);

            // 分离BZ编号和附加信息
            var (bzNumber, additionalInfo) = SplitBzComponents(fullBzPart);

            // 从原parts中移除BZ部分
            parts.Remove(fullBzPart);

            // 插入附加信息到原位置
            if (!string.IsNullOrEmpty(additionalInfo))
            {
                int bzIndex = input.IndexOf(fullBzPart);
                int insertPos = parts.FindIndex(p => input.IndexOf(p) > bzIndex);

                if (insertPos >= 0)
                    parts.Insert(insertPos, additionalInfo);
                else
                    parts.Add(additionalInfo);
            }

            // 移动RoHS标记到末尾（处理独立RoHS项）
            parts.RemoveAll(p => p.Equals("RoHS", StringComparison.OrdinalIgnoreCase));
            parts.Add("RoHS");

            return (bzNumber, string.Join(",", parts));
        }

        private static (string bzNumber, string additionalInfo) SplitBzComponents(string fullBzPart)
        {
            // 匹配模式：BZ编号 + 附加信息
            var match = Regex.Match(fullBzPart,
                @"^(BZX?-[A-Z0-9]+(?:[- ][A-Z0-9]+)*)\s*(.*)$",
                RegexOptions.IgnoreCase);

            if (match.Success)
            {
                string bzNumber = match.Groups[1].Value.Trim();
                string additional = match.Groups[2].Value.Trim();

                // 检查附加信息是否包含中文
                bool hasChinese = ContainsChinese(additional);

                return hasChinese
                    ? (bzNumber, additional)
                    : (fullBzPart, "");
            }

            return (fullBzPart, "");
        }

        private static bool ContainsChinese(string text)
        {
            // 中文Unicode范围检测
            return text.Any(c => (c >= 0x4E00 && c <= 0x9FFF) ||
                                (c >= 0x3400 && c <= 0x4DBF) ||
                                (c >= 0x20000 && c <= 0x2A6DF));
        }




        public static (string extractedPart, string remainingString) ExtractKrcu(string input)
        {
            if (string.IsNullOrEmpty(input))
                return ("", "");

            // 分割字符串并移除空项
            var parts = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(p => p.Trim())
                             .ToList();

            // 查找第一个以"KRCU"开头的部分
            var krcuPart = parts.FirstOrDefault(p => p.StartsWith("KRCU", StringComparison.Ordinal));

            if (krcuPart != null)
            {
                // 移除找到的KRCU部分
                parts.Remove(krcuPart);
            }

            // 重新组合剩余部分
            var remaining = string.Join(",", parts);
            return (krcuPart ?? "", remaining);
        }


        /// <summary>
        /// 在名称里面处理KRCU部分，将括号内的内容提取出来并与括号前的内容用逗号连接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static (string extractedPart, string formattedString) ExtractAndFormatKrcu(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return ("", "");

            // 使用正则表达式匹配KRCU部分
            var match = Regex.Match(input, @"KRCU[\w\-\.]+[^)\s]*");

            if (!match.Success)
                return ("", input.Trim());

            string krcuPart = match.Value;

            // 从原字符串中移除KRCU部分及其周围的括号
            string formatted = Regex.Replace(input, @"\s*\(\s*" + Regex.Escape(krcuPart) + @"\s*\)\s*", " ")
                          .Replace(krcuPart, " ")
                          .Replace("  ", " ") // 替换双空格为单空格
                          .Trim();

            // 返回提取的KRCU部分和格式化后的字符串
            return (krcuPart, $"{krcuPart},{formatted}");
        }




        /// <summary>
        ///在规格型号里面处理KRCU部分，将括号内的内容提取出来并与括号前的内容用逗号连接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ProcessString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // 查找第一个左括号的位置
            int leftIndex = input.IndexOf('(');
            if (leftIndex == -1)
                return input; // 没有左括号直接返回

            // 在左括号后查找右括号
            int rightIndex = input.IndexOf(')', leftIndex + 1);
            if (rightIndex == -1)
                return input; // 没有匹配的右括号

            // 提取括号前部分
            string before = input.Substring(0, leftIndex);

            // 提取括号内容（去掉括号）
            string inside = input.Substring(leftIndex + 1, rightIndex - leftIndex - 1);

            // 用逗号连接两部分
            return before + "," + inside;
        }




        public static string GetFirstPart(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] parts = input.Split(',');
            return parts[0].Trim(); // 去除首尾空格（可选）
        }
    }
}
