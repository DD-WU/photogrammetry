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
    public partial class Form1 : Form
    {
        
        double u = 0.006, f = 70.5, xm = 0, ym = 0.12;//相机参数               
        double m = 11310, n = 17310, l0, h0;
        double[,] l_SamePoint, r_SamePoint;
        readonly List<pixel> L_pixels = new List<pixel>();//左影像
        readonly List<pixel> R_pixels = new List<pixel>();//右影像
        List<Point> points = new List<Point>();//地面点坐标
        double[,] a, b;//存储外方位元素大小6*1   
        double[,] dingxiang;//相对定向元素
        Control control = new Control();
        double[,] l_jueduidinxgiang, r_jueduidingxiang;//左右影像同名像点，大小3*n
        DingXiang.TwoDouble two;//绝对定向元素
        UI.启动界面 form6 = new UI.启动界面();
        public Form1()
        {
            
           
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            

        }
        
        /// <summary>
        /// 出问题的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 绝对定向_Click(object sender, EventArgs e)
        {
            L_pixels.Clear();
            R_pixels.Clear();
            points.Clear();
            open();
            double[,] modelPoint = { { 0 } };//模型点
            double[,] pointxyz;//地面点
            pointxyz = new double[3, L_pixels.Count];//地面点坐标,3*n
            //计算模型点坐标，并给地面点坐标赋值
            l_jueduidinxgiang = new double[3, L_pixels.Count];
            r_jueduidingxiang = new double[3, L_pixels.Count];
            for (int i = 0; i < L_pixels.Count; i++)
            {
                l_jueduidinxgiang[0, i] = L_pixels[i].x;
                l_jueduidinxgiang[1, i] = L_pixels[i].y;
                l_jueduidinxgiang[2, i] = -f;
                r_jueduidingxiang[0, i] = R_pixels[i].x;
                r_jueduidingxiang[1, i] = R_pixels[i].y;
                r_jueduidingxiang[2, i] = -f;
                pointxyz[0, i] = points[i].X;
                pointxyz[1, i] = points[i].Y;
                pointxyz[2, i] = points[i].Z;
            }
            double r11 = 0;
            modelPoint= DingXiang.jueduidingxiang(modelPoint, pointxyz, l_jueduidinxgiang, r_jueduidingxiang, left, right, ref r11);
            Form4 form4 = new Form4(modelPoint, left, right, r11);
            form4.Show();
        }           
      
           
        /// <summary>
        /// 打开文件，读入数据
        /// </summary>
        public void open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "后方交会";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                //打开文件
                string path = openFileDialog.FileName;
                StreamReader reader = new StreamReader(path, Encoding.Default);
                string[] a = reader.ReadLine().Split(',');
                DataGridView data1 = new DataGridView();
                data1.Anchor = AnchorStyles.None;
                data1.Width = this.Width;
                data1.Location = new System.Drawing.Point(0, toolStrip1.Height);
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (string i in a)//这里a为局部变量，读取txt第一行作为列名
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = i;
                    column.HeaderText = i;
                    data1.Columns.Add(column);
                }
                //求像方坐标，并读取数据
                //像主点行列号
                l0 = ((m - 1) / 2 + xm / u);
                h0 = ((n - 1) / 2 - ym / u);
                while (!reader.EndOfStream)
                {
                    pixel pixels1=new pixel(), pixels2= new pixel();
                    Point point=new Point();
                    string[] temp = reader.ReadLine().Split(',');
                    point.ID = pixels1.ID = pixels2.ID = Convert.ToInt32(temp[0]);
                    //求出像平面坐标
                    pixels1.x = (Convert.ToDouble(temp[2]) - l0) * u;
                    pixels1.y = (h0 - Convert.ToDouble(temp[1])) * u;
                    pixels1.z = 0.0f;
                    L_pixels.Add(pixels1);//左影像

                    pixels2.x = (Convert.ToDouble(temp[4]) - l0) * u;
                    pixels2.y = (h0 - Convert.ToDouble(temp[3])) * u;
                    pixels2.z = 0.0f;
                    R_pixels.Add(pixels2);//右影像
                    point.X = Convert.ToDouble(temp[5]);
                    point.Y = Convert.ToDouble(temp[6]);
                    point.Z = Convert.ToDouble(temp[7]);
                    points.Add(point);//地面点
                   
                }
                //输出坐标看一下是否读取正确（正确）
                for (int i = 0; i < points.Count(); i++)
                {
                    string[] rows = new string[]
                    { L_pixels[i].ID.ToString(), L_pixels[i].x.ToString(), L_pixels[i].y.ToString(),
                     R_pixels[i].x.ToString(),R_pixels[i].y.ToString(),
                    points[i].X.ToString(),points[i].Y.ToString(),points[i].Z.ToString()};
                    data1.Rows.Add(rows);
                }
                this.Controls.Add(data1);


            }
        }
        /// <summary>
        /// 打开后方交会文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开_Click(object sender, EventArgs e)
        {
            open();//读取后方交会数据
            //防止用户不知道操作步骤乱按，不该按的时候把按钮隐藏
            toolStripDropDownButton2.Visible = true;
            toolStripTextBox1.Visible = false;

        }     
        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 后方交会
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 后方交会_Click(object sender, EventArgs e)
        {
            if (points.Count != 0)
            {
                //全局变量a,b
                a = JiaoHui.HouFangJiaoHui(L_pixels, points);
                b = JiaoHui.HouFangJiaoHui(R_pixels, points);

                Form2 form1 = new Form2(a, b);
                DataGridView data = new DataGridView();
                data.Anchor = AnchorStyles.None;
                data.Width = form1.Width;
                data.Height = form1.Height / 2;
                data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data.Columns.Add("左影像", "左影像");
                data.Columns.Add("右影像", "右影像");
                for (int i = 0; i < 6; i++)
                {
                    data.Rows.Add(a[i, 0], b[i, 0]);
                }
                form1.Controls.Add(data);
                form1.Show();
            }
            else 
            {
                MessageBox.Show("没有数据");
            }
            

        }
        //
        Bitmap bitmap = new Bitmap("捕获.PNG");
        Bitmap bitmap1 = new Bitmap("捕获1.PNG");
        Bitmap bitmap2 = new Bitmap("捕获2.PNG");
        Bitmap bitmap3 = new Bitmap("捕获3.PNG");
        private void timer1_Tick(object sender, EventArgs e)//画蛇添个足，没用
        {
            if (this.Controls.Count > 1)
            {
                撤销控件.Image = bitmap;
            }
            else 
            {
                撤销控件.Image = bitmap3;
            }
            if (control.Controls.Count != 0)
            {
                this.toolStripLabel1.Image = bitmap2;
            }
            else 
            {
                this.toolStripLabel1.Image = bitmap1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form6.ShowDialog();
            
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
           
        }


        private void 前方交会_Click(object sender, EventArgs e)
        {
            if (points.Count != 0)
            {
                Form3 form = new Form3(a, b,L_pixels,R_pixels);//前方交会在Form3中进行
                form.Show();
            }
            else 
            {
                MessageBox.Show("未进行后方交会"+'\n'+"先读数据再后方交会再前方交会");
            }
           
        }
        private void 打开相对定向_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "相对定向";
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader stream = new StreamReader(open.FileName);
                int count = Convert.ToInt32(stream.ReadLine());
                //同名像点
                l_SamePoint = new double[3, count];
                r_SamePoint = new double[3, count];
                int i = 0;
                //像主点行列号
                l0 = ((m - 1) / 2 + xm / u);
                h0 = ((n - 1) / 2 - ym / u);
                //输入无误
                while (!stream.EndOfStream)
                {
                    string[] a = stream.ReadLine().Split(',');
                    l_SamePoint[0, i] = (Convert.ToDouble(a[1]) - l0) * u;
                    l_SamePoint[1, i] = (h0 - Convert.ToDouble(a[0])) * u;
                    l_SamePoint[2, i] = -f;
                    r_SamePoint[0, i] = (Convert.ToDouble(a[3]) - l0) * u;
                    r_SamePoint[1, i] = (h0 - Convert.ToDouble(a[2])) * u;
                    r_SamePoint[2, i] = -f;
                    i++;
                }

            }
            toolStripTextBox1.Visible = true;
            toolStripDropDownButton2.Visible = false;
        }
        
        double[,] left = new double[6, 1];
        double[,] right = new double[6, 1];
        private void 相对定向_Click(object sender, EventArgs e)
        {
            if (l_SamePoint != null)
            {
                //结果无误
                dingxiang = DingXiang.XiangDuiDIngXiang(l_SamePoint, r_SamePoint);
                //左、右图像外方位元素
                left[3, 0] = dingxiang[0, 0];
                left[5, 0] = dingxiang[2, 0];
                right[0, 0] = 22.776;
                right[3, 0] = dingxiang[3, 0];
                right[4, 0] = dingxiang[4, 0];
                right[5, 0] = dingxiang[5, 0];
                //显示
                Form2 form1 = new Form2(dingxiang);
                DataGridView data = new DataGridView();
                data.Anchor = AnchorStyles.None;
                data.Width = form1.Width;
                data.Height = form1.Height / 2;
                data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data.Columns.Add("相对定向元素", "相对定向元素");
                for (int i = 0; i < 6; i++)
                {
                    data.Rows.Add(dingxiang[i, 0]);
                }
                form1.Controls.Add(data);
                form1.Show();
            }
            else
            {
                MessageBox.Show("没有数据");
            }


        }
        
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 保持界面干净整洁（以下三个都是添足用的）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 撤销控件_Click(object sender, EventArgs e)
        {                      
            if (this.Controls.Count != 1)
            {
                control.Controls.Add(this.Controls[this.Controls.Count - 1]);               
            }                
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (control.Controls.Count != 0)
            {
                this.Controls.Add(control.Controls[control.Controls.Count - 1]);               
            }


        }
       
    }
}
