using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 冲水阀水力特性测试机
{
    public partial class PressureCurve : Form
    {
        public PressureCurve()
        {
            InitializeComponent();
        }

        private void HslButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "图片|*.png";
            fileDialog.InitialDirectory = Application.StartupPath;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                hslCurveHistory1.SaveToBitmap().Save(fileDialog.FileName);
                MessageBox.Show("保存成功!");
            }
            fileDialog.Dispose();

        }

        private void PressureCurve_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(ThreadReadExample1)) { IsBackground = true }.Start();
        }
        private void ThreadReadExample1()
        {
            DataTable dt = Form1.dt;
            float[] pressure = new float[dt.Rows.Count];
            float[] hummer = new float[dt.Rows.Count];
            DateTime[] dateTime = new DateTime[dt.Rows.Count];
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd hh:mm:ss:fff";
            //加载数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                pressure[i] = (float)Convert.ToDouble(dt.Rows[i][1]);
                hummer[i] = (float)Convert.ToDouble(dt.Rows[i][2]);
                // dateTime[i] = Convert.ToDateTime(dt.Rows[i][0],dtFormat);
                dateTime[i] = DateTime.ParseExact((string)dt.Rows[i][0], "yyyy-MM-dd hh:mm:ss:fff", dtFormat);
                //Console.WriteLine((array[i, 0]));
            }
            try
            {
                Invoke(new Action(() =>
                {
                    hslCurveHistory1.Text = "正在加载数据...";
                    hslCurveHistory1.RemoveAllCurve();
                    hslCurveHistory1.SetLeftCurve("压力", pressure, Color.DodgerBlue, true, "{0:F1} L/s");//布尔变量：是否开启曲线平滑
                    hslCurveHistory1.SetLeftCurve("冲击力", hummer, Color.LightYellow, true, "{0:F1} L/s");//布尔变量：是否开启曲线平滑
                    hslCurveHistory1.SetDateTimes(dateTime);

                    hslCurveHistory1.ValueMaxLeft = 10;
                    hslCurveHistory1.ValueMinLeft = 0;
                    hslCurveHistory1.SetScaleByXAxis(xAxis);
                    hslCurveHistory1.RenderCurveUI();
                }));
            }
            catch
            {

            }
        }
        float xAxis = (float)0.5;

        private void HslButton4_Click(object sender, EventArgs e)
        {
            xAxis /= 3;
            hslCurveHistory1.SetScaleByXAxis(xAxis > 0 ? xAxis : (xAxis = 1));
            hslCurveHistory1.RenderCurveUI();
        }

        private void HslButton3_Click(object sender, EventArgs e)
        {
            hslCurveHistory1.SetScaleByXAxis(++xAxis > 0 ? xAxis : (xAxis = 1));
            hslCurveHistory1.RenderCurveUI();
        }
    }
}
