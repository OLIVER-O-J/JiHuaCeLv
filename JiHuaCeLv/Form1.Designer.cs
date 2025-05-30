namespace JiHuaCeLv
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Batch_number_management_rules = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.wenzi = new System.Windows.Forms.ToolStripStatusLabel();
            this.jdt = new System.Windows.Forms.ToolStripProgressBar();
            this.Introduce_templates = new System.Windows.Forms.Button();
            this.Add_a_position_code = new System.Windows.Forms.Button();
            this.BOM_Introduce_templates = new System.Windows.Forms.Button();
            this.BOM_exclude_repeat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.提取型号 = new System.Windows.Forms.Button();
            this.按钮 = new System.Windows.Forms.Button();
            this.抓出型号 = new System.Windows.Forms.Button();
            this.按规范技术文件编辑物料名称 = new System.Windows.Forms.Button();
            this.提取图号 = new System.Windows.Forms.Button();
            this.对中类物料的名称进行提取 = new System.Windows.Forms.Button();
            this.对7组件物料修改名称 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Batch_number_management_rules
            // 
            this.Batch_number_management_rules.Location = new System.Drawing.Point(17, 18);
            this.Batch_number_management_rules.Margin = new System.Windows.Forms.Padding(2);
            this.Batch_number_management_rules.Name = "Batch_number_management_rules";
            this.Batch_number_management_rules.Size = new System.Drawing.Size(94, 37);
            this.Batch_number_management_rules.TabIndex = 0;
            this.Batch_number_management_rules.Text = "按批号规则添加";
            this.Batch_number_management_rules.UseVisualStyleBackColor = true;
            this.Batch_number_management_rules.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wenzi,
            this.jdt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(995, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // wenzi
            // 
            this.wenzi.Name = "wenzi";
            this.wenzi.Size = new System.Drawing.Size(32, 17);
            this.wenzi.Text = "就绪";
            // 
            // jdt
            // 
            this.jdt.Name = "jdt";
            this.jdt.Size = new System.Drawing.Size(75, 16);
            // 
            // Introduce_templates
            // 
            this.Introduce_templates.Location = new System.Drawing.Point(17, 102);
            this.Introduce_templates.Margin = new System.Windows.Forms.Padding(2);
            this.Introduce_templates.Name = "Introduce_templates";
            this.Introduce_templates.Size = new System.Drawing.Size(94, 37);
            this.Introduce_templates.TabIndex = 2;
            this.Introduce_templates.Text = "按引入模板添加";
            this.Introduce_templates.UseVisualStyleBackColor = true;
            this.Introduce_templates.Click += new System.EventHandler(this.button2_Click);
            // 
            // Add_a_position_code
            // 
            this.Add_a_position_code.Location = new System.Drawing.Point(17, 188);
            this.Add_a_position_code.Margin = new System.Windows.Forms.Padding(2);
            this.Add_a_position_code.Name = "Add_a_position_code";
            this.Add_a_position_code.Size = new System.Drawing.Size(94, 37);
            this.Add_a_position_code.TabIndex = 3;
            this.Add_a_position_code.Text = "添加仓位码";
            this.Add_a_position_code.UseVisualStyleBackColor = true;
            this.Add_a_position_code.Click += new System.EventHandler(this.button3_Click);
            // 
            // BOM_Introduce_templates
            // 
            this.BOM_Introduce_templates.Location = new System.Drawing.Point(17, 274);
            this.BOM_Introduce_templates.Margin = new System.Windows.Forms.Padding(2);
            this.BOM_Introduce_templates.Name = "BOM_Introduce_templates";
            this.BOM_Introduce_templates.Size = new System.Drawing.Size(94, 37);
            this.BOM_Introduce_templates.TabIndex = 4;
            this.BOM_Introduce_templates.Text = "按BOM引入模板添加";
            this.BOM_Introduce_templates.UseVisualStyleBackColor = true;
            this.BOM_Introduce_templates.Click += new System.EventHandler(this.button4_Click);
            // 
            // BOM_exclude_repeat
            // 
            this.BOM_exclude_repeat.Location = new System.Drawing.Point(178, 18);
            this.BOM_exclude_repeat.Margin = new System.Windows.Forms.Padding(2);
            this.BOM_exclude_repeat.Name = "BOM_exclude_repeat";
            this.BOM_exclude_repeat.Size = new System.Drawing.Size(94, 37);
            this.BOM_exclude_repeat.TabIndex = 5;
            this.BOM_exclude_repeat.Text = "找出风险BOM";
            this.BOM_exclude_repeat.UseVisualStyleBackColor = true;
            this.BOM_exclude_repeat.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 104);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "零件续上流水号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 274);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "\"1.99\"物料跑模板";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(178, 188);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 37);
            this.button3.TabIndex = 8;
            this.button3.Text = "找出新加父项编码\r\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(326, 18);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 37);
            this.button4.TabIndex = 9;
            this.button4.Text = "成品工时添加";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(326, 102);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 37);
            this.button5.TabIndex = 10;
            this.button5.Text = "工时比对添加";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(326, 188);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 37);
            this.button6.TabIndex = 11;
            this.button6.Text = "连接MAGIC";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(326, 274);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 37);
            this.button7.TabIndex = 12;
            this.button7.Text = "筛选除中文外字符";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(451, 18);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 37);
            this.button8.TabIndex = 13;
            this.button8.Text = "DWG转PDF";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // 提取型号
            // 
            this.提取型号.Location = new System.Drawing.Point(451, 102);
            this.提取型号.Margin = new System.Windows.Forms.Padding(2);
            this.提取型号.Name = "提取型号";
            this.提取型号.Size = new System.Drawing.Size(94, 37);
            this.提取型号.TabIndex = 14;
            this.提取型号.Text = "对7包材名称和型号修改";
            this.提取型号.UseVisualStyleBackColor = true;
            this.提取型号.Click += new System.EventHandler(this.提取型号_Click);
            // 
            // 按钮
            // 
            this.按钮.Location = new System.Drawing.Point(451, 188);
            this.按钮.Margin = new System.Windows.Forms.Padding(2);
            this.按钮.Name = "按钮";
            this.按钮.Size = new System.Drawing.Size(94, 37);
            this.按钮.TabIndex = 15;
            this.按钮.Text = "按钮";
            this.按钮.UseVisualStyleBackColor = true;
            this.按钮.Click += new System.EventHandler(this.按钮_Click);
            // 
            // 抓出型号
            // 
            this.抓出型号.Location = new System.Drawing.Point(451, 274);
            this.抓出型号.Margin = new System.Windows.Forms.Padding(2);
            this.抓出型号.Name = "抓出型号";
            this.抓出型号.Size = new System.Drawing.Size(94, 37);
            this.抓出型号.TabIndex = 16;
            this.抓出型号.Text = "抓出型号";
            this.抓出型号.UseVisualStyleBackColor = true;
            this.抓出型号.Click += new System.EventHandler(this.抓出型号_Click);
            // 
            // 按规范技术文件编辑物料名称
            // 
            this.按规范技术文件编辑物料名称.Location = new System.Drawing.Point(570, 18);
            this.按规范技术文件编辑物料名称.Margin = new System.Windows.Forms.Padding(2);
            this.按规范技术文件编辑物料名称.Name = "按规范技术文件编辑物料名称";
            this.按规范技术文件编辑物料名称.Size = new System.Drawing.Size(94, 37);
            this.按规范技术文件编辑物料名称.TabIndex = 17;
            this.按规范技术文件编辑物料名称.Text = "按规范技术文件编辑物料名称";
            this.按规范技术文件编辑物料名称.UseVisualStyleBackColor = true;
            this.按规范技术文件编辑物料名称.Click += new System.EventHandler(this.按规范技术文件编辑物料名称_Click);
            // 
            // 提取图号
            // 
            this.提取图号.Location = new System.Drawing.Point(570, 102);
            this.提取图号.Margin = new System.Windows.Forms.Padding(2);
            this.提取图号.Name = "提取图号";
            this.提取图号.Size = new System.Drawing.Size(94, 37);
            this.提取图号.TabIndex = 18;
            this.提取图号.Text = "提取图号";
            this.提取图号.UseVisualStyleBackColor = true;
            this.提取图号.Click += new System.EventHandler(this.提取图号_Click);
            // 
            // 对中类物料的名称进行提取
            // 
            this.对中类物料的名称进行提取.Location = new System.Drawing.Point(570, 188);
            this.对中类物料的名称进行提取.Margin = new System.Windows.Forms.Padding(2);
            this.对中类物料的名称进行提取.Name = "对中类物料的名称进行提取";
            this.对中类物料的名称进行提取.Size = new System.Drawing.Size(94, 37);
            this.对中类物料的名称进行提取.TabIndex = 19;
            this.对中类物料的名称进行提取.Text = "对5组件物料修改名称";
            this.对中类物料的名称进行提取.UseVisualStyleBackColor = true;
            this.对中类物料的名称进行提取.Click += new System.EventHandler(this.对中类物料的名称进行提取_Click);
            // 
            // 对7组件物料修改名称
            // 
            this.对7组件物料修改名称.Location = new System.Drawing.Point(570, 274);
            this.对7组件物料修改名称.Margin = new System.Windows.Forms.Padding(2);
            this.对7组件物料修改名称.Name = "对7组件物料修改名称";
            this.对7组件物料修改名称.Size = new System.Drawing.Size(94, 37);
            this.对7组件物料修改名称.TabIndex = 20;
            this.对7组件物料修改名称.UseVisualStyleBackColor = true;
            this.对7组件物料修改名称.Click += new System.EventHandler(this.对7组件物料修改名称_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 555);
            this.Controls.Add(this.对7组件物料修改名称);
            this.Controls.Add(this.对中类物料的名称进行提取);
            this.Controls.Add(this.提取图号);
            this.Controls.Add(this.按规范技术文件编辑物料名称);
            this.Controls.Add(this.抓出型号);
            this.Controls.Add(this.按钮);
            this.Controls.Add(this.提取型号);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BOM_exclude_repeat);
            this.Controls.Add(this.BOM_Introduce_templates);
            this.Controls.Add(this.Add_a_position_code);
            this.Controls.Add(this.Introduce_templates);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Batch_number_management_rules);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "OLIVER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Batch_number_management_rules;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar jdt;
        private System.Windows.Forms.Button Introduce_templates;
        private System.Windows.Forms.Button Add_a_position_code;
        private System.Windows.Forms.Button BOM_Introduce_templates;
        private System.Windows.Forms.Button BOM_exclude_repeat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.ToolStripStatusLabel wenzi;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button 提取型号;
        private System.Windows.Forms.Button 按钮;
        private System.Windows.Forms.Button 抓出型号;
        private System.Windows.Forms.Button 按规范技术文件编辑物料名称;
        private System.Windows.Forms.Button 提取图号;
        private System.Windows.Forms.Button 对中类物料的名称进行提取;
        private System.Windows.Forms.Button 对7组件物料修改名称;
    }
}

