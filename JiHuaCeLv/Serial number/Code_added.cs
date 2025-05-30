using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs;

namespace JiHuaCeLv.Serial_number
{/// <summary>
/// 输入文件名，返回一个云星空与K3差异物料的编码的清单。
/// </summary>
    public class Code_added
    {
        public string file;
        public  Code_added(string file)
        {
            this.file = file;
        }
        public static List<ReadMaterical> Comparison_different(string file)
        {
            var goalist = MiniExcel.Query<KinSearchOldcode>(file, startCell: "A2").Select(a => a.Oldcode).ToList();
            var oldlist = MiniExcel.Query<K3SearchOldcode>(file).Select(i => i.Oldcode).ToList();
            var different_list = oldlist.Except(goalist);
            return (List<ReadMaterical>)different_list;
        }
       
    }
}
