using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10170405_王浩丞_摄影测量.UI
{
    public partial class 打开图片 : Form
    {
        double u = 0.006, f = 70.5, xm = 0, ym = 0.12;//相机参数               
        double m = 11310, n = 17310, l0, h0;
        TextBox box1, box2, box3, box4;
        List<pixel> a = new List<pixel>();
        List<pixel> b = new List<pixel>();
        public 打开图片(TextBox text1, TextBox text2, TextBox text3, TextBox text4,List<pixel> a, List<pixel> b)
        {
            InitializeComponent();
            box1 = text1;
            box2 = text2;
            box3 = text3;
            box4 = text4;
            
            foreach (pixel i in a) 
            {
                pixel pixels = new pixel();
                pixels.ID = i.ID;
                pixels.x = i.x;
                pixels.y = i.y;
                pixels.z = i.z;
                this.a.Add(pixels);
            }
            foreach (pixel i in b)
            {
                pixel pixels = new pixel();
                pixels.ID = i.ID;
                pixels.x = i.x;
                pixels.y = i.y;
                pixels.z = i.z;
                this.b.Add(pixels);
            }

            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_down);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_up);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_move);
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_wheel);
            pictureBox2.MouseDown += new MouseEventHandler(pictureBox2_down);
            pictureBox2.MouseUp += new MouseEventHandler(pictureBox2_up);
            pictureBox2.MouseMove += new MouseEventHandler(pictureBox2_move);
            pictureBox2.MouseWheel += new MouseEventHandler(pictureBox2_wheel);          
            this.Load += Form5_Load;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            //像主点行列号
            l0 = ((m - 1) / 2 + xm / u);
            h0 = ((n - 1) / 2 - ym / u);
            for (int i = 0; i < a.Count; i++) 
            {
                a[i].x = a[i].x / u + l0;
                a[i].y = h0 - a[i].y / u;
            }
            for (int i = 0; i < b.Count; i++)
            {
                b[i].x = b[i].x / u + l0;
                b[i].y = h0 - b[i].y / u;
            }
        }

        private void pictureBox2_wheel(object sender, MouseEventArgs e) 
        {
            double step = 1.2;
            if (pictureBox2.ClientRectangle.Contains(e.Location))
            {
                if (e.Delta > 0)
                {
                    pictureBox2.Height = (int)(pictureBox2.Height * step);
                    pictureBox2.Width = (int)(pictureBox2.Width * step);

                    int px = e.Location.X ;
                    int py = e.Location.Y ;
                    int px_add = (int)(px * (step - 1.0));
                    int py_add = (int)(py * (step - 1.0));
                    pictureBox2.Location = new System.Drawing.Point(pictureBox2.Location.X - px_add, pictureBox2.Location.Y - py_add);
                }
                else if (e.Delta < 0)
                {
                    pictureBox2.Height = (int)(pictureBox2.Height / step);
                    pictureBox2.Width = (int)(pictureBox2.Width / step);

                    int px = e.Location.X ;
                    int py = e.Location.Y ;
                    int px_add = (int)(px * (1.0 - 1.0 / step));
                    int py_add = (int)(py * (1.0 - 1.0 / step));
                    pictureBox2.Location = new System.Drawing.Point(pictureBox2.Location.X + px_add, pictureBox2.Location.Y + py_add);

                }
            }
        }
        private void pictureBox1_wheel(object sender, MouseEventArgs e)
        {
            double step = 1.2;
            if (pictureBox1.ClientRectangle.Contains(e.Location))
            {
                if (e.Delta > 0)
                {
                    pictureBox1.Height = (int)(pictureBox1.Height * step);
                    pictureBox1.Width = (int)(pictureBox1.Width * step);

                    int px = e.Location.X ;
                    int py = e.Location.Y ;
                    int px_add = (int)(px * (step - 1.0));
                    int py_add = (int)(py * (step - 1.0));
                    pictureBox1.Location = new System.Drawing.Point(pictureBox1.Location.X - px_add, pictureBox1.Location.Y - py_add);
                }
                else if (e.Delta < 0)
                {
                    pictureBox1.Height = (int)(pictureBox1.Height / step);
                    pictureBox1.Width = (int)(pictureBox1.Width / step);

                    int px = e.Location.X ;
                    int py = e.Location.Y ;
                    int px_add = (int)(px * (1.0 - 1.0 / step));
                    int py_add = (int)(py * (1.0 - 1.0 / step));
                    pictureBox1.Location = new System.Drawing.Point(pictureBox1.Location.X + px_add, pictureBox1.Location.Y + py_add);

                }
            }
        }
        System.Drawing.Point pt1;
        bool mousedown1 = false;
        private void pictureBox2_down(object sender, MouseEventArgs e)
        {
            if (pictureBox2.ClientRectangle.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                mousedown1 = true;
                pt1 = Cursor.Position;
            }
        }
        private void pictureBox2_up(object sender, MouseEventArgs e)
        {
            if (pictureBox2.ClientRectangle.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                mousedown1 = false;

            }
            else if (pictureBox2.ClientRectangle.Contains(e.Location) && e.Button == MouseButtons.Right)
            {
                box4.Text = Convert.ToString(e.X * ((double)pictureBox2.Image.Width / (double)pictureBox2.Width));
                box3.Text = Convert.ToString(e.Y  * ((double)pictureBox2.Image.Height / (double)pictureBox2.Height));
                Graphics g = ((PictureBox)sender).CreateGraphics();
                g.DrawEllipse(new Pen(Color.Black), e.X - 5, e.Y - 5, 10, 10);                
                g.Dispose();
            }

        }
        private void pictureBox2_move(object sender, MouseEventArgs e)
        {
            if (pictureBox2.ClientRectangle.Contains(e.Location))
            {
                if (mousedown1 == true)
                {
                    int x = Cursor.Position.X - pt1.X;
                    int y = Cursor.Position.Y - pt1.Y;
                    pictureBox2.Location = new System.Drawing.Point(pictureBox2.Location.X + x, pictureBox2.Location.Y + y);
                    pt1 = Cursor.Position;
                }
                
                    
                
            }
            
        }
        
        System.Drawing.Point pt;
        bool mousedown = false;
        private void pictureBox1_down(object sender, MouseEventArgs e) 
        {
            
            if (pictureBox1.ClientRectangle.Contains(e.Location) && e.Button == MouseButtons.Left) 
            {
                mousedown = true;
                pt = Cursor.Position;
            }
            
        }
        private void pictureBox1_up(object sender, MouseEventArgs e)
        {
            if (pictureBox1.ClientRectangle.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                mousedown = false;
            }
            else if (pictureBox1.ClientRectangle.Contains(e.Location) && e.Button == MouseButtons.Right)
            {

                box2.Text = Convert.ToString(e.X* ((double)pictureBox1.Image.Width / (double)pictureBox1.Width));
                box1.Text = Convert.ToString(e.Y* ((double)pictureBox1.Image.Height / (double)pictureBox1.Height));

                Graphics g = ((PictureBox)sender).CreateGraphics();
                g.DrawEllipse(new Pen(Color.Black), e.X-5, e.Y-5, 10, 10);
                g.Dispose();
            }

        }
        private void pictureBox1_move(object sender, MouseEventArgs e)
        {
            if (pictureBox1.ClientRectangle.Contains(e.Location))
            {
                if (mousedown == true)
                {
                    int x = Cursor.Position.X - pt.X;
                    int y = Cursor.Position.Y - pt.Y;
                    pictureBox1.Location = new System.Drawing.Point(pictureBox1.Location.X + x, pictureBox1.Location.Y + y);
                    pt = Cursor.Position;
                }
                             
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private delegate void loadprogress(object sender, ProgressChangedEventArgs e);
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true;
            int count = 0;
            if (openFile.ShowDialog() == DialogResult.OK) 
            {
                
                foreach (string i in openFile.FileNames) 
                {
                    if (count == 0)
                    {
                        pictureBox1.LoadAsync(i);                      
                        pictureBox1.LoadProgressChanged += PictureBox1_LoadProgressChanged;
                        pictureBox1.LoadCompleted += PictureBox1_LoadCompleted;
                        count++;
                    }
                    else 
                    {
                        pictureBox2.LoadAsync(i);
                        pictureBox2.LoadProgressChanged += PictureBox2_LoadProgressChanged;
                        pictureBox2.LoadCompleted += PictureBox2_LoadCompleted;
                    }
                    
                }
                openFile.Dispose();
            }
           
                
            
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics1, graphics2;
            graphics2 = pictureBox2.CreateGraphics();
            for (int i = 0; i < b.Count; i++)
            {
                graphics2.DrawLine(new Pen(Color.Red),
                   (float)(b[i].x / pictureBox2.Image.Width * pictureBox2.Width - 5),
                    (float)(b[i].y / pictureBox2.Image.Height * pictureBox2.Height - 5),
                    (float)(b[i].x / pictureBox2.Image.Width * pictureBox2.Width + 5),
                   (float)(b[i].y / pictureBox2.Image.Height * pictureBox2.Height + 5)
                    );
                graphics2.DrawLine(new Pen(Color.Red),
                   (float)(b[i].x / pictureBox2.Image.Width * pictureBox2.Width + 5),
                    (float)(b[i].y / pictureBox2.Image.Height * pictureBox2.Height - 5),
                    (float)(b[i].x / pictureBox2.Image.Width * pictureBox2.Width - 5),
                   (float)(b[i].y / pictureBox2.Image.Height * pictureBox2.Height + 5)
                    );
            }
            graphics1 = pictureBox1.CreateGraphics();
            for (int i = 0; i < a.Count; i++)
            {
                graphics1.DrawLine(new Pen(Color.Red),
                   (float)(a[i].x / pictureBox1.Image.Width * pictureBox1.Width - 5),
                    (float)(a[i].y / pictureBox1.Image.Height * pictureBox1.Height - 5),
                    (float)(a[i].x / pictureBox1.Image.Width * pictureBox1.Width + 5),
                   (float)(a[i].y / pictureBox1.Image.Height * pictureBox1.Height + 5)
                    );
                graphics1.DrawLine(new Pen(Color.Red),
                   (float)(a[i].x / pictureBox1.Image.Width * pictureBox1.Width + 5),
                    (float)(a[i].y / pictureBox1.Image.Height * pictureBox1.Height - 5),
                    (float)(a[i].x / pictureBox1.Image.Width * pictureBox1.Width - 5),
                   (float)(a[i].y / pictureBox1.Image.Height * pictureBox1.Height + 5)
                    );
            }
            graphics1.Dispose();
            graphics2.Dispose();
        }
        private void PictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            progressBar1.Value = 100;
        }
        private void PictureBox2_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            progressBar2.Value = 100;
        }

       

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            progressBar1.Value = e.ProgressPercentage;
        }

       
        private void PictureBox2_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }
    }
}
