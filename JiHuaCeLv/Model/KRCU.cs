using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;
using regulartest;

namespace JiHuaCeLv.Model
{
    internal class KRCU
    {
        [ExcelColumn(Name = "(物料)编码")]
        public string Code { get; set; }
        [ExcelColumn(Name = "*(物料)名称#中文(简体)")]
        public string name { get; set; }

        public string DrawingNO
        {
            get
            {
                if (name.Contains("KRCU"))
                {
                    return regular.ExtractAndFormatKrcu(name).formattedString;
                }
                else if (regular.ExtractKrcu(Spec).extractedPart.Length==0)
                {
                    return name;
                }
                else
                {
                    return regular.ProcessString(regular.ExtractKrcu(Spec).extractedPart) + "," + name;
                }
            }
        }

        [ExcelColumn(Name = "(物料)规格型号#中文(简体)")]
        public string Spec { get; set; }
        [ExcelColumn(Name = "型号")]
        public string Description { get { return regular.ExtractKrcu(Spec).remainingString; } }
    }
}
