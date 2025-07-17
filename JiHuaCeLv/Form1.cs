using JiHuaCeLv.FaliaoWays;
using JiHuaCeLv.fugaiyinru;
using JiHuaCeLv.BOM;
using JiHuaCeLv.TFweiwai;
using JiHuaCeLv.WareRules;
using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mapster;
using System.IO;
using JiHuaCeLv.Serial_number;
using JiHuaCeLv._1._99;
using JiHuaCeLv.ExceptFuxiang;
using JiHuaCeLv.Find_Not_introduced;
using JiHuaCeLv.Finished_Product_Add_StandardworkTime;
using JiHuaCeLv.Compare_man_hours;
using JiHuaCeLv.DangerousMaterical_s_BOM;
using static JiHuaCeLv.DangerousMaterical_s_BOM.SeparateBOMService;
using System.Net.Http;
using Newtonsoft.Json;
using JiHuaCeLv.DWG_exchange_PDF;
using JiHuaCeLv.Model;
using JiHuaCeLv.Service;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Asn1.X500;
using regulartest;


namespace JiHuaCeLv
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        IProgress<(int max, int lastest)> progress;
        IProgress<int> progress1;
        public void Form1_Load(object sender, EventArgs e)
        {
            progress1 = new Progress<int>(value =>
            {
                jdt.Value = value; // 更新进度条的值  
            });
            progress = new Progress<(int max, int lastest)>(value =>
            {
                // 在 UI 线程更新进度条  
                jdt.Maximum = value.max;
                jdt.Value = value.lastest;
                wenzi.Text = value.ToString();
            });
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开新代码文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var goalist = MiniExcel.Query<BaseInformation>(ofd.FileName).ToList();
                var standardlist = MiniExcel.Query<gongshi1>("工时明细表.xlsx").ToList();
                var warelist = MiniExcel.Query<WareSearch>("委外入库.xlsx", startCell: "A3").ToList();
                var weiwailist = MiniExcel.Query<weiwaiDingdan>("工作簿1.xlsx").ToList();
                var chejianlist = MiniExcel.Query<ChejianCang>("车间仓.xlsx").ToList();
                wenzi.Text = "已读入数据，行数为" + goalist.Count + "条";
                jdt.Maximum = goalist.Count;
                int i = 0;
                await Task.Run(() =>
                {
                    foreach (var goal in goalist)
                    {
                        if (goal.Type == "栋")
                        {
                            goal.Type = "dong";
                        }
                        if (goal.Type == "千克")
                        {
                            goal.Type = "kg";
                        }
                        if (goal.Type == "升")
                        {
                            goal.Type = "L";
                        }
                        if (goal.Type == "辆")
                        {
                            goal.Type = "liang";
                        }
                        if (goal.Type == "米")
                        {
                            goal.Type = "m";
                        }
                        if (goal.Type == "秒")
                        {
                            goal.Type = "second";
                        }
                        if (goal.Type == "台")
                        {
                            goal.Type = "tai";
                        }
                        //var zhonglei = goal.Newcode.Substring(0, 4);
                        //加工时
                        var standard = standardlist.FirstOrDefault(it => it.MaterCode == goal.OldCode);

                        if (standard != null)
                        {
                            goal.StandardTime = standard.CostTime;
                            //goal.ZhongleiCode = zhonglei;
                        }//加完
                        //var ware = warelist.FirstOrDefault( os =>os .ZhongleiCode == goal.ZhongleiCode);
                        foreach (var ware in warelist)
                        {
                            //Console.WriteLine(ware.ZhongleiCode +" - "+ goal.ZhongleiCode);
                            if (ware.ZhongleiCode.Trim() == goal.ZhongleiCode.Trim())
                            {
                                goal.IsPihao = ware.IsPihao;
                                goal.PihaoRule = ware.PihaoRule;
                                goal.IsProtect = ware.IsProtect;
                                goal.Birthday = ware.Birthday;
                                goal.ProtectYear = ware.ProtectYear;
                                goal.SerialNumber = ware.SerialNumber;
                                goal.InventoryCategory = ware.InventoryCategory;
                                goal.MatericalCategory = ware.MatericalCategory;
                                goal.WareHouse = ware.WareHouse;
                                goal.OverissueMax = ware.OverissueMax;
                                goal.OverissueMin = ware.OverissueMin;
                                goal.ReceivingMax = ware.ReceivingMax;
                                goal.ReceivingMin = ware.ReceivingMin;
                                //goal.MatericalCome = ware.MatericalCome;
                                //goal.ProductCheck = ware.ProductCheck;
                                //goal.WareSave = ware.WareSave;
                                goal.RukuChaoshou = ware.RukuChaoshou;
                                goal.RukuQianshou = ware.RukuQianshou;
                                goal.BOMson = ware.BOMson;
                                goal.FAliaoWays = ware.FAliaoWays;
                                goal.OverissueContronl = ware.OverissueContronl;
                                goal.IsKey = ware.IsKey;
                                goal.ShengchanChejian = ware.ShengchanChejian;
                                goal.FUliaoPandian = ware.FUliaoPandian;
                                goal.Creatlv = ware.Creatlv;
                            }
                            if (goal.Unit.Contains("自制") || goal.Unit.Contains("委外加工"))
                            {
                                goal.Planlv = "MPS";
                            }
                            else
                            {
                                goal.Planlv = "MRP";
                            }
                            foreach (var weiwai in weiwailist)
                            {
                                if (goal.OldCode == weiwai.materialCode)
                                {
                                    goal.Unit = "委外";
                                }
                            }
                        }
                        foreach (var chejian in chejianlist)
                        {
                            if (chejian.MaterCode == goal.OldCode)
                            {
                                goal.FAliaoWays = "调拨倒冲";
                            }
                        }
                        progress1.Report(i++);
                    }
                });
                MiniExcel.SaveAs(ofd.FileName, goalist, overwriteFile: true);
                wenzi.Text = "搞定！！！";
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog wenjian = new OpenFileDialog()
            {
                Title = "打开新代码文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (wenjian.ShowDialog() == DialogResult.OK)
            {
                var goalist = MiniExcel.Query<yinrumold>(wenjian.FileName).ToList();
                var standardlist = MiniExcel.Query<gongshi1>("工时明细表.xlsx").ToList();
                var warelist = MiniExcel.Query<WareSearch>("批号管理规则.xlsx", startCell: "A4").ToList();
                var weiwailist = MiniExcel.Query<weiwaiDingdan>("真委外订单.xlsx").ToList();
                var chejianlist = MiniExcel.Query<ChejianCang>("车间仓.xlsx").ToList();
                wenzi.Text = "已读入数据，行数为" + goalist.Count + "条";
                jdt.Maximum = goalist.Count;
                await Task.Run(() =>
                {
                    int i = 0;
                    foreach (var goal in goalist)
                    {

                        if (goal.Type == "千克")
                        {
                            goal.Type = "kg";
                        }
                        if (goal.Type == "升")
                        {
                            goal.Type = "L";
                        }
                        if (goal.Type == "米")
                        {
                            goal.Type = "m";
                        }
                        if (goal.Type == "秒")
                        {
                            goal.Type = "second";
                        }
                        if (goal.Type == "立方米")
                        {
                            goal.Type = "m³";
                        }
                        if (goal.Type == "平方米")
                        {
                            goal.Type = "m²";
                        }
                        if (goal.Unit == "虚拟件")
                        {
                            goal.Unit = "虚拟";
                        }
                        //改单位
                        //var zhonglei = goal.Newcode.Substring(0, 4);
                        //加工时
                        var standard = standardlist.FirstOrDefault(it => it.MaterCode == goal.OldCode);
                        //goal.ZhongleiCode = zhonglei;
                        //}//加完
                        //var ware = warelist.FirstOrDefault( os =>os .ZhongleiCode == goal.ZhongleiCode);
                        foreach (var ware in warelist)
                        {
                            //Console.WriteLine(ware.ZhongleiCode +" - "+ goal.Zhongleicode);
                            if (ware.ZhongleiCode.Trim() == goal.Zhongleicode.Trim())
                            {
                                goal.Categotty = ware.InventoryCategory;
                                goal.Warenumber = ware.WareHouse;
                                goal.Ispihao = ware.IsPihao;
                                goal.Pihaorule = ware.PihaoRule;
                                goal.Isbaozhiqi = ware.IsProtect;
                                goal.Baozhiqi = ware.ProtectYear;
                                goal.Planlv = ware.Planlv;
                                goal.Cratelv = ware.Creatlv;
                                goal.Shengchanchejian = ware.ShengchanChejian;
                                goal.Overissuecontro = ware.OverissueContronl;
                                goal.Baozhiqi = ware.ProtectYear;
                                //goal.OldCode = goal.OldCode.Trim();.
                                goal.FaliaoWays = ware.FAliaoWays;
                                //goal.Baozhiqitype = "年";
                                goal.Specdingdan = "False";
                                goal.Updateshenchan = "False";
                                goal.Yangpinrenz = "False";
                                goal.Baozhiqitype = ware.Birthday;
                                //按批号规则Lookup对应中类信息
                            }
                            foreach (var weiwai in weiwailist)
                            {
                                if (goal.OldCode == weiwai.materialCode)
                                {
                                    goal.Unit = "委外";
                                }
                            }
                            if (goal.Unit.Contains("自制加工"))
                            {
                                goal.Unit = "自制";
                            }
                            if (goal.Unit == "委外加工")
                            {
                                goal.Unit = "委外";
                            }
                            if (goal.Unit.Contains("自制") || goal.Unit.Contains("委外加工") || goal.Unit.Contains("委外"))
                            {
                                goal.Planlv = "MPS";
                            }
                            else
                            {
                                goal.Planlv = "MRP";
                            }
                        }
                        foreach (var chejian in chejianlist)
                        {
                            if (chejian.MaterCode == goal.OldCode)
                            {
                                goal.FaliaoWays = "调拨倒冲";
                            }
                        }
                        if (standard != null)
                        {
                            goal.StandardTime = standard.CostTime;
                        }
                        //改物料属性
                        progress1.Report(i++);
                    }
                });
                MiniExcel.SaveAs(wenjian.FileName, goalist, sheetName: "物料#物料(FBillHead)", overwriteFile: true);
                wenzi.Text = "搞定！！！";
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var goalist = MiniExcel.Query<floorinformation>(ofd.FileName).ToList();
                var matchlist = MiniExcel.Query<cangweicode>("").ToList();
                jdt.Maximum = goalist.Count;
                wenzi.Text = "已读入数据，行数为" + goalist.Count + "条";
                await Task.Run(() =>
                {
                    int i = 0;
                    foreach (var goal in goalist)
                    {
                        foreach (var match in matchlist)
                        {
                            if (goal.OldCode == match.matericalcode)
                            {
                                goal.cangweicode = match.cangcode;
                            }
                            i++;
                        }
                        progress1.Report(i);
                    }
                });
                MiniExcel.SaveAs(ofd.FileName, goalist, overwriteFile: true);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<Fill_Head> goalist = new List<Fill_Head>();
                await Task.Run(() =>
                {
                    goalist = MiniExcel.Query<Fill_Head>(ofd.FileName).ToList();
                });
                jdt.Maximum = goalist.Count;
                wenzi.Text = "已读入数据。行数为" + goalist.Count + "条";
                int i = 0;
                int j = 2;
                string pid = goalist.First().FMATERIALID;
                await Task.Run(() =>
                {
                    foreach (var line in goalist)
                    {
                        line.FBillHead = j;
                        line.FTreeEntity = ++i;

                        if (line.FMATERIALID != pid)
                        {
                            j++;
                            pid = line.FMATERIALID;

                        }
                        else if (line.FCHILDUNITID.Contains("升"))
                        {
                            line.FCHILDUNITID = "L";
                        }
                        progress1.Report(i);
                    }

                });
                var target = goalist.Adapt<List<FillHead_Output>>();
                var path = Path.GetFileName("Target.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, target, sheetName: "物料清单#单据头(FBillHead)", overwriteFile: true);
                wenzi.Text = "GOOD！！！";
            }
        }
        private async void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                Multiselect = true,
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<List<BomItem>> bomlist = new List<List<BomItem>>();
                await Task.Run(() =>
                {
                    bomlist = SeparateBOMService.Dist(ofd.FileName).ToList();
                    UpdateStatus($"已读入数据，共 {bomlist.Count} 个BOM");
                    UpdateUI(bomlist.Count);
                });
                var dangerouscodelist = SeparateBOMService.DangerousCode(ofd.FileName);
                List<List<BomItem>> dangerousboms = new List<List<BomItem>>();
                await Task.Run(() =>
                {
                    int i = 0;
                    bool isSafe = true; // 标记当前 BOM 是否安全  
                    foreach (var bom in bomlist)//遍历每一个BOM
                    {
                        foreach (var fmaterical in bom)//遍历每个BOM的子项
                        {
                            foreach (var dangerouscode in dangerouscodelist)//遍历所有风险物料代码
                            {
                                if (fmaterical.FMATERIALIDCHILD == dangerouscode.Dangerousmaterical)
                                {
                                    isSafe = false; // 如果找到风险物料，则标记为不安全  
                                    dangerousboms.Add(bom); // 将该 BOM 加入要移除列表  
                                }
                            }
                            if (!isSafe) { } // 如果已经标记为不安全，则退出循环  
                        }
                        i++;
                        progress1.Report(i);
                    }
                });
                string Name = "已找出风险BOM";
                OliverSaveAs(Name, SeparateBOMService.Flattening(bomlist));
                wenzi.Text = "GOOD!!!!";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                var goalist = MiniExcel.Query<K3SearchOldcode>(ofd.FileName).ToList();//K3所有物料
                var list = Code_added.Comparison_different(ofd.FileName);//未引入的物料旧代码

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var goalist = MiniExcel.Query<_1_99>(ofd.FileName).ToList();
                wenzi.Text = "已读入数据，有" + goalist.Count + "条";
                var target = goalist.Adapt<List<_1_99_Output>>();

                int i = 0;
                foreach (var item in target)
                {
                    i++;
                    item.Newcode = "1.99." + i.ToString().PadLeft(6, '0');

                }

                var path = Path.GetFileName("1.99target.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, target, sheetName: "物料#物料(FBillHead)", overwriteFile: true);
                button2_Click(sender, e);
                wenzi.Text = "good！";
            }
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<BOM_Info_Search> goalists = new List<BOM_Info_Search>();
                List<Add_Fuxiang_Code> matchlists = new List<Add_Fuxiang_Code>();
                await Task.Run(() =>
                {
                    var sheetnames = MiniExcel.GetSheetNames(ofd.FileName);
                    foreach (var sheetname in sheetnames)
                    {
                        goalists = MiniExcel.Query<BOM_Info_Search>(ofd.FileName, sheetName: "物料清单#单据头(FBillHead)").ToList();
                        matchlists = MiniExcel.Query<Add_Fuxiang_Code>(ofd.FileName, sheetName: "Sheet1").ToList();
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                // 更新 UI 控件，例如 Label  
                                wenzi.Text = "已读入数据，行数为" + goalists.Count + "条";
                                jdt.Maximum = goalists.Count;
                            }));
                        }
                        else
                        {
                            wenzi.Text = "已读入数据，行数为" + goalists.Count + "条";
                            jdt.Maximum = goalists.Count;
                        }
                        int i = 0;
                        foreach (var goal in goalists)
                        {
                            i++;
                            foreach (var match in matchlists)
                            {
                                if (IsThesame(goal.FMATERIALID, match.Code))
                                {
                                    goal.Spilt = "已引入";
                                }
                                else
                                {
                                    goal.Spilt = "未引入";
                                }
                            }
                            progress1.Report(i);
                        }
                    }
                });
                var path = Path.GetFileName("比对结果.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, goalists, sheetName: "物料清单#单据头(FBillHead)", overwriteFile: true);
                wenzi.Text = "good！";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var goalist = MiniExcel.Query<Get_Excel_All_Columns>(ofd.FileName).ToList();
                var standardtimelist = MiniExcel.Query<Finished_Product>("工时表.xlsx").ToList();
                var UVstandardtimelist = MiniExcel.Query<UV_Product_Standatdtime>("UV产品工时表.xlsx").ToList();
                wenzi.Text = "已读入数据，共" + goalist.Count + "条";
                jdt.Maximum = goalist.Count;
                int i = 0;
                foreach (var goal in goalist)
                {
                    i++;
                    foreach (var standardtime in standardtimelist)
                    {
                        if (goal.Substring8 == standardtime.Oldcode)
                        {
                            goal.Standardtime = standardtime.Standardtime;
                        }
                    }
                    foreach (var standatdtime in UVstandardtimelist)
                    {
                        if (goal.Substring8 == standatdtime.Oldcode)
                        {
                            goal.Standardtime = standatdtime.Standardtime;
                        }
                    }
                    progress1.Report(i);
                }

                var path = Path.GetFileName("已添加工时(需要VLOOKUP一下).xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, goalist, overwriteFile: true);
                wenzi.Text = "good!";
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                Multiselect = true,
                RestoreDirectory = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var goalist = MiniExcel.Query<Compare>(ofd.FileName, sheetName: "").ToList();
                var standardlist = MiniExcel.Query<standlardlist>("已添加工时.xlsx").ToList();
                jdt.Maximum = goalist.Count;
                int j = 0;
                foreach (var goal in goalist)
                {
                    foreach (var standard in standardlist)
                    {
                        if (goal.Oldcode == standard.Oldcode)
                        {
                            goal.Standardtime = standard.Standardtime;
                        }
                    }
                    progress1.Report(j++);
                }
                var path = Path.GetFileName("完成比对.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, goalist, overwriteFile: true);
                OliverSaveAs(path, goalist);
                wenzi.Text = "good!";
            }
        }
        private async void button6_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.16.4.24:5566/api/");//给API地址访问
            var resp = await client.GetAsync("k3Cloud/getProductInfo?Itemcode=1&ProductName=KB65D07081724A12-151516D16D-I&IgnorePurchaseProduct=true");
            if (resp.IsSuccessStatusCode)
            {
                using (Stream s = await resp.Content.ReadAsStreamAsync())
                {
                    StreamReader reader = new StreamReader(s, Encoding.UTF8);
                    var text = reader.ReadToEnd();
                    var rep = JsonConvert.DeserializeObject<GetBOMInfo.BomInfo>(text);
                }
            }
        }
        /// <summary>
        /// 保存:输入存档的名字 和你要存的目标清单
        /// </summary>
        /// <param name="pathname"></param>
        /// <param name="list"></param>
        private static void OliverSaveAs<t>(string pathname, IEnumerable<t> list) where t : class
        {
            var path = Path.GetFileName($"{pathname}");
            var dir = Path.GetDirectoryName(pathname);
            path = Path.Combine(dir, pathname);
            MiniExcel.SaveAs(path, list, overwriteFile: true);
        }
        private bool IsThesame(string A, string B)
        {
            if (A == B)
            {
                return true;
            }
            return false;
        }
        private void UpdateStatus(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => wenzi.Text = message));
            }
            else
            {
                wenzi.Text = message;
            }
        }
        // 更新 UI 的方法  
        private void UpdateUI(int bomCount)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    wenzi.Text = "已读入数据，共 " + bomCount + " 个BOM";
                    jdt.Maximum = bomCount; // 更新进度条最大值  
                }));
            }
            else
            {
                wenzi.Text = "已读入数据，共 " + bomCount + " 个BOM";
                jdt.Maximum = bomCount; // 更新进度条最大值  
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var list = MiniExcel.Query<SpecSub.MyClass>(openFileDialog.FileName/* startCell: "A2"*/).ToList();
                var path = "提前完成.xlsx";
                var dir = Path.GetDirectoryName(openFileDialog.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, list, overwriteFile: true);
                wenzi.Text = "good!";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "DWG文件(*.DWG)|*.DWG|全部文件(*.*)|*.*",
                RestoreDirectory = true,
                Multiselect = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                CAD_method cad = new CAD_method();
                foreach (var dwgFilePath in ofd.FileNames)
                {
                    // 根据 DWG 文件路径生成 PDF 文件路径  
                    var pdfFilePath = Path.ChangeExtension(dwgFilePath, cad.pdfExtensions);

                    // 调用转换方法  
                    cad.ConverDwgToPdf(dwgFilePath, pdfFilePath);
                }
                MessageBox.Show("转换完成");
                wenzi.Text = "已完成";

            }

        }

        private void 提取型号_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var list = MiniExcel.Query<Work_on_the_name>(openFileDialog.FileName, startCell: "A2", sheetName: "物料#物料(FBillHead)").ToList();

                var path = "7包材（已改）.xlsx";
                var dir = Path.GetDirectoryName(openFileDialog.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, list, overwriteFile: true);
                wenzi.Text = "good!";
            }
        }

        private void 按钮_Click(object sender, EventArgs e)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int i = 0;
            i++;
            wenzi.Text = i.ToString();
            dictionary.Add(i, i);
        }

        private void 抓出型号_Click(object sender, EventArgs e)
        {
            FileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var list = MiniExcel.Query<RegularExpression.SubSpec>(ofd.FileName).ToList();

                var path = "7包材（已改）.xlsx";
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, list, overwriteFile: true);
                wenzi.Text = "good!";
            }
        }

        private void 按规范技术文件编辑物料名称_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var goalist = MiniExcel.Query<Work_on_the_name>(ofd.FileName, sheetName: "物料#物料(FBillHead)", startCell: "A2").ToList();
                jdt.Maximum = goalist.Count;
                int i = 0;
                foreach (var goal in goalist)
                {
                    if (!string.IsNullOrEmpty(goal.drawingno))
                    {
                        goal.Name = goal.drawingno + "," + goal.Name;
                    }
                    progress1.Report(i++);
                }
                var path = Path.GetFileName("已编辑物料名称.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, goalist, overwriteFile: true);
                wenzi.Text = "good!";
            }
        }

        private void 提取图号_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var goalist = MiniExcel.Query<Name>(ofd.FileName).ToList();
                var path = Path.GetFileName("图号.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, goalist, overwriteFile: true);
                wenzi.Text = "good!";

            }
        }

        private void 对中类物料的名称进行提取_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string name = "5组件（已改）";
                var goalist = MiniExcel.Query<Name>(ofd.FileName, sheetName: "物料#物料(FBillHead)", startCell: "A2").ToList();
                var motorlist = goalist.Where(i => i.name?.Contains("电机") == true).ToList();
                foreach (var motor in motorlist)
                {

                }

                var path = Path.GetFileName($"{name}.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, goalist, overwriteFile: true);
                wenzi.Text = "good!";
            }
        }

        private void 对7组件物料修改名称_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string name = "电机（已改）";
                var goalist = MiniExcel.Query<KRCU>(ofd.FileName, sheetName: "Sheet1", startCell: "A2").ToList();
                var path = Path.GetFileName($"{name}.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, goalist, overwriteFile: true);
                wenzi.Text = "good!";
            }
        }

        private void 对7的规格型号进行正则提取_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var list = MiniExcel.Query<GetSpec>(openFileDialog.FileName, startCell: "A2").ToList();
                var path = "7包材（规格）.xlsx";
                var dir = Path.GetDirectoryName(openFileDialog.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, list, overwriteFile: true);
                wenzi.Text = "good!";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd =new OpenFileDialog()
            {
                Title = "打开文件",
                Filter = "Excel文件(*.xlsx)|*.xlsx|全部文件(*.*)|*.*",
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                var goalist =MiniExcel.Query<Name>(ofd.FileName, sheetName: "物料#物料(FBillHead)", startCell: "A2").ToList();
                var path = Path.GetFileName("物料名称.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path);
                MiniExcel.SaveAs(path, goalist, overwriteFile:true);
                wenzi.Text = "good!已提取物料名称";
            }
        }
    }
}

