namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.xlimit = new System.Windows.Forms.TextBox();
            this.ylimit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dVal = new System.Windows.Forms.TextBox();
            this.hVal = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label4 = new System.Windows.Forms.Label();
            this.u0 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.r0 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.TextBox();
            this.bl = new System.Windows.Forms.Label();
            this.b = new System.Windows.Forms.TextBox();
            this.ks1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ks2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kf = new System.Windows.Forms.TextBox();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.kf);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.ks2);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.ks1);
            this.tabPage1.Controls.Add(this.b);
            this.tabPage1.Controls.Add(this.bl);
            this.tabPage1.Controls.Add(this.a);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.r0);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.u0);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.hVal);
            this.tabPage1.Controls.Add(this.dVal);
            this.tabPage1.Controls.Add(this.ylimit);
            this.tabPage1.Controls.Add(this.xlimit);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1005, 649);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Модель";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(901, 584);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            legend4.Title = "График функции y=f(x)";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(28, 42);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(670, 565);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // xlimit
            // 
            this.xlimit.Location = new System.Drawing.Point(749, 153);
            this.xlimit.Name = "xlimit";
            this.xlimit.Size = new System.Drawing.Size(100, 20);
            this.xlimit.TabIndex = 11;
            this.xlimit.Text = "0,0";
            // 
            // ylimit
            // 
            this.ylimit.Location = new System.Drawing.Point(876, 153);
            this.ylimit.Name = "ylimit";
            this.ylimit.Size = new System.Drawing.Size(100, 20);
            this.ylimit.TabIndex = 12;
            this.ylimit.Text = "1500,0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(746, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Отрезок интегрирования (X,Y)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(749, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "D(толщина покрытия)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(749, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "h(шаг интегрирования)";
            // 
            // dVal
            // 
            this.dVal.Location = new System.Drawing.Point(876, 199);
            this.dVal.Name = "dVal";
            this.dVal.Size = new System.Drawing.Size(100, 20);
            this.dVal.TabIndex = 16;
            this.dVal.Text = "0,0";
            // 
            // hVal
            // 
            this.hVal.Location = new System.Drawing.Point(876, 228);
            this.hVal.Name = "hVal";
            this.hVal.Size = new System.Drawing.Size(100, 20);
            this.hVal.TabIndex = 17;
            this.hVal.Text = "0,1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1005, 649);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Описание";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(920, 125);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.rgn;
            this.pictureBox1.Location = new System.Drawing.Point(6, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 78);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.rgn2;
            this.pictureBox2.Location = new System.Drawing.Point(3, 233);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 92);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1013, 675);
            this.tabControl1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(749, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Напряжение";
            // 
            // u0
            // 
            this.u0.Location = new System.Drawing.Point(876, 256);
            this.u0.Name = "u0";
            this.u0.Size = new System.Drawing.Size(100, 20);
            this.u0.TabIndex = 19;
            this.u0.Text = "300";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(724, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Начальное сопротивление";
            // 
            // r0
            // 
            this.r0.Location = new System.Drawing.Point(876, 281);
            this.r0.Name = "r0";
            this.r0.Size = new System.Drawing.Size(100, 20);
            this.r0.TabIndex = 21;
            this.r0.Text = "0,1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(724, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "a";
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(876, 316);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(100, 20);
            this.a.TabIndex = 23;
            this.a.Text = "2,25e-8";
            // 
            // bl
            // 
            this.bl.AutoSize = true;
            this.bl.Location = new System.Drawing.Point(724, 348);
            this.bl.Name = "bl";
            this.bl.Size = new System.Drawing.Size(13, 13);
            this.bl.TabIndex = 24;
            this.bl.Text = "b";
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(876, 348);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(100, 20);
            this.b.TabIndex = 25;
            this.b.Text = "1,0";
            // 
            // ks1
            // 
            this.ks1.Location = new System.Drawing.Point(876, 374);
            this.ks1.Name = "ks1";
            this.ks1.Size = new System.Drawing.Size(100, 20);
            this.ks1.TabIndex = 26;
            this.ks1.Text = "2,7e-6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(724, 377);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "ks1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(724, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "ks2";
            // 
            // ks2
            // 
            this.ks2.Location = new System.Drawing.Point(876, 400);
            this.ks2.Name = "ks2";
            this.ks2.Size = new System.Drawing.Size(100, 20);
            this.ks2.TabIndex = 29;
            this.ks2.Text = "1,3e-6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(724, 431);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "kf";
            // 
            // kf
            // 
            this.kf.Location = new System.Drawing.Point(876, 428);
            this.kf.Name = "kf";
            this.kf.Size = new System.Drawing.Size(100, 20);
            this.kf.TabIndex = 31;
            this.kf.Text = "0,179";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 699);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox hVal;
        private System.Windows.Forms.TextBox dVal;
        private System.Windows.Forms.TextBox ylimit;
        private System.Windows.Forms.TextBox xlimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox u0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox r0;
        private System.Windows.Forms.TextBox kf;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ks2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ks1;
        private System.Windows.Forms.TextBox b;
        private System.Windows.Forms.Label bl;
        private System.Windows.Forms.TextBox a;
        private System.Windows.Forms.Label label6;
    }
}

