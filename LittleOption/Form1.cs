using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniExcelLibs;

namespace LittleOption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                RestoreDirectory = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var goalist = MiniExcel.Query<option.Unit>(ofd.FileName).ToList();
                var path = Path.GetFileName("型号单.xlsx");
                var dir = Path.GetDirectoryName(ofd.FileName);
                path = Path.Combine(dir, path); 
                MiniExcel.SaveAs(path, goalist);
            }
        }
    }
}
