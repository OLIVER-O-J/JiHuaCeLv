using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JiHuaCeLv.DangerousMaterical_s_BOM
{
    internal class LocalService
    {
        private HttpClient Client;
       
        
        public LocalService(string basAPI)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(basAPI);
        }

    }
}
