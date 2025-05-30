using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs;
using MiniExcelLibs.Attributes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace JiHuaCeLv.DangerousMaterical_s_BOM
{
    internal class SeparateBOMService
    {
        public class DangerousMaterical
        {
            [ExcelColumn(Name = "风险物料代码")]
            public string Dangerousmaterical { get; set; }
        }
        public class BomItem
        {
            [ExcelColumn(Name = "FMATERIALID")]
            public string FMATERIALID { get; set; }
            [ExcelColumn(Name = "FMATERIALID#Name")]
            public string FMATERIALID_Name { get; set; }
            public string FReplaceGroup { get; set; }
            [ExcelColumn(Name = "FReplaceGroup")]//子项序号
            public int Count { get; set; }
            // 其他BOM相关的属性可以在这里添加
            [ExcelColumn(Name = "FMATERIALIDCHILD")]
            public string FMATERIALIDCHILD { get; set; }
        }
        public static List<List<BomItem>> ClassifyBoms(List<BomItem> bomData)
        {
            List<List<BomItem>> classifiedBoms = new List<List<BomItem>>();
            List<BomItem> currentBom = new List<BomItem>();

            foreach (var item in bomData)
            {
                if (item.Count == 1 && currentBom.Count > 0)
                {
                    // 当遇到新的计数为1的项且当前BOM不为空时，将当前BOM添加到分类结果中，并重新开始一个新的BOM
                    classifiedBoms.Add(currentBom);
                    currentBom = new List<BomItem>();
                }
                currentBom.Add(item);
            }
            // 添加最后一个BOM
            if (currentBom.Count > 0)
            {
                classifiedBoms.Add(currentBom);
            }

            return classifiedBoms;
        }
        /// <summary>
        /// 返回一个已经分割好BOM的清单
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static List<List<BomItem>> Dist(string file)
        {
            return ClassifyBoms(MiniExcel.Query<BomItem>(file).ToList());
        }
        /// <summary>
        /// 扁平化
        /// </summary>
        /// <param name="nestedList"></param>
        /// <returns></returns>
        public static List<BomItem> Flattening(List<List<BomItem>> nestedList)
        {
            return nestedList.SelectMany(x => x).ToList();
        }
        public static List<DangerousMaterical> DangerousCode(string file)
        {
            var list = MiniExcel.Query<DangerousMaterical>(file, sheetName: "Sheet2").ToList();
            return list;
        }
    }


}
