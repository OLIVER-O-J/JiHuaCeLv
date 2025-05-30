using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace regulartest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teststring = "17.5*11.5*12，BZ-65DP19-1727BE 03(中间珍珠棉),RoHS\r\n";
            Console.WriteLine("BZ部分是：" + regular.ProcessBZString(teststring).bzPart);
            Console.WriteLine("剩余部分是：" + regular.ProcessBZString(teststring).remainingPart+"\n");



            // 测试其他字符串
            var test2string = "KRCU20E-8BT(支持双OOK),TR28520112AH,703-803调角2-16,885-960调角2-16,1710-1830调角2-12,1885-2025调角2-12,2515-2675调角2-12,GY00695 [符合ROHS]";
            Console.WriteLine("KRCU部分是：" + regular.ProcessKRCUString(test2string).ExtractedPart);
            Console.WriteLine("剩余部分是：" + regular.ProcessKRCUString(test2string).ModifiedString+"\n");


            // 测试其他字符串
            var test3string = "KB034 内置电机KRCU20E-2BT";
            Console.WriteLine("KRCU部分是：" + regular.ParseCodeDescriptionModel(test3string).Value.Model);
            Console.WriteLine("剩余部分是：" + regular.ParseCodeDescriptionModel(test3string).Value.Code+ regular.ParseCodeDescriptionModel(test3string).Value.Description + "\n");
        }
    }
}
