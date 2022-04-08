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
namespace _10170405_王浩丞_摄影测量
{
    public partial class Form4 : Form
    {
        double[,] left;
        double[,] right;
        double u = 0.006, f = 70.5, xm = 0, ym = 0.12;//相机参数               
        double m = 11310, n = 17310, l0, h0,r11;

        

        double[,] two;
        public Form4(double[,] two,double[,]left,double[,]right,double r11)
        {
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.two = two;
            this.left = left;
            this.right = right;
            this.r11 = r11;
            this.richTextBox1.AppendText("r:" + System.Environment.NewLine);
            this.richTextBox1.AppendText( (two[3,0]+r11).ToString()+ System.Environment.NewLine);
            this.richTextBox1.AppendText("R:" + System.Environment.NewLine);
            for (int i = 4; i < 7; i++) 
            {

                this.richTextBox1.AppendText(two[i, 0].ToString() + "   ");

                this.richTextBox1.AppendText(System.Environment.NewLine);
            }
            this.richTextBox1.AppendText("平移参数:" + System.Environment.NewLine);
            for (int i = 0; i < 3; i++)
            {
                this.richTextBox1.AppendText(two[i, 0] + "    ");
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        DataGridView data1;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                l0 = ((m - 1) / 2 + xm / u);
                h0 = ((n - 1) / 2 - ym / u);
                //打开文件
                string path = openFileDialog.FileName;
                StreamReader reader = new StreamReader(path, Encoding.Default);
                string[] a = reader.ReadLine().Split(',');
                List<pixel> Lpixels = new List<pixel>();
                List<pixel> Rpixels = new List<pixel>();
                double[,] lJueDuiDingXiang, rJueDuiDingXiang;
                while (!reader.EndOfStream)
                {
                    pixel pixels1 = new pixel(), pixels2 = new pixel();
                    Point point = new Point();
                    string[] temp = reader.ReadLine().Split(',');
                    point.ID = pixels1.ID = pixels2.ID = Convert.ToInt32(temp[0]);
                    //求出像平面坐标
                    pixels1.x = (Convert.ToDouble(temp[2]) - l0) * u;
                    pixels1.y = (h0 - Convert.ToDouble(temp[1])) * u;
                    pixels1.z = 0.0f;
                    Lpixels.Add(pixels1);//左影像

                    pixels2.x = (Convert.ToDouble(temp[4]) - l0) * u;
                    pixels2.y = (h0 - Convert.ToDouble(temp[3])) * u;
                    pixels2.z = 0.0f;
                    Rpixels.Add(pixels2);//右影像                 
                }
                lJueDuiDingXiang = new double[3, Lpixels.Count];
                rJueDuiDingXiang = new double[3, Lpixels.Count];
                double[,] poi = new double[3, Lpixels.Count];
                for (int i = 0; i < Lpixels.Count; i++)
                {
                    lJueDuiDingXiang[0, i] = Lpixels[i].x;
                    lJueDuiDingXiang[1, i] = Lpixels[i].y;
                    lJueDuiDingXiang[2, i] = -f;
                    rJueDuiDingXiang[0, i] = Rpixels[i].x;
                    rJueDuiDingXiang[1, i] = Rpixels[i].y;
                    rJueDuiDingXiang[2, i] = -f;
                }
                double[,] modelPoint = JiaoHui.qianfangjiaohui(left, right, lJueDuiDingXiang, rJueDuiDingXiang);

                int count = Lpixels.Count;

               
                double[,] R = matrix.T(matrix.xuanzhuanjuzhen(two[4, 0], two[5, 0], two[6, 0]), 3, 3);
                double[,] xyz = new double[3, 1];
                double[,] uvw = new double[3, 1];
                double[,] uvw1 = new double[3, count];
                for (int i = 0; i < 3; i++) 
                {
                    xyz[i, 0] = two[i , 0];
                }
                for (int s = 0; s < count; s++)
                {

                    uvw[0, 0] = r11 * modelPoint[0, s] - two[7, 0];
                    uvw[1, 0] = r11 * modelPoint[1, s] - two[8, 0];
                    uvw[2, 0] = r11 * modelPoint[2, s] - two[9, 0];

                    double[,] R_UVW =  matrix.MatrixMulti(R, uvw);
                    uvw1[0, s] = two[3, 0] * R_UVW[0, 0] + two[0, 0];
                    uvw1[1, s] = two[3, 0] * R_UVW[1, 0] + two[1, 0];
                    uvw1[2, s] = two[3, 0] * R_UVW[2, 0] + two[2, 0];



                }
                    
                double area = areaAndCircum.area(uvw1);
                double circum = areaAndCircum.Circum(uvw1);

                this.Controls.Clear();
                data1 = new DataGridView();
                data1.Width = this.Width;
                data1.Location = new System.Drawing.Point(0, 0);
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data1.Columns.Add("x", "x");
                data1.Columns.Add("y", "y");
                data1.Columns.Add("z", "z");
                for (int j = 0; j < count; j++)
                {
                    data1.Rows.Add(uvw1[0, j].ToString(), uvw1[1, j].ToString(), uvw1[2, j].ToString());

                }
                this.Controls.Add(data1);
                Button save = new Button();
                save.Width = 50;
                save.Height = 20;
                save.Top = this.Height - 100;
                save.Left = this.Width - 100;
                save.Text = "save";
                save.Click += Save_Click;
                this.Controls.Add(save);
                
                MessageBox.Show("   面积：" + area + '\n' + "   周长：" + circum);
            }

        }
        
        private void Save_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                for (int i = 0; i < data1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < data1.Columns.Count; j++)
                    {
                        writer.Write(data1.Rows[i].Cells[j].Value.ToString() + "  ");
                    }
                    writer.Write('\n');
                }
                writer.Flush();
                writer.Close();
            }
        }
    }
}
