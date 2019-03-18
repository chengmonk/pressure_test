﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        System.Timers.Timer t;
        static List<double> l;
        bool loadDataFlag = false;
        private void hslButton1_Click(object sender, EventArgs e)
        {
            loadDataFlag = true;
           
            pushWork.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            //t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；   
        }
        void pushWorkThread(object source, System.Timers.ElapsedEventArgs e)
        {
            doData[0] = set_bit(doData[0], 3, true);
            daq.InstantDo_Write(doData);
            //System.Console.WriteLine("push:" + doData[0]);
            double t = 1000 * (double)numericUpDown1.Value;
            System.Threading.Thread.Sleep((int)t);//
            doData[0] = set_bit(doData[0], 3, false);
            daq.InstantDo_Write(doData);
            // System.Console.WriteLine("push:" + doData[0]);
        }
        void theout(object source, System.Timers.ElapsedEventArgs e)

        {
            //通道0  压力 pressure
            //通道1  水冲击力  waterHammer
            //通道2  温度
            //通道3  变频器返回值
            //通道4  流量
            double[] data = daq.InstantAi_Read(2, 3);
            if (loadDataFlag)
            {
                l.Add(data[1]);
                //连续采样N个数据，去掉一个最大值和一个最小值然后计算N - 2个数据的算术平均值N值的选取：3~14
                if (l.Count > 8)
                {
                    double sum = 0;
                    List<double> temp = new List<double>();
                    for (int i = 1; i < 8; i++)
                    {
                        temp.Add(l[l.Count - i]);
                        sum += l[l.Count - i];
                    }
                    sum = sum - temp.Max() - temp.Min();
                    l[l.Count - 4] = (sum / 5);
                    if (l[l.Count - 4] > maxFlow) { maxFlow = l[l.Count - 4]; }
                }
            }
            myDelegate md = new myDelegate(setText);
            // daq.EventCount_Read();
            // if (IsDisposed || !this.Parent.IsHandleCreated) return;
            if (this.IsHandleCreated)
                this.Invoke(md, new object[] {data });

        }
        public void setText(double[] data)
        {            
            DateTime t = DateTime.Now;
            t.ToString("yyyy-MM-dd hh:mm:ss:fff");
                            //新建第一行，并赋值           
            waterTemperature.Text = "温度：" +Math.Round( data[0],2);
            waterFlow.Text = "流量：" + Math.Round( data[2],2);
            maxWaterFlow.Text = "最大流量:" + Math.Round( maxFlow,2);

            bpqreturn.Text = Math.Round(data[1], 2).ToString();

            if (l.Count > 8 && loadDataFlag)
            {
                dt.Rows.Add(t.ToString("yyyy-MM-dd hh:mm:ss:fff"), Math.Round(data[0], 2), Math.Round(data[2], 2));
                hslCurve1.AddCurveData(
                        new string[] { "A" },
                        new float[]
                        {
                  (float) l[l.Count - 4]
                        }
                    );
            }
        }
        DAQ_profile daq;
        private config c;
        private delegate void myDelegate(double[] data);//声明委托    
        public const int CHANNEL_COUNT_MAX = 16;
        private double[] m_dataScaled = new double[CHANNEL_COUNT_MAX];
        static public DataTable dt;
        double[] aoData = new double[1];
        System.Timers.Timer monitor;
        System.Timers.Timer pushWork;
        double maxFlow = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
           
            maxFlow = -1;

            c = new config();
            c.channelCount = 3;
            c.convertClkRate = 1000;
            c.deviceDescription = "DemoDevice,BID#0";
            c.profilePath = "D:/demo.xml";
            c.sectionCount = 0;//The 0 means setting 'streaming' mode.
            c.sectionLength = 1000;
            c.startChannel = 0;

            //初始化研华板卡的功能
            daq = new DAQ_profile(0, c);
            daq.InstantAo();
            daq.InstantDi();
            daq.InstantDo();
            axgj.Enabled = true;
            tqgj.Enabled = false;
            //dp.Enabled = true;
            //bp.Enabled = false;
            bpqzt.Text = "变频器当前状态：变频";
            //sbzt.Text = "水泵当前状态：关闭";
            sbyali.Value = Properties.Settings.Default.水泵压力;
            numericUpDown1.Value = Properties.Settings.Default.保持时间;
            doData = new byte[2] { 0x00, 0x00 };
            l = new List<double>();
            l.Clear();
            hslCurve1.SetLeftCurve("A", null, Color.DodgerBlue);       

            hslCurve1.ValueMaxLeft = 10;
            hslCurve1.ValueMaxRight = 10;
            hslCurve1.StrechDataCountMax = 300;//设置显示数据量
            hslCurve1.IsAbscissaStrech = true;//这是数据全部显示
            dt = new DataTable();
            dt.Columns.Add("时间", typeof(string));
            dt.Columns.Add("温度", typeof(double));   //新建第一列
            dt.Columns.Add("流量", typeof(double));      //新建第二列    
          
            t = new System.Timers.Timer(50);
            t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件； 
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；

            monitor = new System.Timers.Timer(50);
            monitor.Elapsed += new System.Timers.ElapsedEventHandler(monitorAction);//到达时间的时候执行事件； 
            monitor.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            monitor.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件； 

            pushWork = new System.Timers.Timer(1);
            pushWork.Elapsed += new System.Timers.ElapsedEventHandler(pushWorkThread);//到达时间的时候执行事件； 
            pushWork.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            daq.InstantAi();
            t.Start();
        }
        private delegate void alarmDelegate(byte[] data, byte diData);//声明委托   
        void monitorAction(object source, System.Timers.ElapsedEventArgs e)
        {
            byte diData = daq.InstantDi_Read();
            alarmDelegate md = new alarmDelegate(alarmactive);
            // daq.EventCount_Read();
            if(this.IsHandleCreated)
            this.Invoke(md, new object[] { doData, diData });

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
                hslBlower1.MoveSpeed = (float)aoData[0]/2;
                hslBlower1.Text = "水泵运行中...";
               
                //hslLanternSimple.LanternBackground = Color.LimeGreen;

            }
            else
            {
               // sbzt.Text = "水泵当前状态：关闭";
                hslBlower1.MoveSpeed=0;
                hslBlower1.Text = "水泵已关闭";
                //hslLanternSimple.LanternBackground = Color.Red;

            }

            if (GetbitValue(data[0], 2) == 1)
            {
                qdfstatus.Text = "气动阀当前状态：已按下...";
            }
            else
            {

                qdfstatus.Text = "气动阀当前状态：关闭";
            }

            //变频器报警
            //重置所有设置
            //if (GetbitValue(diData, 0) == 1)
            //    System.Console.WriteLine("alarm");

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
            
            
           
            if (MessageBox.Show("关闭窗体后，程序会退出！！", "提示！！", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
                System.Environment.Exit(0);
                
            }
            else
            {
                if(t.Enabled)
                t.Dispose();
                if(monitor.Enabled)
                monitor.Dispose();
                if(pushWork.Enabled)
                pushWork.Dispose();
                //e.Cancel = true;
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
        }
        private byte[] doData;
        private void hslButton4_Click(object sender, EventArgs e)
        {
            if (open.Text == "打开水泵")
            {
                doData[0] = set_bit(doData[0], 1, true);
                daq.InstantDo_Write(doData);

                aoData[0] = (double)sbyali.Value;
                daq.InstantAo_Write(aoData);
                open.Text = "关闭水泵";
                //sbzt.Text = "水泵当前状态：运行中...";
            }
            else
            {
                doData[0] = set_bit(doData[0], 1, false);
                daq.InstantDo_Write(doData);
                //sbzt.Text = "水泵当前状态：关闭";
                open.Text = "打开水泵";
            }
        }

        private void dp_Click(object sender, EventArgs e)
        {
            doData[0] = set_bit(doData[0], 2, true);
            daq.InstantDo_Write(doData);
           // bpqzt.Text = "变频器当前状态：定频";
            //dp.Enabled = false;
            //bp.Enabled = true;
        }

        private void bp_Click(object sender, EventArgs e)
        {
            doData[0] = set_bit(doData[0], 2, false);
            daq.InstantDo_Write(doData);
            //bp.Enabled = false;
            //dp.Enabled = true;
            //bpqzt.Text = "变频器当前状态：变频";
        }

        private void sbyali_ValueChanged(object sender, EventArgs e)
        {
            aoData[0] = (double)sbyali.Value;
            Properties.Settings.Default.水泵压力 = sbyali.Value;
            Properties.Settings.Default.Save();
            daq.InstantAo_Write(aoData);
        }

        private void axgj_Click(object sender, EventArgs e)
        {
            doData[0] = set_bit(doData[0], 3, true);
            daq.InstantDo_Write(doData);

            axgj.Enabled = false;
            tqgj.Enabled = true;
        }

        private void tqgj_Click(object sender, EventArgs e)
        {
            doData[0] = set_bit(doData[0], 3, false);
            daq.InstantDo_Write(doData);

            axgj.Enabled = true;
            tqgj.Enabled = false;
        }

        private void hslButton4_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            DirectoryInfo theFolder;
            string foldPath = null;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath;
                theFolder = new DirectoryInfo(foldPath);
                //MessageBox.Show(foldPath);
            }
            if (workName.TextLength == 0)
            {
                MessageBox.Show("工件名称不能为空", "警报！！", MessageBoxButtons.OK);
            }
            else
                dataTableToCsvT(dt, foldPath + workName.Text + ".csv");
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

        private void hslSwitch1_OnSwitchChanged(object arg1, bool arg2)
        {
            if (arg2)//定频
            {
                doData[0] = set_bit(doData[0], 2, true);
                daq.InstantDo_Write(doData);

                aoData[0] = Convert.ToDouble(bpqreturn.Text);
                daq.InstantAo_Write(aoData);
            }
            else//变频
            {
                aoData[0] = (double)sbyali.Value;
                daq.InstantAo_Write(aoData);
                doData[0] = set_bit(doData[0], 2, false);
                daq.InstantDo_Write(doData);
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
    }
}
