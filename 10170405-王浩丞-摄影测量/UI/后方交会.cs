using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace _10170405_王浩丞_摄影测量
{
    /// <summary>
    /// 展示相对定向或后方交会结果，并提供保存、确认功能
    /// </summary>
    public partial class Form2 : Form
    {
        double[,] c, d;
        
        public Form2( double[,] a,double[,] b)//后方交会
        {
            InitializeComponent();
            c = a;
            d = b;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        public Form2(double[,] a)//相对定向
        {
            InitializeComponent();
            c = a;           
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (d == null)
            {
                SaveFileDialog save = new SaveFileDialog();

                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(save.FileName);
                    foreach (double i in c)
                    {
                        sw.WriteLine(i.ToString());
                    }
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();

                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(save.FileName);

                    foreach (double i in c)
                    {
                        sw.WriteLine(i.ToString());
                    }
                    sw.WriteLine();
                    foreach (double i in d)
                    {
                        sw.WriteLine(i.ToString());
                    }
                    sw.Flush();
                    sw.Close();
                }
                
            }
            this.Dispose();
        }
    }
}
