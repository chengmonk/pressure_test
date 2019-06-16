using HslCommunication.ModBus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 冲水阀水力特性测试机
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //System.Timers.Timer t;
        static List<double> l;
        static List<double> wendu;
        bool loadDataFlag = false;
        bool pushedFlag = false;

        double FLOW = 0;

        void pushWorkThread(object source, System.Timers.ElapsedEventArgs e) { }
        void pushThread()
        {
            doData[0] = set_bit(doData[0], 3, true);
            daq.InstantDo_Write(doData);

            //System.Console.WriteLine("push:" + doData[0]);
            while (true)//流量大于某个数值以后开始计时
            {
                if (FLOW > (double)startThreshold.Value)
                {

                    break;
                }
                System.Threading.Thread.Sleep((int)200);//
            }
            double t = 1000 * (double)numericUpDown1.Value;
            System.Threading.Thread.Sleep((int)t);//
            doData[0] = set_bit(doData[0], 3, false);
            daq.InstantDo_Write(doData);
            // System.Console.WriteLine("push:" + doData[0]);

            pushedFlag = true;

        }

        void theout(object source)

        {
            byte diData = daq.InstantDi_Read();
            alarmDelegate mdd = new alarmDelegate(alarmactive);
            // daq.EventCount_Read();
            try
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                    this.Invoke(mdd, new object[] { doData, diData });
            }
            catch { }
            //通道0  压力 pressure
            //通道1  水冲击力  waterHammer
            //通道2  温度            
            //通道3  水泵压力输出值
            //modbus   流量
            double[] data = daq.InstantAi_Read(0, 4);

            double flow = mr.read_float("3002", 1);//读取3002地址的数据，单位立方米/s
            flow = flow * 1000;//转换成L/s
            flow = flow + Convert.ToDouble(Properties.Settings.Default.m流量);//加上误差调整
            totalFlow = mr.read_double("3014", 1);//单位立方米
            totalFlow = totalFlow * 1000;//单位：L
            data[4] = flow;
            data[5] = Math.Round(mr.read_short("8451", 2) / 100.0, 2);
            FLOW = flow;
            data[2] = data[2] * 10 + Convert.ToDouble(Properties.Settings.Default.m温度);
            if (loadDataFlag && (FLOW >= (double)startThreshold.Value))//大于阈值开始绘制曲线以及记录数据
            {

                l.Add(data[4]);
                if (wendu.Count < 1)
                    wendu.Add(data[2]);
                else if ((Math.Abs(data[2] - wendu[wendu.Count - 1]) <= 1
                    && data[2] < 50))
                    wendu.Add(data[2]);
                maxFlow = l.Max();
                maxflow_pose = l.IndexOf(l.Max());
                //连续采样N个数据，去掉一个最大值和一个最小值然后计算N - 2个数据的算术平均值N值的选取：3~14
                //if (l.Count > 8)
                //{

                //    double sum = 0;
                //    List<double> temp = new List<double>();
                //    for (int i = 1; i < 8; i++)
                //    {
                //        temp.Add(l[l.Count - i]);
                //        sum += l[l.Count - i];
                //    }
                //    sum = sum - temp.Max() - temp.Min();
                //    l[l.Count - 4] = (sum / 5);
                //    if (l[l.Count - 4] > maxFlow) { maxFlow = l[l.Count - 4]; }
                //    maxflow_pose = l.IndexOf(l.Max()) ;
                //}
            }

            myDelegate md = new myDelegate(setText);
            // daq.EventCount_Read();
            // if (IsDisposed || !this.Parent.IsHandleCreated) return;
            try
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                    this.Invoke(md, new object[] { data });
            }
            catch { }

        }
        public static int L6 = 0;
        public static int L9 = 0;

        bool first6l = true;
        bool first9l = true;
        bool firstadd0 = true;
        double TEMP;
        public void setText(double[] data)
        {
            DateTime t = DateTime.Now;
            t.ToString("yyyy-MM-dd hh:mm:ss:fff");
            //新建第一行，并赋值
            if (wendu.Count > 0)
                waterTemperature.Text = "温度：" + Math.Round(wendu[wendu.Count - 1], 2) + "℃";
            waterFlow.Text = "流量：" + Math.Round(data[4], 2) + "L/s";
            maxWaterFlow.Text = "最大流量:" + Math.Round(maxFlow, 2) + "L/s";
            totalFlowShow.Text = "累计流量：" + Math.Round(totalFlow, 2) + "L";
            pressure.Text = "出水压力：" + Math.Round(data[0], 2) + "Bar";
            pumpOutPressure.Text = "水泵输出压力值：" + Math.Round(data[3], 2) + "Bar";
            TEMP = Math.Round(data[2], 2);
            bpqreturn.Text = Math.Round(data[5], 2).ToString();//变频器返回值

            if (loadDataFlag && (FLOW >= (double)startThreshold.Value))//大于阈值开始绘制曲线以及记录数据
            {
                if (Math.Abs(Math.Round(totalFlow, 2) - 6) < 1 && first6l)//记录到达6l的索引
                {
                    L6 = l.Count;
                    first6l = false;
                }

                if (Math.Abs(Math.Round(totalFlow, 2) - 9) < 1 && first9l)//记录到达9l的索引
                {
                    L9 = l.Count;
                    first9l = false;
                }
                //if (l.Count > 8)
                {
                    if (firstadd0)//添加零点
                    {
                        if (wendu.Count > 0)
                            dt.Rows.Add(t.ToString("yyyy-MM-dd hh:mm:ss:fff"), Math.Round(wendu[wendu.Count - 1], 2), 0);
                        if (wendu.Count > 0)
                            hslCurve1.AddCurveData(
                            new string[] { "流量", "温度" },
                            new float[]
                            {
                            (float) 0,(float)wendu[wendu.Count-1]
                            }
                        );
                        firstadd0 = false;
                    }
                    else
                    {
                        if (wendu.Count > 0)
                            dt.Rows.Add(t.ToString("yyyy-MM-dd hh:mm:ss:fff"), Math.Round(wendu[wendu.Count - 1], 2), l[l.Count - 1]);
                        if (wendu.Count > 0) ;
                        hslCurve1.AddCurveData(
                        new string[] { "流量", "温度" },
                        new float[]
                        {
                            (float) l[l.Count - 1],(float)wendu[wendu.Count-1]
                        }
                    );

                    }
                }
                // Console.WriteLine("pushedFlag:" + pushedFlag);

            }
            // systemInfo.Text = "系统信息："+pushedFlag;
            if (FLOW <= (double)stopThreshold.Value && pushedFlag && l.Count > 8
                && Math.Abs(FLOW - l[l.Count - 1]) < 0.5)//小于阈值停止记录
            {
                t = t.AddMilliseconds(500);
                if (wendu.Count > 0)
                    dt.Rows.Add(t.ToString("yyyy-MM-dd hh:mm:ss:fff"), Math.Round(wendu[wendu.Count - 1], 2), 0);

                if (wendu.Count > 0)
                    hslCurve1.AddCurveData(
                    new string[] { "流量", "温度" },
                    new float[]
                    {
                            (float) 0,(float)wendu[wendu.Count-1]
                    }
                );
                loadDataFlag = false;
                pushedFlag = false;
                hslPlay1.Text = "自动运行";
                mr.write_coil("10", true, 1);//停止累计流量
                hslPlay1.Played = false;
                systemInfo.Text = "系统信息：测试已完成！！！请及时保存数据。";

            }

        }
        DAQ_profile daq;
        private config c;
        private delegate void myDelegate(double[] data);//声明委托    
        public const int CHANNEL_COUNT_MAX = 16;
        private double[] m_dataScaled = new double[CHANNEL_COUNT_MAX];
        static public DataTable dt;
        static public double totalFlow = 0;
        double[] aoData = new double[1];

        //System.Threading.Timer monitor2;        
        System.Threading.Timer t2;
        Thread push_Thread;
        public static double maxFlow = 0;
        public static int maxflow_pose = 0;

        static M_485Rtu mr;
        COMconfig conf;
        COMconfig bpqCOMConf;
        //private ModbusRtu busRtuClient = null;
        void timer_Elapsed(object sender)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Out.WriteLine(DateTime.Now + " " + DateTime.Now.Millisecond.ToString() + "timer in:");
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //ti=new  System.Threading.Timer(new TimerCallback(timer_Elapsed), null, 1000*10, 2000);

            first6l = true;
            firstadd0 = true;
            first9l = true;

            conf.botelv = "19200";
            conf.zhanhao = "1";
            conf.shujuwei = "8";
            conf.tingzhiwei = "1";
            conf.dataFromZero = true;
            conf.stringReverse = false;
            conf.COM_Name = "COM11";
            conf.checkInfo = 2;
            mr = new M_485Rtu(conf);
            mr.connect();
            mr.write_coil("10", true, 1);//停止累计流量

            //MessageBox.Show("485连接成功");

            maxFlow = -1;
            pushedFlag = false;

            loadDataFlag = false;



            c = new config();
            //c.channelCount = 3;
            c.convertClkRate = 100;
            c.deviceDescription = "PCI-1710HG,BID#0";
            c.deviceDescription = "DemoDevice,BID#0";
            //c.profilePath = "D:/demo.xml";
            c.sectionCount = 0;//The 0 means setting 'streaming' mode.
            c.sectionLength = 100;
            c.startChannel = 0;

            //初始化研华板卡的功能
            daq = new DAQ_profile(4, c);
            daq.InstantAo();
            daq.InstantDi();
            daq.InstantDo();
            doData = new byte[2] { 0x00, 0x00 };
            daq.InstantDo_Write(doData);
            l = new List<double>();
            l.Clear();
            wendu = new List<double>();
            wendu.Clear();
            //dp.Enabled = true;
            //bp.Enabled = false;
            bpqzt.Text = "变频器当前状态：变频";
            //sbzt.Text = "水泵当前状态：关闭";
            try
            {
                sbyali.Value = Properties.Settings.Default.水泵压力;
                numericUpDown1.Value = Properties.Settings.Default.保持时间;
                startThreshold.Value = Properties.Settings.Default.开始计时阈值;
                stopThreshold.Value = Properties.Settings.Default.停止阈值;
                qmin.Value = Properties.Settings.Default.qmin;
            }
            catch { }
            doData = new byte[2] { 0x00, 0x00 };
            hslCurve1.SetLeftCurve("流量", null, Color.DodgerBlue);//流量
            hslCurve1.SetRightCurve("温度", null, Color.DarkOrange);//温度
            hslCurve1.ValueMaxLeft = 10;
            hslCurve1.ValueMaxRight = 50;
            hslCurve1.StrechDataCountMax = 300;//设置显示数据量
            hslCurve1.IsAbscissaStrech = true;//这是数据全部显示
            dt = new DataTable();
            dt.Columns.Add("时间", typeof(string));
            dt.Columns.Add("温度", typeof(double));   //新建第一列
            dt.Columns.Add("流量", typeof(double));      //新建第二列    ElapsedEventHandler

            //t = new System.Timers.Timer(100);
            //t.Elapsed += new System.Timers.(theout);//到达时间的时候执行事件； 
            //t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            //t.Enabled = false;
            daq.InstantAi();
            t2 = new System.Threading.Timer(new TimerCallback(theout), null, 200, 110);

            //monitor = new System.Timers.Timer(500);
            //monitor.Elapsed += new System.Timers.ElapsedEventHandler(monitorAction);//到达时间的时候执行事件； 
            //monitor.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            //monitor.Enabled = false;//是否执行System.Timers.Timer.Elapsed事件； 
            //monitor2 = new System.Threading.Timer(new TimerCallback(monitorAction), null, 0, 1000);


            //pushWork = new System.Timers.Timer(10);
            //pushWork.Elapsed += new System.Timers.ElapsedEventHandler(pushWorkThread);//到达时间的时候执行事件； 
            //pushWork.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；




            DateTime tt = DateTime.Now;
            maxFlow = -1;
            //hslCurve1.RemoveAllCurveData();
            //dt.Clear();
            //l.Clear();
            //wendu.Clear();
            l.Add(0);//绘图从零点开始
            dt.Rows.Add(tt.ToString("yyyy-MM-dd hh:mm:ss:fff"), TEMP, 0);
            pushedFlag = false;
            first6l = true;
            first9l = true;



            //t.Start();
        }
        private delegate void alarmDelegate(byte[] data, byte diData);//声明委托 
        void monitorAction(object source, System.Timers.ElapsedEventArgs e) { }
        void monitorAction(object source)
        {
            byte diData = daq.InstantDi_Read();
            alarmDelegate md = new alarmDelegate(alarmactive);
            // daq.EventCount_Read();
            try
            {
                if (this.IsHandleCreated)
                    this.Invoke(md, new object[] { doData, diData });
            }
            catch { }
        }
        void alarmactive(byte[] data, byte diData)
        {
            if (GetbitValue(data[0], 1) == 1)
            {
                bpqzt.Text = "变频器当前状态：定频";
            }
            else
            {
                bpqzt.Text = "变频器当前状态：变频";
            }

            if (GetbitValue(data[0], 0) == 1)
            {
                //sbzt.Text = "水泵当前状态：运行中...";
                hslBlower1.MoveSpeed = (float)aoData[0] / 2;
                hslBlower1.Text = "水泵运行中...";

                //hslLanternSimple.LanternBackground = Color.LimeGreen;

            }
            else
            {
                // sbzt.Text = "水泵当前状态：关闭";
                hslBlower1.MoveSpeed = 0;
                hslBlower1.Text = "水泵已关闭";
                //hslLanternSimple.LanternBackground = Color.Red;

            }

            if (GetbitValue(data[0], 2) == 1)
            {
                qdfstatus.Text = "气动阀当前状态：已按下...";
                hslSwitch2.SwitchStatus = true;

            }
            else
            {
                hslSwitch2.SwitchStatus = false;
                qdfstatus.Text = "气动阀当前状态：关闭";
            }

            //变频器报警
            //重置所有设置
            if (GetbitValue(diData, 0) == 1)
            {
                //loadDataFlag = false;
                //pushFlag = false;
                //pushedFlag = false;

                //doData[0] = set_bit(doData[0], 1, false);
                //daq.InstantDo_Write(doData);
                //open.Text = "打开水泵";

                //systemInfo.Text += "警报！！变频器报警！！！";
            }


        }
        /// <summary>
        /// 获取数据中某一位的值
        /// </summary>
        /// <param name="input">传入的数据类型,可换成其它数据类型,比如Int</param>
        /// <param name="index">要获取的第几位的序号,从0开始 0-7</param>
        /// <returns>返回值为-1表示获取值失败</returns>
        private int GetbitValue(byte input, int index)
        {

            return ((input & (1 << index)) > 0) ? 1 : 0;
        }
        /// <summary>
        /// 设置某一位的值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index">要设置的位， 值从低到高为 1-8</param>
        /// <param name="flag">要设置的值 true / false</param>
        /// <returns></returns>
        byte set_bit(byte data, int index, bool flag)
        {
            if (index > 8 || index < 1)
                throw new ArgumentOutOfRangeException();
            int v = index < 2 ? index : (2 << (index - 2));
            return flag ? (byte)(data | v) : (byte)(data & ~v);
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try

            {
                doData = new byte[2] { 0x00, 0x00 };
                daq.InstantDo_Write(doData);
                //if (t.Enabled)
                //    t.Dispose();
                //if (monitor.Enabled)
                //    monitor.Dispose();
                //if (pushWork.Enabled)
                //    pushWork.Dispose();

                //e.Cancel = false;
                maxFlow = -1;
                //pushWork.Enabled = false;
                // monitor.Enabled = false;
                //t.Enabled = false;
                //pushWork.Dispose();
                //monitor.Dispose();
                //monitor2.Dispose();
                //t.Dispose();


                
                dt.Clear();
                l.Clear();
                wendu.Clear();
                //daq.Dispose();
                //mr.disConnect();
                // daq.InstantDi_Read();
                mr.disConnect();
                Application.Exit();
                System.Environment.Exit(0);
                //e.Cancel = true;
            }
            catch
            {

                MessageBox.Show("程序关闭异常！！！");
            }
        }

        private void hslButton2_Click(object sender, EventArgs e)
        {

            // Hide();
            using (Modify m = new Modify())
            {
                m.ShowDialog();
            }
            System.Threading.Thread.Sleep(10);
            Show();

        }

        private void hslButton3_Click(object sender, EventArgs e)
        {
            loadDataFlag = false;
            //pushedFlag = false;
        }
        private byte[] doData;
        //short sbyali_short = 0;
        private void pump_open()
        {
            doData[0] = set_bit(doData[0], 1, true);
            daq.InstantDo_Write(doData);
            aoData[0] = (double)sbyali.Value;
            //daq.InstantAo_Write(aoData);
            // sbyali_short = (short)(500 * sbyali.Value);             
            //bpqMR.connect();
            mr.write_short("125", (short)(sbyali.Value * 500), 2);
            Invoke(new Action(() =>
            {
                open.Text = "关闭水泵";
            }));
        }
        private void pump_off()
        {
            doData[0] = set_bit(doData[0], 1, false);
            daq.InstantDo_Write(doData);
            //sbzt.Text = "水泵当前状态：关闭";

            Invoke(new Action(() =>
            {
                open.Text = "打开水泵";
            }));
        }
        private void hslButton4_Click(object sender, EventArgs e)
        {
            if (open.Text == "打开水泵")
            {
                new Thread(new ThreadStart(pump_open)) { IsBackground = false }.Start();
                //sbzt.Text = "水泵当前状态：运行中...";
            }
            else
            {
                new Thread(new ThreadStart(pump_off)) { IsBackground = false }.Start();
            }
        }

        private void dp_Click(object sender, EventArgs e)
        {
            doData[0] = set_bit(doData[0], 2, true);
            daq.InstantDo_Write(doData);
            // bpqzt.Text = "变频器当前状态：定频";
            // dp.Enabled = false;
            // bp.Enabled = true;
        }

        private void bp_Click(object sender, EventArgs e)
        {
            doData[0] = set_bit(doData[0], 2, false);
            daq.InstantDo_Write(doData);

        }
        private void sbyaiThread()
        {
            aoData[0] = (double)sbyali.Value;
            Properties.Settings.Default.水泵压力 = sbyali.Value;
            Properties.Settings.Default.Save();
            if (hslSwitch1.SwitchStatus == false)
            {

                mr.write_short("125", (short)(100 * sbyali.Value * 5), 2);
            }
            Invoke(new Action(() =>
            {

            }));
        }
        private void sbyali_ValueChanged(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(sbyaiThread)) { IsBackground = false }.Start();

            // daq.InstantAo_Write(aoData);

        }

        private void axgj_Click(object sender, EventArgs e)
        {

        }

        private void tqgj_Click(object sender, EventArgs e)
        {

        }

        private void hslButton4_Click_1(object sender, EventArgs e)
        {

            if (workName.TextLength == 0)
            {
                MessageBox.Show("工件名称不能为空", "警报！！", MessageBoxButtons.OK);
            }
            else
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "文档|*.csv";
                fileDialog.FileName = workName.Text + ".csv";
                fileDialog.InitialDirectory = Application.StartupPath;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    dataTableToCsvT(dt, fileDialog.FileName);
                    MessageBox.Show("保存成功!");
                }
                fileDialog.Dispose();
            }

        }
        /// <summary>
        /// DataTable导出为CSV
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="strFilePath">路径</param>
        public static void dataTableToCsvT(System.Data.DataTable dt, string strFilePath)
        {
            if (dt == null || dt.Rows.Count == 0)   //确保DataTable中有数据
                return;
            string strBufferLine = "";
            StreamWriter strmWriterObj = new StreamWriter(strFilePath, false, System.Text.Encoding.Default);
            //写入列头
            foreach (System.Data.DataColumn col in dt.Columns)
                strBufferLine += col.ColumnName + ",";
            strBufferLine = strBufferLine.Substring(0, strBufferLine.Length - 1);
            strmWriterObj.WriteLine(strBufferLine);
            //写入记录
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strBufferLine = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j > 0)
                        strBufferLine += ",";
                    strBufferLine += dt.Rows[i][j].ToString().Replace(",", "");   //因为CSV文件以逗号分割，在这里替换为空
                }
                strmWriterObj.WriteLine(strBufferLine);
            }
            strmWriterObj.Close();
        }

        private void hslLanternSimple1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.保持时间 = numericUpDown1.Value;
            Properties.Settings.Default.Save();
        }
        private void change_bpq()
        {
            doData[0] = set_bit(doData[0], 2, true);
            daq.InstantDo_Write(doData);
            aoData[0] = (double)mr.read_short("8451", 2) / 500;//读取变频器返回值
            mr.write_short("17", mr.read_short("8451", 2), 2);//直接将从变频器读取到数据写入变频器中

            Invoke(new Action(() =>
            {
                dingpin_out.Value = (decimal)Math.Round(mr.read_short("8451", 2) / 100.0, 2);
            }));
        }
        private void change_bpq2()
        {
            aoData[0] = (double)sbyali.Value;
            //daq.InstantAo_Write(aoData);
            mr.write_short("125", (short)(100 * sbyali.Value * 5), 2);
            doData[0] = set_bit(doData[0], 2, false);
            daq.InstantDo_Write(doData);
        }
        private void hslSwitch1_OnSwitchChanged(object arg1, bool arg2)
        {
            if (arg2)//定频
            {

                //aoData[0] = Convert.ToDouble(bpqreturn.Text)/5;
                //daq.InstantAo_Write(aoData);
                new Thread(new ThreadStart(change_bpq)) { IsBackground = false }.Start();

            }
            else//变频
            {
                new Thread(new ThreadStart(change_bpq2)) { IsBackground = false }.Start();

            }
        }

        private void hslButton5_Click(object sender, EventArgs e)
        {
            // Hide();
            if (dt.Rows.Count > 1)
            {
                using (Curve form = new Curve())
                {
                    form.ShowDialog();
                }
                System.Threading.Thread.Sleep(10);
                Show();
            }

        }

        private void hslBlower1_Load(object sender, EventArgs e)
        {

        }

        private void hslButton6_Click(object sender, EventArgs e)
        {
            dt.Clear();
            hslCurve1.RemoveAllCurve();

        }

        private void hslSwitch2_OnSwitchChanged(object arg1, bool arg2)
        {
            if (arg2)
            {
                doData[0] = set_bit(doData[0], 3, true);
                daq.InstantDo_Write(doData);
            }
            else
            {
                doData[0] = set_bit(doData[0], 3, false);
                daq.InstantDo_Write(doData);
            }
        }
        private void startThread()
        {
            DateTime t = DateTime.Now;
            dt.Clear();
            l.Clear();
            wendu.Clear();
            maxFlow = -1;
            l.Add(0);//绘图从零点开始
            dt.Rows.Add(t.ToString("yyyy-MM-dd hh:mm:ss:fff"), TEMP, 0);
            pushedFlag = false;
            first6l = true;
            first9l = true;
            loadDataFlag = true;
            firstadd0 = true;
            mr.write_coil("9", true, 1);
            mr.write_coil("10", false, 1);//开始累计流量
            Invoke(new Action(() =>
            {
                //pushWork.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
                hslCurve1.RemoveAllCurveData();
                hslPlay1.Text = "停止";
                systemInfo.Text = "系统信息：";

            }));
        }
        private void hslPlay1_OnPlayChanged(object arg1, bool arg2)
        {
            if (arg2)
            {
                if (open.Text == "关闭水泵")
                {
                    // 启动线程
                    new Thread(new ThreadStart(startThread)) { IsBackground = false }.Start();

                    //if (push_Thread != null )
                    //{
                    //    if (push_Thread.IsAlive) { MessageBox.Show("请等待上一次任务执行完毕。"); }
                    //    //push_Thread.Suspend();

                    //    //push_Thread.Abort();//强制结束的时候当上一个进程没有结束的时候，调用这个函数会报错，是因为函数当中修改了全局的变量
                    //}

                    push_Thread = new Thread(new ThreadStart(pushThread));
                    push_Thread.IsBackground = true;
                    push_Thread.Start();

                }
                else
                {
                    MessageBox.Show("请先打开水泵再点击自动运行！！！");
                    hslPlay1.Played = false;
                    if (push_Thread != null && push_Thread.IsAlive)
                        push_Thread.Abort();
                }
            }
            else
            {
                new Thread(new ThreadStart(stopThread)) { IsBackground = false }.Start();
                if (push_Thread != null && push_Thread.IsAlive)
                    push_Thread.Abort();

            }
        }
        void stopThread()
        {
            loadDataFlag = false;
            pushedFlag = false;
            mr.write_coil("10", true, 1);//停止累计流量
            hslPlay1.Played = false;
            Invoke(new Action(() =>
            {
                hslPlay1.Text = "自动运行";
            }));
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Qmin_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.qmin = qmin.Value;
            Properties.Settings.Default.Save();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void StartThreshold_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.开始计时阈值 = startThreshold.Value;
            Properties.Settings.Default.Save();
        }

        private void StopThreshold_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.停止阈值 = startThreshold.Value;
            Properties.Settings.Default.Save();
        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }
        bool flowisVisiable = true;

        bool tempisVisiable = true;

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Dingpin_out_ValueChanged(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(dingpinThread)) { IsBackground = false }.Start();

        }
        void dingpinThread()
        {
            mr.write_short("17", (short)(dingpin_out.Value * 100), 2);
        }
    }
}
