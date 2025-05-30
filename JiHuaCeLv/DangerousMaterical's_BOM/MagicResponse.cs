using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiHuaCeLv.DangerousMaterical_s_BOM
{

    public class MagicResponse
    {
        public bool Success {  get; set; }
        public int Code {  get; set; }
        public string Message { get; set; }
        public string Data {  get; set; }
        public int Timestamp { get; set; }
    }

}
