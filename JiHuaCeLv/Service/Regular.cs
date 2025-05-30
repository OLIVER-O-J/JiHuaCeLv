using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JiHuaCeLv.Service
{
    internal class Regular
    {

        /// <summary>
        /// 对7包材物料名称的修改方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static (string Extracted, string Remaining) FilterString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return (null, null);

            // 按逗号分割字符串（忽略括号内的逗号，支持中英文逗号）
            var parts = Regex.Split(input, @"[，,](?![^(\[]*[)\]])")
                            .Select(p => p.Trim())
                            .Where(p => !string.IsNullOrEmpty(p))
                            .ToArray();

            // 查找BZ开头的部分
            string bzPart = parts.FirstOrDefault(p =>
                p.StartsWith("BZ", StringComparison.OrdinalIgnoreCase));

            // 处理BZ部分
            string cleanedBzPart = null;
            if (bzPart != null)
            {
                // 移除所有括号及其内容（包括中文括号、方括号等）
                string temp = Regex.Replace(bzPart, @"[\(\[\{<].*?[\)\]\}>]", "").Trim();

                // 移除所有非ASCII字符（保留英文、数字和常见符号）
                temp = Regex.Replace(temp, @"[^\x20-\x7E]", "").Trim();

                // 清理格式
                temp = Regex.Replace(temp, @"-+", "-");  // 合并多个连字符
                temp = Regex.Replace(temp, @"\s+", " "); // 合并多个空格
                temp = temp.Trim('-').Trim();            // 移除首尾连字符和空格

                cleanedBzPart = temp;
            }

            // 重建剩余部分
            string remaining = bzPart != null
                ? string.Join(", ", parts.Where(p => !p.Equals(bzPart, StringComparison.OrdinalIgnoreCase)))
                : string.Join(", ", parts);

            return (cleanedBzPart, remaining);
        }

        /// <summary>
        /// 分离文本中的中文和非中文部分，保留非中文部分的空格，移除末尾非字母数字符号
        /// </summary>
        /// <param name="input">输入的混合文本</param>
        /// <returns>包含英文和中文部分的元组</returns>
        public static (string EnglishPart, string ChinesePart) SeparateText(string input)
        {
            if (string.IsNullOrEmpty(input))
                return ("", "");

            // 提取全部非中文字符（包括符号和空格）
            string engNum = Regex.Replace(input, "[\u4e00-\u9fa5]", "");

            // 去除末尾的非字母数字字符（保留中间空格）
            while (!string.IsNullOrEmpty(engNum) && !char.IsLetterOrDigit(engNum[engNum.Length - 1]))
            {
                engNum = engNum.Substring(0, engNum.Length - 1);
            }

            // 提取中文部分
            string chinesePart = string.Join("", Regex.Matches(input, "[\u4e00-\u9fa5]+")
                .Cast<Match>()
                .Select(m => m.Value));

            return (engNum, chinesePart);
        }
        /// <summary>
        /// 提取图号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        // 定义方法，输入原始字符串，输出提取的非中文内容（集合或拼接字符串）
        public static string ExtractNonChineseParts(string input)
        {
            int commaIndex = input.IndexOf(',');
            string beforeComma = commaIndex >= 0 ? input.Substring(0, commaIndex) : input;

            Regex nonChineseRegex = new Regex("[^\u4e00-\u9fa5]+");
            Match match = nonChineseRegex.Match(beforeComma);
            if (match.Success)
            {
                return match.Value.Trim();
            }
            return "";
        }
        public static string SplitAndJoinFirstTwoParts(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // 检查是否包含中文单位（如"米"、"欧"等）
            if (Regex.IsMatch(input, @"[\u4e00-\u9fa5]"))
            {
                // 查找第一个空格位置
                int firstSpaceIndex = input.IndexOf(' ');
                if (firstSpaceIndex > 0 && firstSpaceIndex < input.Length - 1)
                {
                    return $"{input.Substring(0, firstSpaceIndex).Trim()},{input.Substring(firstSpaceIndex + 1).Trim()}";
                }
            }

            // 若没有中文单位或无有效空格，使用原逻辑（按空格/逗号分割）
            string[] parts = Regex.Split(input, @"(?<!\([^()]*)(?:,|，|\s)(?!([^()]*\)[^()]*)*[^()]*\))")
                                .Select(p => p.Trim())
                                .Where(p => !string.IsNullOrEmpty(p))
                                .ToArray();

            return parts.Length >= 2
                ? $"{parts[0]},{parts[1]}"
                : parts.FirstOrDefault() ?? string.Empty;
        }

        /// <summary>
        /// 对5组件名称的修改方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SplitAtLastDelimiter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // 中文字符正则
            Regex chineseRegex = new Regex(@"[\u4e00-\u9fa5]");
            // 英文字符正则
            Regex englishRegex = new Regex(@"[A-Za-z]");

            // 规则1：如果第一个字符是中文，直接返回原字符串
            if (chineseRegex.IsMatch(input[0].ToString()))
            {
                return input;
            }

            // 新增规则：如果整个字符串不含英文字母，直接返回
            if (!englishRegex.IsMatch(input))
            {
                return input;
            }

            // 找出第一个中文字符位置
            int splitPos = 0;
            while (splitPos < input.Length && !chineseRegex.IsMatch(input[splitPos].ToString()))
            {
                splitPos++;
            }

            // 如果没有中文则直接返回
            if (splitPos >= input.Length)
            {
                return input;
            }

            // 分离非中文和中文部分
            string nonChinese = input.Substring(0, splitPos).TrimEnd('-', '_');
            string chinese = input.Substring(splitPos);

            // 组合最终结果
            return $"{nonChinese}, {chinese}";
        }
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

            // 分离BZ编号和RoHS信息
            var (bzNumber, rohsInfo) = SplitBzAndRohs(fullBzPart);

            // 从原parts中移除BZ部分
            parts.Remove(fullBzPart);

            // 插入RoHS信息到原位置
            if (!string.IsNullOrEmpty(rohsInfo))
            {
                // 找到插入位置（原BZ部分在输入字符串中的位置）
                int bzIndex = input.IndexOf(fullBzPart);
                int insertPos = parts.FindIndex(p => input.IndexOf(p) > bzIndex);

                if (insertPos >= 0)
                    parts.Insert(insertPos, rohsInfo);
                else
                    parts.Add(rohsInfo);
            }

            return (bzNumber, string.Join(",", parts));
        }

        private static (string bzNumber, string rohsInfo) SplitBzAndRohs(string fullBzPart)
        {
            // 匹配模式：BZ编号 + [RoHS]信息
            // 修复点：支持全角括号［］
            var match = Regex.Match(fullBzPart,
                @"^(BZX?-[A-Z0-9]+(?:[- ][A-Z0-9]+)*)\s*(.*)$",
                RegexOptions.IgnoreCase);

            // 匹配成功时
            if (match.Success)
            {
                string bzNumber = match.Groups[1].Value.Trim();
                string remaining = match.Groups[2].Value.Trim();

                // 检查剩余部分是否包含RoHS标记（支持全角括号）
                bool hasRohs = Regex.IsMatch(remaining, @"[\[［]符合RoHS[\]］]");

                return hasRohs
                    ? (bzNumber, remaining)
                    : (fullBzPart, "");
            }

            // 未匹配时返回原始内容
            return (fullBzPart, "");
        }

    }
}
