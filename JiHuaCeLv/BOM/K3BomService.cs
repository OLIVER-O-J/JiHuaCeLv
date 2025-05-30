using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuaCeLv.BOM
{
    internal class K3BomService
    {
        /// <summary>
        /// 仅分割 BOM，未判重的
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static List<K3Bom> ReadK3Bom(string file)
        {
            var list = MiniExcel.Query<K3BomLine>(file).ToList();
            var boms = new List<K3Bom>();
            do
            {
                //1 分割BOM 2 判重 3 删除已用list
                var currLine = list.First();
                var bom = new K3Bom(currLine.Itemcode);
                int i;
                for (i = 1; i < list.Count; i++)
                {
                    var item = list[i];
                    if (currLine.Itemcode != item.Itemcode || bom.LineNumbers.Contains(item.LineNumber))
                    {
                        break;
                    }
                    else
                    {
                        bom.AddSubBom(item);
                    }
                }
                boms.Add(bom);
                list.RemoveRange(0, i);
            } while (list.Count > 0);
            return boms;
        }
        public static List<K3Bom> ReadDictinctBOms(string file, IProgress<(int max, int lastest)> jdt)
        {
            var src = ReadK3Bom(file); //未判重
            var target = new List<K3Bom>(); //排重后的
            int max = src.Count;
            int i = 0;
            do
            {
                var bom = src[0].DeepClone();
                target.Add(bom);
                src.RemoveAll(it => it.EqualTo(bom));
                jdt.Report((max, i++));

            } while (src.Count > 0);
            return target;
        }
    }
}
