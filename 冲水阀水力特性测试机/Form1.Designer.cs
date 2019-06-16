namespace 冲水阀水力特性测试机
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.hslButton3 = new HslControls.HslButton();
            this.instantDoCtrl1 = new Automation.BDaq.InstantDoCtrl(this.components);
            this.m_instantAoCtrl = new Automation.BDaq.InstantAoCtrl(this.components);
            this.instantDiCtrl1 = new Automation.BDaq.InstantDiCtrl(this.components);
            this.hslCurve1 = new HslControls.HslCurve();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dingpin_out = new System.Windows.Forms.NumericUpDown();
            this.dingpin_ = new System.Windows.Forms.Label();
            this.hslBlower1 = new HslControls.HslBlower();
            this.hslSwitch1 = new HslControls.HslSwitch();
            this.bpqreturn = new System.Windows.Forms.Label();
            this.sbzt = new System.Windows.Forms.Label();
            this.bpqzt = new System.Windows.Forms.Label();
            this.bpqfh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sbyali = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.open = new HslControls.HslButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.hslButton4 = new HslControls.HslButton();
            this.label5 = new System.Windows.Forms.Label();
            this.workName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.stopThreshold = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.startThreshold = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.hslSwitch2 = new HslControls.HslSwitch();
            this.qdfstatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hslPlay1 = new HslControls.HslPlay();
            this.systemInfo = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.waterHammerMax = new System.Windows.Forms.Label();
            this.pressureMax = new System.Windows.Forms.Label();
            this.waterHammer = new System.Windows.Forms.Label();
            this.waterPresuer = new System.Windows.Forms.Label();
            this.waterTemperature = new System.Windows.Forms.Label();
            this.instantAiCtrl1 = new Automation.BDaq.InstantAiCtrl(this.components);
            this.hslButton1 = new HslControls.HslButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dingpin_out)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbyali)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startThreshold)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // hslButton3
            // 
            this.hslButton3.CustomerInformation = null;
            this.hslButton3.Location = new System.Drawing.Point(26, 110);
            this.hslButton3.Name = "hslButton3";
            this.hslButton3.Size = new System.Drawing.Size(68, 30);
            this.hslButton3.TabIndex = 3;
            this.hslButton3.Text = "保存数据";
            this.hslButton3.Click += new System.EventHandler(this.hslButton3_Click);
            // 
            // instantDoCtrl1
            // 
            this.instantDoCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("instantDoCtrl1._StateStream")));
            // 
            // m_instantAoCtrl
            // 
            this.m_instantAoCtrl._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("m_instantAoCtrl._StateStream")));
            // 
            // instantDiCtrl1
            // 
            this.instantDiCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("instantDiCtrl1._StateStream")));
            // 
            // hslCurve1
            // 
            this.hslCurve1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hslCurve1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hslCurve1.Location = new System.Drawing.Point(27, 12);
            this.hslCurve1.Name = "hslCurve1";
            this.hslCurve1.Size = new System.Drawing.Size(616, 241);
            this.hslCurve1.TabIndex = 5;
            this.hslCurve1.ValueMaxLeft = 10F;
            this.hslCurve1.ValueMaxRight = 10F;
            this.hslCurve1.ValueSegment = 20;
            this.hslCurve1.Load += new System.EventHandler(this.hslCurve1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dingpin_out);
            this.groupBox1.Controls.Add(this.dingpin_);
            this.groupBox1.Controls.Add(this.hslBlower1);
            this.groupBox1.Controls.Add(this.hslSwitch1);
            this.groupBox1.Controls.Add(this.bpqreturn);
            this.groupBox1.Controls.Add(this.sbzt);
            this.groupBox1.Controls.Add(this.bpqzt);
            this.groupBox1.Controls.Add(this.bpqfh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sbyali);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.open);
            this.groupBox1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(649, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 337);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "水泵控制";
            // 
            // dingpin_out
            // 
            this.dingpin_out.DecimalPlaces = 2;
            this.dingpin_out.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.dingpin_out.Location = new System.Drawing.Point(243, 151);
            this.dingpin_out.Margin = new System.Windows.Forms.Padding(4);
            this.dingpin_out.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.dingpin_out.Name = "dingpin_out";
            this.dingpin_out.Size = new System.Drawing.Size(71, 21);
            this.dingpin_out.TabIndex = 35;
            this.dingpin_out.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dingpin_out.ThousandsSeparator = true;
            this.dingpin_out.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.dingpin_out.ValueChanged += new System.EventHandler(this.Dingpin_out_ValueChanged);
            // 
            // dingpin_
            // 
            this.dingpin_.AutoSize = true;
            this.dingpin_.Location = new System.Drawing.Point(160, 153);
            this.dingpin_.Name = "dingpin_";
            this.dingpin_.Size = new System.Drawing.Size(89, 12);
            this.dingpin_.TabIndex = 34;
            this.dingpin_.Text = "定频输出频率：";
            // 
            // hslBlower1
            // 
            this.hslBlower1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(205)))), ((int)(((byte)(211)))));
            this.hslBlower1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.hslBlower1.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(220)))));
            this.hslBlower1.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(160)))), ((int)(((byte)(169)))));
            this.hslBlower1.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(100)))), ((int)(((byte)(111)))));
            this.hslBlower1.Color6 = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(114)))), ((int)(((byte)(121)))));
            this.hslBlower1.Color7 = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(165)))), ((int)(((byte)(173)))));
            this.hslBlower1.Color8 = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(182)))), ((int)(((byte)(189)))));
            this.hslBlower1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hslBlower1.Location = new System.Drawing.Point(71, 196);
            this.hslBlower1.Margin = new System.Windows.Forms.Padding(2);
            this.hslBlower1.Name = "hslBlower1";
            this.hslBlower1.Size = new System.Drawing.Size(112, 136);
            this.hslBlower1.TabIndex = 22;
            this.hslBlower1.Text = "关闭";
            this.hslBlower1.Load += new System.EventHandler(this.HslBlower1_Load);
            this.hslBlower1.Click += new System.EventHandler(this.hslBlower1_Click);
            // 
            // hslSwitch1
            // 
            this.hslSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hslSwitch1.Location = new System.Drawing.Point(217, 19);
            this.hslSwitch1.Margin = new System.Windows.Forms.Padding(2);
            this.hslSwitch1.Name = "hslSwitch1";
            this.hslSwitch1.Size = new System.Drawing.Size(94, 106);
            this.hslSwitch1.SwitchBackground = System.Drawing.Color.Gray;
            this.hslSwitch1.SwitchForeground = System.Drawing.Color.Black;
            this.hslSwitch1.SwitchStatusDescription = "变频;定频";
            this.hslSwitch1.TabIndex = 21;
            this.hslSwitch1.Text = "定变频选择";
            this.hslSwitch1.OnSwitchChanged += new System.Action<object, bool>(this.hslSwitch1_OnSwitchChanged);
            // 
            // bpqreturn
            // 
            this.bpqreturn.AutoSize = true;
            this.bpqreturn.Location = new System.Drawing.Point(112, 95);
            this.bpqreturn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bpqreturn.Name = "bpqreturn";
            this.bpqreturn.Size = new System.Drawing.Size(23, 12);
            this.bpqreturn.TabIndex = 17;
            this.bpqreturn.Text = "0.0";
            // 
            // sbzt
            // 
            this.sbzt.AutoSize = true;
            this.sbzt.Location = new System.Drawing.Point(6, 153);
            this.sbzt.Name = "sbzt";
            this.sbzt.Size = new System.Drawing.Size(89, 12);
            this.sbzt.TabIndex = 16;
            this.sbzt.Text = "水泵当前状态：";
            // 
            // bpqzt
            // 
            this.bpqzt.AutoSize = true;
            this.bpqzt.Location = new System.Drawing.Point(6, 125);
            this.bpqzt.Name = "bpqzt";
            this.bpqzt.Size = new System.Drawing.Size(101, 12);
            this.bpqzt.TabIndex = 15;
            this.bpqzt.Text = "变频器当前状态：";
            // 
            // bpqfh
            // 
            this.bpqfh.AutoSize = true;
            this.bpqfh.Location = new System.Drawing.Point(6, 95);
            this.bpqfh.Name = "bpqfh";
            this.bpqfh.Size = new System.Drawing.Size(101, 12);
            this.bpqfh.TabIndex = 14;
            this.bpqfh.Text = "变频器输出频率：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "Bar";
            // 
            // sbyali
            // 
            this.sbyali.DecimalPlaces = 1;
            this.sbyali.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.sbyali.Location = new System.Drawing.Point(65, 61);
            this.sbyali.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sbyali.Name = "sbyali";
            this.sbyali.Size = new System.Drawing.Size(89, 21);
            this.sbyali.TabIndex = 12;
            this.sbyali.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sbyali.ThousandsSeparator = true;
            this.sbyali.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.sbyali.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "水泵压力：";
            // 
            // open
            // 
            this.open.CustomerInformation = null;
            this.open.Location = new System.Drawing.Point(6, 20);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(148, 35);
            this.open.TabIndex = 10;
            this.open.Text = "打开水泵";
            this.open.Click += new System.EventHandler(this.hslButton4_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "秒";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(105, 22);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 21);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ThousandsSeparator = true;
            this.numericUpDown1.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "工件保持时间：";
            // 
            // hslButton4
            // 
            this.hslButton4.CustomerInformation = null;
            this.hslButton4.Location = new System.Drawing.Point(26, 161);
            this.hslButton4.Name = "hslButton4";
            this.hslButton4.Size = new System.Drawing.Size(68, 26);
            this.hslButton4.TabIndex = 17;
            this.hslButton4.Text = "误差修正";
            this.hslButton4.Click += new System.EventHandler(this.hslButton4_Click_2);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "工件名称：";
            // 
            // workName
            // 
            this.workName.Location = new System.Drawing.Point(94, 58);
            this.workName.Margin = new System.Windows.Forms.Padding(2);
            this.workName.Multiline = true;
            this.workName.Name = "workName";
            this.workName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.workName.Size = new System.Drawing.Size(117, 55);
            this.workName.TabIndex = 19;
            this.workName.Text = "冲水阀";
            this.workName.TextChanged += new System.EventHandler(this.workName_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.stopThreshold);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.startThreshold);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.hslSwitch2);
            this.groupBox2.Controls.Add(this.qdfstatus);
            this.groupBox2.Controls.Add(this.workName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(648, 347);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(326, 213);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工件属性";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = "停止采集阈值：";
            // 
            // stopThreshold
            // 
            this.stopThreshold.DecimalPlaces = 2;
            this.stopThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.stopThreshold.Location = new System.Drawing.Point(106, 184);
            this.stopThreshold.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.stopThreshold.Name = "stopThreshold";
            this.stopThreshold.Size = new System.Drawing.Size(61, 21);
            this.stopThreshold.TabIndex = 35;
            this.stopThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stopThreshold.ThousandsSeparator = true;
            this.stopThreshold.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.stopThreshold.ValueChanged += new System.EventHandler(this.StopThreshold_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(173, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 11);
            this.label9.TabIndex = 36;
            this.label9.Text = "压力小于这个值停止采集";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "开始计时阈值：";
            // 
            // startThreshold
            // 
            this.startThreshold.DecimalPlaces = 2;
            this.startThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.startThreshold.Location = new System.Drawing.Point(107, 153);
            this.startThreshold.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.startThreshold.Name = "startThreshold";
            this.startThreshold.Size = new System.Drawing.Size(61, 21);
            this.startThreshold.TabIndex = 32;
            this.startThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startThreshold.ThousandsSeparator = true;
            this.startThreshold.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.startThreshold.ValueChanged += new System.EventHandler(this.StartThreshold_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(174, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 11);
            this.label7.TabIndex = 33;
            this.label7.Text = "压力大于这个值开始计时";
            // 
            // hslSwitch2
            // 
            this.hslSwitch2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hslSwitch2.Location = new System.Drawing.Point(236, 22);
            this.hslSwitch2.Margin = new System.Windows.Forms.Padding(2);
            this.hslSwitch2.Name = "hslSwitch2";
            this.hslSwitch2.Size = new System.Drawing.Size(76, 87);
            this.hslSwitch2.SwitchForeground = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.hslSwitch2.SwitchStatusDescription = "抬起;按下";
            this.hslSwitch2.TabIndex = 30;
            this.hslSwitch2.Text = "工件控制器";
            this.hslSwitch2.OnSwitchChanged += new System.Action<object, bool>(this.hslSwitch2_OnSwitchChanged);
            // 
            // qdfstatus
            // 
            this.qdfstatus.AutoSize = true;
            this.qdfstatus.Location = new System.Drawing.Point(15, 130);
            this.qdfstatus.Name = "qdfstatus";
            this.qdfstatus.Size = new System.Drawing.Size(101, 12);
            this.qdfstatus.TabIndex = 20;
            this.qdfstatus.Text = "气动阀当前状态：";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.hslButton1);
            this.groupBox3.Controls.Add(this.hslPlay1);
            this.groupBox3.Controls.Add(this.hslButton4);
            this.groupBox3.Controls.Add(this.hslButton3);
            this.groupBox3.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(9, 244);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(232, 245);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作区";
            // 
            // hslPlay1
            // 
            this.hslPlay1.ActiveColor = System.Drawing.Color.Red;
            this.hslPlay1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hslPlay1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.hslPlay1.Location = new System.Drawing.Point(26, 16);
            this.hslPlay1.Name = "hslPlay1";
            this.hslPlay1.Size = new System.Drawing.Size(59, 87);
            this.hslPlay1.TabIndex = 28;
            this.hslPlay1.Text = "自动运行";
            this.hslPlay1.OnPlayChanged += new System.Action<object, bool>(this.hslPlay1_OnPlayChanged);
            // 
            // systemInfo
            // 
            this.systemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.systemInfo.AutoSize = true;
            this.systemInfo.Location = new System.Drawing.Point(33, 494);
            this.systemInfo.Name = "systemInfo";
            this.systemInfo.Size = new System.Drawing.Size(65, 12);
            this.systemInfo.TabIndex = 22;
            this.systemInfo.Text = "系统信息：";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.waterHammerMax);
            this.groupBox4.Controls.Add(this.pressureMax);
            this.groupBox4.Controls.Add(this.waterHammer);
            this.groupBox4.Controls.Add(this.waterPresuer);
            this.groupBox4.Controls.Add(this.waterTemperature);
            this.groupBox4.Location = new System.Drawing.Point(239, 244);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(375, 245);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "仪表显示";
            // 
            // waterHammerMax
            // 
            this.waterHammerMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterHammerMax.AutoSize = true;
            this.waterHammerMax.Location = new System.Drawing.Point(24, 201);
            this.waterHammerMax.Name = "waterHammerMax";
            this.waterHammerMax.Size = new System.Drawing.Size(77, 12);
            this.waterHammerMax.TabIndex = 27;
            this.waterHammerMax.Text = "最大冲击力：";
            // 
            // pressureMax
            // 
            this.pressureMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pressureMax.AutoSize = true;
            this.pressureMax.Location = new System.Drawing.Point(24, 161);
            this.pressureMax.Name = "pressureMax";
            this.pressureMax.Size = new System.Drawing.Size(65, 12);
            this.pressureMax.TabIndex = 26;
            this.pressureMax.Text = "最大压力：";
            // 
            // waterHammer
            // 
            this.waterHammer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterHammer.AutoSize = true;
            this.waterHammer.Location = new System.Drawing.Point(24, 80);
            this.waterHammer.Name = "waterHammer";
            this.waterHammer.Size = new System.Drawing.Size(53, 12);
            this.waterHammer.TabIndex = 25;
            this.waterHammer.Text = "冲击力：";
            // 
            // waterPresuer
            // 
            this.waterPresuer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterPresuer.AutoSize = true;
            this.waterPresuer.Location = new System.Drawing.Point(24, 34);
            this.waterPresuer.Name = "waterPresuer";
            this.waterPresuer.Size = new System.Drawing.Size(41, 12);
            this.waterPresuer.TabIndex = 24;
            this.waterPresuer.Text = "压力：";
            // 
            // waterTemperature
            // 
            this.waterTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waterTemperature.AutoSize = true;
            this.waterTemperature.Location = new System.Drawing.Point(24, 121);
            this.waterTemperature.Name = "waterTemperature";
            this.waterTemperature.Size = new System.Drawing.Size(41, 12);
            this.waterTemperature.TabIndex = 23;
            this.waterTemperature.Text = "温度：";
            // 
            // instantAiCtrl1
            // 
            this.instantAiCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("instantAiCtrl1._StateStream")));
            // 
            // hslButton1
            // 
            this.hslButton1.CustomerInformation = null;
            this.hslButton1.Location = new System.Drawing.Point(26, 201);
            this.hslButton1.Name = "hslButton1";
            this.hslButton1.Size = new System.Drawing.Size(68, 26);
            this.hslButton1.TabIndex = 29;
            this.hslButton1.Text = "绘制曲线";
            this.hslButton1.Click += new System.EventHandler(this.HslButton1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 585);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.systemInfo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hslCurve1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "压力特性测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dingpin_out)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbyali)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startThreshold)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HslControls.HslButton hslButton3;
        private Automation.BDaq.InstantDoCtrl instantDoCtrl1;
        private Automation.BDaq.InstantAoCtrl m_instantAoCtrl;
        private Automation.BDaq.InstantDiCtrl instantDiCtrl1;
        private HslControls.HslCurve hslCurve1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown sbyali;
        private System.Windows.Forms.Label label1;
        private HslControls.HslButton open;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label bpqfh;
        private System.Windows.Forms.Label sbzt;
        private System.Windows.Forms.Label bpqzt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private HslControls.HslButton hslButton4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox workName;
        private System.Windows.Forms.Label bpqreturn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label qdfstatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private HslControls.HslSwitch hslSwitch1;
        private HslControls.HslBlower hslBlower1;
        private System.Windows.Forms.Label systemInfo;
        private HslControls.HslSwitch hslSwitch2;
        private HslControls.HslPlay hslPlay1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown startThreshold;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown stopThreshold;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label waterHammer;
        private System.Windows.Forms.Label waterPresuer;
        private System.Windows.Forms.Label waterTemperature;
        private System.Windows.Forms.Label waterHammerMax;
        private System.Windows.Forms.Label pressureMax;
        private System.Windows.Forms.NumericUpDown dingpin_out;
        private System.Windows.Forms.Label dingpin_;
        private HslControls.HslButton hslButton1;
        private Automation.BDaq.InstantAiCtrl instantAiCtrl1;
    }
}

