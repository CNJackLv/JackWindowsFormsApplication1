namespace WindowsFormsApplication1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Sqltoxml = new System.Windows.Forms.Button();
            this.Xmltosql = new System.Windows.Forms.Button();
            this.流式处理XML文档 = new System.Windows.Forms.Button();
            this.yield_demo = new System.Windows.Forms.Button();
            this.映射存储过程 = new System.Windows.Forms.Button();
            this.EntitySetDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 189);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Sqltoxml
            // 
            this.Sqltoxml.Location = new System.Drawing.Point(331, 127);
            this.Sqltoxml.Name = "Sqltoxml";
            this.Sqltoxml.Size = new System.Drawing.Size(75, 23);
            this.Sqltoxml.TabIndex = 3;
            this.Sqltoxml.Text = "Sql to xml";
            this.Sqltoxml.UseVisualStyleBackColor = true;
            this.Sqltoxml.Click += new System.EventHandler(this.button2_Click);
            // 
            // Xmltosql
            // 
            this.Xmltosql.Location = new System.Drawing.Point(331, 175);
            this.Xmltosql.Name = "Xmltosql";
            this.Xmltosql.Size = new System.Drawing.Size(75, 23);
            this.Xmltosql.TabIndex = 4;
            this.Xmltosql.Text = "Xml to sql";
            this.Xmltosql.UseVisualStyleBackColor = true;
            this.Xmltosql.Click += new System.EventHandler(this.Xmltosql_Click);
            // 
            // 流式处理XML文档
            // 
            this.流式处理XML文档.Location = new System.Drawing.Point(27, 225);
            this.流式处理XML文档.Name = "流式处理XML文档";
            this.流式处理XML文档.Size = new System.Drawing.Size(75, 23);
            this.流式处理XML文档.TabIndex = 5;
            this.流式处理XML文档.Text = "流式处理XML文档";
            this.流式处理XML文档.UseVisualStyleBackColor = true;
            this.流式处理XML文档.Click += new System.EventHandler(this.流式处理XML文档_Click);
            // 
            // yield_demo
            // 
            this.yield_demo.Location = new System.Drawing.Point(154, 225);
            this.yield_demo.Name = "yield_demo";
            this.yield_demo.Size = new System.Drawing.Size(75, 23);
            this.yield_demo.TabIndex = 6;
            this.yield_demo.Text = "yield_demo";
            this.yield_demo.UseVisualStyleBackColor = true;
            this.yield_demo.Click += new System.EventHandler(this.yield_demo_Click);
            // 
            // 映射存储过程
            // 
            this.映射存储过程.Location = new System.Drawing.Point(27, 271);
            this.映射存储过程.Name = "映射存储过程";
            this.映射存储过程.Size = new System.Drawing.Size(75, 23);
            this.映射存储过程.TabIndex = 7;
            this.映射存储过程.Text = "映射存储过程";
            this.映射存储过程.UseVisualStyleBackColor = true;
            this.映射存储过程.Click += new System.EventHandler(this.映射存储过程_Click);
            // 
            // EntitySetDemo
            // 
            this.EntitySetDemo.Location = new System.Drawing.Point(27, 316);
            this.EntitySetDemo.Name = "EntitySetDemo";
            this.EntitySetDemo.Size = new System.Drawing.Size(75, 23);
            this.EntitySetDemo.TabIndex = 8;
            this.EntitySetDemo.Text = "EntitySetDemo";
            this.EntitySetDemo.UseVisualStyleBackColor = true;
            this.EntitySetDemo.Click += new System.EventHandler(this.EntitySetDemo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 485);
            this.Controls.Add(this.EntitySetDemo);
            this.Controls.Add(this.映射存储过程);
            this.Controls.Add(this.yield_demo);
            this.Controls.Add(this.流式处理XML文档);
            this.Controls.Add(this.Xmltosql);
            this.Controls.Add(this.Sqltoxml);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Sqltoxml;
        private System.Windows.Forms.Button Xmltosql;
        private System.Windows.Forms.Button 流式处理XML文档;
        private System.Windows.Forms.Button yield_demo;
        private System.Windows.Forms.Button 映射存储过程;
        private System.Windows.Forms.Button EntitySetDemo;
    }
}

