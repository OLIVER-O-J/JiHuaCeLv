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







        public static (string OriginalString, string ExtractedPart, string ModifiedString) ProcessKRCUString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return (input, string.Empty, input);
            }

            // 使用正则表达式按逗号分割字符串，同时处理中英文逗号
            var parts = Regex.Split(input, @"[，,]").Select(p => p.Trim()).ToList();

            // 查找以KRCU开头的部分
            var krcuIndex = parts.FindIndex(p => p.StartsWith("KRCU"));
            string krcuPart = krcuIndex >= 0 ? parts[krcuIndex] : string.Empty;

            // 提取KRCU部分中的括号内容并从KRCU部分删除
            string extractedBracketContent = string.Empty;
            string processedKrcuPart = krcuPart;
            if (!string.IsNullOrEmpty(krcuPart))
            {
                // 提取括号及其中的内容
                var bracketMatch = Regex.Match(krcuPart, @"\([^)]*\)");
                if (bracketMatch.Success)
                {
                    extractedBracketContent = bracketMatch.Value;
                    processedKrcuPart = krcuPart.Replace(extractedBracketContent, "").Trim();
                }
            }

            // 从原字符串中删除KRCU部分（处理后的）
            string modifiedString = input;
            if (krcuIndex >= 0)
            {
                // 找到原始字符串中KRCU部分的起始和结束位置
                int startIndex = 0;
                int currentPartIndex = 0;
                int krcuStart = 0;
                int krcuEnd = 0;

                foreach (var part in Regex.Split(input, @"[，,]"))
                {
                    if (currentPartIndex == krcuIndex)
                    {
                        krcuStart = startIndex;
                        krcuEnd = startIndex + part.Length;
                        break;
                    }
                    startIndex += part.Length + 1; // +1 是逗号的长度
                    currentPartIndex++;
                }

                // 删除KRCU部分，包括可能的前导或尾随逗号
                if (krcuStart > 0 && input[krcuStart - 1] == ',')
                {
                    krcuStart--; // 包含前导逗号
                }
                else if (krcuEnd < input.Length && input[krcuEnd] == ',')
                {
                    krcuEnd++; // 包含尾随逗号
                }

                modifiedString = input.Remove(krcuStart, krcuEnd - krcuStart);

                // 处理可能出现的连续逗号
                modifiedString = Regex.Replace(modifiedString, @",+", ",");
                modifiedString = modifiedString.Trim(',');
            }

            // 将提取的括号内容插入到KRCU原来的位置
            if (!string.IsNullOrEmpty(extractedBracketContent) && krcuIndex >= 0)
            {
                // 计算插入位置（考虑删除操作后的偏移）
                int insertIndex = CalculateInsertIndex(input, krcuIndex);

                // 如果原字符串不是空的，确保插入位置正确
                if (insertIndex >= 0 && insertIndex <= modifiedString.Length)
                {
                    // 如果插入位置在字符串中间，确保前面有逗号
                    if (insertIndex > 0 && insertIndex < modifiedString.Length && modifiedString[insertIndex - 1] != ',')
                    {
                        modifiedString = modifiedString.Insert(insertIndex, "," + extractedBracketContent);
                    }
                    else
                    {
                        modifiedString = modifiedString.Insert(insertIndex, extractedBracketContent);
                    }

                    // 如果插入位置不在字符串末尾，确保后面有逗号
                    if (insertIndex < modifiedString.Length - 1 && modifiedString[insertIndex + extractedBracketContent.Length] != ',')
                    {
                        modifiedString = modifiedString.Insert(insertIndex + extractedBracketContent.Length, ",");
                    }
                }
            }

            return (input, processedKrcuPart, modifiedString);
        }

        private static int CalculateInsertIndex(string originalInput, int krcuIndex)
        {
            int insertIndex = 0;
            int currentPartIndex = 0;

            foreach (var part in Regex.Split(originalInput, @"[，,]"))
            {
                if (currentPartIndex == krcuIndex)
                {
                    break;
                }
                insertIndex += part.Length + 1; // +1 是逗号的长度
                currentPartIndex++;
            }

            // 调整插入位置，考虑删除KRCU部分后的偏移
            return Math.Max(0, insertIndex);
        }






        /// <summary>
        /// 解析类似 "KB034 内置电机KRCU20E-2BT" 格式的字符串，返回元组 (code, description, model)
        /// </summary>
        /// <param name="input">待解析字符串</param>
        /// <returns>包含Code、Description、Model的元组，否则返回null</returns>
        public static (string Code, string Description, string Model)? ParseCodeDescriptionModel(string input)
        {
            string pattern = @"^(?<code>[A-Za-z]+\d*)\s*(?<description>.+?)\s*(?<model>[A-Za-z0-9\-]+)$";

            var regex = new Regex(pattern);
            var match = regex.Match(input);

            if (match.Success)
            {
                return (
                    match.Groups["code"].Value,
                    match.Groups["description"].Value,
                    match.Groups["model"].Value
                );
            }
            else
            {
                return null; // 无法匹配
            }
        }
    }
}
