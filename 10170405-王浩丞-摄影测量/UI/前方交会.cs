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
using _10170405_王浩丞_摄影测量.UI;
using System.Diagnostics;

namespace _10170405_王浩丞_摄影测量
{
    public partial class Form3 : Form
    {
        static double u = 0.006, f = 70.5, xm = 0, ym = 0.12;//相机参数
        static double m = 11310, n = 17310, l0, h0;
        double[,] xyz;
        double[,] c, d;
        List<pixel> left ;
        List<pixel> right ;
        public Form3(double[,] a, double[,] b, List<pixel>left, List<pixel> right)
        {
            InitializeComponent();
            c = a;
            d = b;
            this.left = new List<pixel>(left);
            this.right = new List<pixel>(right);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        bool openpicture = false;
        private void button3_Click(object sender, EventArgs e)
        {
            openpicture = true;
            打开图片 form5 = new 打开图片(textBox3,textBox1,textBox6,textBox7,left,right);                                                      
            form5.Show();  
            
        }

        DataGridView data1;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                l0 = ((m - 1) / 2 + xm / u);
                h0 = ((n - 1) / 2 - ym / u);
                StreamReader reader = new StreamReader(open.FileName);
                int count = Convert.ToInt32(reader.ReadLine());
                double[,] l_pixel = new double[count, 4];
                int i = 0;
                while (!reader.EndOfStream)
                {
                    string[] a = reader.ReadLine().Split(',');

                    l_pixel[i, 0] = (Convert.ToDouble(a[1]) - l0) * u;
                    l_pixel[i, 1] = (h0 - Convert.ToDouble(a[0])) * u;
                    l_pixel[i, 2] = (Convert.ToDouble(a[3]) - l0) * u;
                    l_pixel[i, 3] = (h0 - Convert.ToDouble(a[2])) * u;
                    i++;

                }
                double[,] xyf1 = new double[3, l_pixel.GetLength(0)];
                double[,] xyf2 = new double[3, l_pixel.GetLength(0)];
                for (int j = 0; j < i; j++)
                {
                    xyf1[0, j] = l_pixel[j, 0];
                    xyf1[1, j] = l_pixel[j, 1];
                    xyf1[2, j] = -f;
                    xyf2[0, j] = l_pixel[j, 2];
                    xyf2[1, j] = l_pixel[j, 3];
                    xyf2[2, j] = -f;
                }
                
                xyz = JiaoHui.qianfangjiaohui(c, d, xyf1, xyf2);
                double area = areaAndCircum.area(xyz);
                double circum = areaAndCircum.Circum(xyz);

                //this.Controls.Clear();   
                Form3 form3 = new Form3(c,d,left,right);
                form3.Controls.Clear();
                data1 = new DataGridView();
                data1.Width = this.Width;
                data1.Location = new System.Drawing.Point(0, 0);
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data1.Columns.Add("x", "x");
                data1.Columns.Add("y", "y");
                data1.Columns.Add("z", "z");
                for (int j = 0; j < i; j++)
                {
                    data1.Rows.Add(xyz[0, j].ToString(), xyz[1, j].ToString(), xyz[2, j].ToString());

                }
                form3.Controls.Add(data1);
                Button save = new Button();
                save.Width = 80;
                save.Height = 30;
                save.Top = this.Height-100;
                save.Left = 300;
                save.Text = "save";                
                save.Click += Save_Click;
                form3.Controls.Add(save);
                Button Add = new Button();
                Add.Width = 80;
                Add.Height = 30;
                Add.Top = this.Height - 100;
                Add.Left = 100;
                Add.Text = "Add";
                Add.Click += Add_Click;
                form3.Controls.Add(Add);
                Button process = new Button();
                process.Width = 80;
                process.Height = 30;
                process.Top = this.Height - 100;
                process.Left = 200;
                process.Text = "process";
                process.Click += Process_Click;
                form3.Controls.Add(process);
                form3.Show();
                MessageBox.Show("   面积：" + area + '\n' + "   周长：" + circum);
            }
            
        }
        /// <summary>
        /// 用于打开arcgis或.mxd文件,可通过在本页面保存的.txt文件生成矢量文件，进而生成地形图。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Process_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter += ".exe|*.exe|.mxd|*.mxd";
           
            if (openFile.ShowDialog() == DialogResult.OK) 
            {
                Process process = new Process();//打开arcgis
                process.StartInfo.FileName = openFile.FileName;
                process.Start();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (openpicture == true&& textBox4.Text!="") 
            {
                data1.Rows.Add(Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox5.Text));
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK) 
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                for (int i = 0; i < data1.Rows.Count-1; i++) 
                {
                    for (int j = 0; j < data1.Columns.Count; j++) 
                    {
                        writer.Write(data1.Rows[i].Cells[j].Value.ToString()+"  ");
                    }
                    writer.Write('\n');
                }
                writer.Flush();
                writer.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox3.Text != "") 
            {
                l0 = ((m - 1) / 2 + xm / u);
                h0 = ((n - 1) / 2 - ym / u);
                double[,] xyf1 = new double[3, 1];
                double[,] xyf2 = new double[3, 1];
                xyf1[0, 0] = (Convert.ToDouble(textBox1.Text) - l0) * u;
                xyf1[1, 0] = (h0 - Convert.ToDouble(textBox3.Text)) * u;
                xyf1[2, 0] = -f;
                xyf2[0, 0] = (Convert.ToDouble(textBox7.Text) - l0) * u;
                xyf2[1, 0] = (h0 - Convert.ToDouble(textBox6.Text)) * u;
                xyf2[2, 0] = -f;
                double[,] XAYAZA = JiaoHui.qianfangjiaohui(c, d, xyf1, xyf2);
                textBox4.Text = XAYAZA[0, 0].ToString();
                textBox2.Text = XAYAZA[1, 0].ToString();
                textBox5.Text = XAYAZA[2, 0].ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
