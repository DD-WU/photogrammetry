using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10170405_王浩丞_摄影测量
{
    
    public class pixel//像平面坐标
    {
        public int ID;
        public double x;
        public double y;
        public double z;
        public static pixel operator +(pixel a, pixel b)
        {
            pixel point = new pixel();
            point.x = a.x + b.x;
            point.y = a.y + b.y;
            point.z = a.z + b.z;
            return point;
        }
        public static pixel operator -(pixel a, pixel b)
        {
            pixel point = new pixel();
            point.x = a.x - b.x;
            point.y = a.y - b.y;
            point.z = a.z - b.z;
            return point;
        }
        public static pixel operator *(pixel a, pixel b)
        {
            pixel point = new pixel();
            point.x = a.x * b.x;
            point.y = a.y * b.y;
            point.z = a.z * b.z;
            return point;
        }
        public static pixel operator /(pixel a, pixel b)
        {
            pixel point = new pixel();
            point.x = a.x / b.x;
            point.y = a.y / b.y;
            point.z = a.z / b.z;
            return point;
        }
        
    }

    public class Point //地面点坐标
    {
		public int ID;
		public double X;
		public double Y;
		public double Z;
        public static Point operator +(Point a, Point b)
        {
            Point point = new Point();
            point.X = a.X + b.X;
            point.Y = a.Y + b.Y;
            point.Z = a.Z + b.Z;
            return point;
        }
        public static Point operator -(Point a, Point b)
        {
            Point point = new Point();
            point.X = a.X - b.X;
            point.Y = a.Y - b.Y;
            point.Z = a.Z - b.Z;
            return point;
        }
        public static Point operator *(Point a, Point b)
        {
            Point point = new Point();
            point.X = a.X * b.X;
            point.Y = a.Y * b.Y;
            point.Z = a.Z * b.Z;
            return point;
        }
        public static Point operator /(Point a, Point b)
        {
            Point point = new Point();
            point.X = a.X / b.X;
            point.Y = a.Y / b.Y;
            point.Z = a.Z / b.Z;
            return point;
        }
    }
    /// <summary>
    /// 矩阵类
    /// </summary>
    public class matrix
    {

        /// 方阵求逆函数1,Psr为输入方阵，N为方阵的大小,P为返回的逆矩阵
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public static double[,] juzhqn1(double[,] Psr)
        {
            double[,] P;
            double d = 0.0;
            double temp = 0.0;
            int N, N1;
            N = Psr.GetLength(0);
            N1 = Psr.GetLength(1);
            P = new double[N, N1];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N1; j++)
                    P[i, j] = Psr[i, j];
            int[] main_row = new int[N];
            int[] main_col = new int[N];
            if (N == N1)
            {
                for (int k = 0; k <= N - 1; k++)
                {
                    d = 0.0;
                    for (int i = k; i <= N - 1; i++)
                    {
                        for (int j = k; j <= N - 1; j++)
                        {
                            temp = Math.Abs(P[i, j]);
                            if (temp > d)
                            {
                                d = temp; main_row[k] = i; main_col[k] = j;
                            }
                        }
                    }
                    if (main_row[k] != k)
                    {
                        for (int j = 0; j <= N - 1; j++)
                        {
                            temp = P[main_row[k], j]; P[main_row[k], j] = P[k, j]; P[k, j] = temp;
                        }
                    }
                    if (main_col[k] != k)
                    {
                        for (int i = 0; i <= N - 1; i++)
                        {
                            temp = P[i, main_col[k]]; P[i, main_col[k]] = P[i, k]; P[i, k] = temp;
                        }
                    }
                    P[k, k] = 1.0 / P[k, k];
                    for (int j = 0; j <= N - 1; j++)
                    {
                        if (j != k)
                        {
                            P[k, j] *= P[k, k];
                        }
                    }

                    for (int i = 0; i <= N - 1; i++)
                    {
                        if (i != k)
                        {
                            for (int j = 0; j <= N - 1; j++)
                            {
                                if (j != k)
                                {
                                    P[i, j] -= P[i, k] * P[k, j];
                                }
                            }
                        }
                    }
                    for (int i = 0; i <= N - 1; i++)
                    {
                        if (i != k)
                        {
                            P[i, k] = -P[i, k] * P[k, k];
                        }
                    }
                }
                for (int k = N - 1; k >= 0; k--)
                {
                    if (main_col[k] != k)
                    {
                        for (int j = 0; j <= N - 1; j++)
                        {
                            temp = P[k, j]; P[k, j] = P[main_col[k], j]; P[main_col[k], j] = temp;
                        }
                    }
                    if (main_row[k] != k)
                    {
                        for (int i = 0; i <= N - 1; i++)
                        {
                            temp = P[i, k]; P[i, k] = P[i, main_row[k]]; P[i, main_row[k]] = temp;
                        }
                    }
                }
            }
            return P;

        }
        /// <summary>
        /// 矩阵转置
        /// </summary>
        /// <param name="a">要转置的矩阵</param>
        /// <param name="m">行</param>
        /// <param name="n">列</param>
        /// <returns></returns>
        public static double[,] T(double[,] a, int m, int n)
        {
            double[,] b = new double[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    b[j, i] = a[i, j];
                }
            }
            return b;
        }
        /// <summary>
        /// 旋转矩阵
        /// </summary>
        /// <param name="phi">外方位元素数组</param>
        /// <returns>旋转矩阵</returns>
        public static double[,] xuanzhuanjuzhen(double[,] phi)
        {
            double[,] a = new double[3, 3];//旋转矩阵
            a[0, 0] = Math.Cos(phi[3, 0]) * Math.Cos(phi[5, 0]) - Math.Sin(phi[3, 0]) * Math.Sin(phi[4, 0]) * Math.Sin(phi[5, 0]);
            a[1, 0] = -1*Math.Cos(phi[3, 0]) * Math.Sin(phi[5, 0]) - Math.Sin(phi[3, 0]) * Math.Sin(phi[4, 0]) * Math.Cos(phi[5, 0]);
            a[2, 0] = -1 * Math.Sin(phi[3, 0]) * Math.Cos(phi[4, 0]);
            a[0, 1] = Math.Cos(phi[4, 0]) * Math.Sin(phi[5, 0]);
            a[1, 1] = Math.Cos(phi[4, 0]) * Math.Cos(phi[5, 0]);
            a[2, 1] = -1 * Math.Sin(phi[4, 0]);
            a[0, 2] = Math.Sin(phi[3, 0]) * Math.Cos(phi[5, 0]) + Math.Cos(phi[3, 0]) * Math.Sin(phi[4, 0]) * Math.Sin(phi[5, 0]);
            a[1, 2] = -1 * Math.Sin(phi[3, 0]) * Math.Sin(phi[5, 0]) + Math.Cos(phi[3, 0]) * Math.Sin(phi[4, 0]) * Math.Cos(phi[5, 0]);
            a[2, 2] = Math.Cos(phi[3, 0]) * Math.Cos(phi[4, 0]);
            return a;
        }
        /// <summary>
        /// 旋转矩阵
        /// </summary>
        /// <param name="phi"></param>
        /// <param name="w"></param>
        /// <param name="k"></param>
        /// <returns>旋转矩阵</returns>
        public static double[,] xuanzhuanjuzhen(double phi, double w, double k)

        {
            double[,] a = new double[3, 3];//旋转矩阵
            a[0, 0] = Math.Cos(phi) * Math.Cos(k) - Math.Sin(phi) * Math.Sin(w) * Math.Sin(k);
            a[1, 0] = -1 * Math.Cos(phi) * Math.Sin(k) - Math.Sin(phi) * Math.Sin(w) * Math.Cos(k);
            a[2, 0] = -1 * Math.Sin(phi) * Math.Cos(w);
            a[0, 1] = Math.Cos(w) * Math.Sin(k);
            a[1, 1] = Math.Cos(w) * Math.Cos(k);
            a[2, 1] = -1 * Math.Sin(w);
            a[0, 2] = Math.Sin(phi) * Math.Cos(k) + Math.Cos(phi) * Math.Sin(w) * Math.Sin(k);
            a[1, 2] = -1 * Math.Sin(phi) * Math.Sin(k) + Math.Cos(phi) * Math.Sin(w) * Math.Cos(k);
            a[2, 2] = Math.Cos(phi) * Math.Cos(w);
            return a;
        }
        /// <summary>
        /// 矩阵乘法a[]*b[]
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[,] MatrixMulti(double[,] a,double[,] b) 
		{
			int mm = a.GetLength(0),nn=a.GetLength(1),pp=b.GetLength(1);
			double[,] c = new double[mm,pp];
			for (int i = 0; i < mm; i++) 
			{
				for (int j = 0; j < pp; j++) 
				{
					c[i, j] = 0;
					for (int k = 0; k < nn; k++) 
					{
						c[i, j] += a[i, k] * b[k, j];
					}
				}
			}
			return c;
		}
        /// <summary>
        /// 矩阵减法a[]-b[]
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
		public static double[,] MatrixSubstract(double[,] a, double[,] b) 
		{
			int m = a.GetLength(0), n = a.GetLength(1);
			double[,] c = new double[m, n];
			for (int i = 0; i < m; i++) 
			{
				for (int j = 0; j < n; j++) 
				{
					c[i, j] = a[i, j] - b[i, j];
				}
			}
			return c;
		}
        /// <summary>
        /// 矩阵加法a[]+b[]
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[,] MatrixAdd(double[,] a, double[,] b) 
        {
            double[,] c = new double[a.GetLength(0), a.GetLength(1)];
            int counti = a.GetLength(0);
            int countj = a.GetLength(1);
            for (int i = 0; i < counti; i++) 
            {
                for (int j = 0; j < countj; j++) 
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }
        /// <summary>
        /// 数乘k*a[]
        /// </summary>
        /// <param name="k"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double[,] Multi(double k, double[,] a) 
        {
            int counti = a.GetLength(0);
            int countj = a.GetLength(1);
            double[,] c = new double[counti, countj];
            for (int i = 0; i < counti; i++) 
            {
                for (int j = 0; j < countj; j++) 
                {
                    c[i, j] = a[i, j] * k;
                }
            }
            return c;
        }
        
	}
    /// <summary>
    /// 前方交会后方交会
    /// </summary>
    /// 
    class JiaoHui
    {
        static double u = 0.006, f = 70.5, xm = 0, ym = 0.12;//相机参数
        static double m = 11310, n = 17310, l0, h0;
        /// <summary>
        /// 后方交会
        /// </summary>
        /// <param name="L_pixels">像平面坐标</param>
        /// <param name="points">地面点坐标</param>
        public static double[,] HouFangJiaoHui(List<pixel> L_pixels, List<Point> points)
        {
            double q = 0, k = 0, w = 0, XS0 = 0, YS0 = 0, ZS0 = 0;
            for (int i = 0; i < points.Count(); i++)
            {
                XS0 += points[i].X;
                YS0 += points[i].Y;
                ZS0 += points[i].Z;
            }
            XS0 /= points.Count();
            YS0 /= points.Count();
            ZS0 /= points.Count();

            double h = 3718;//航高3718
            double[,] phi = new double[6, 1];//存储外方位元素
            ZS0 += h;
            phi[0, 0] = XS0;
            phi[1, 0] = YS0;
            phi[2, 0] = ZS0;
            phi[3, 0] = q;
            phi[4, 0] = w;
            phi[5, 0] = k;


            double max = 100000000000;//迭代误差,初始值随便赋的


            while (max > 1e-6)
            {
                double[,] a;//旋转矩阵
                double[,] L_equation = new double[2 * points.Count(), 6];//系数A
                double[,] L_L = new double[2 * points.Count(), 1];//L
                double[] _x = new double[points.Count()];//共线方程近似解
                double[] _y = new double[points.Count()];//共线方程近似解
                double[] _z = new double[points.Count()];//共线方程近似解

                a = matrix.xuanzhuanjuzhen(phi);


                //近似坐标赋值（顾忌了像主点）
                for (int i = 0; i < points.Count(); i++)
                {
                    _z[i] = (a[2, 0] * (points[i].X - phi[0, 0]) + a[2, 1] * (points[i].Y - phi[1, 0]) + a[2, 2] * (points[i].Z - phi[2, 0]));
                    _x[i] = -f * (a[0, 0] * (points[i].X - phi[0, 0]) + a[0, 1] * (points[i].Y - phi[1, 0]) + a[0, 2] * (points[i].Z - phi[2, 0])) / _z[i];
                    _y[i] = -f * (a[1, 0] * (points[i].X - phi[0, 0]) + a[1, 1] * (points[i].Y - phi[1, 0]) + a[1, 2] * (points[i].Z - phi[2, 0])) / _z[i];
                }

                //系数阵赋值（抄的PPT20、22页上的，确认无误）
                for (int i = 0; i < points.Count(); i++)
                {

                    L_equation[2 * i, 0] = 1.0 / _z[i] * (a[0, 0] * f + a[2, 0] * L_pixels[i].x);
                    L_equation[2 * i, 1] = 1.0 / _z[i] * (a[0, 1] * f + a[2, 1] * L_pixels[i].x);
                    L_equation[2 * i, 2] = 1.0 / _z[i] * (a[0, 2] * f + a[2, 2] * L_pixels[i].x);

                    L_equation[2 * i, 3] = (L_pixels[i].y * Math.Sin(phi[4, 0])) - Math.Cos(phi[4, 0]) * ((L_pixels[i].x / f) * ((L_pixels[i].x * Math.Cos(phi[5, 0]))
                                             - (L_pixels[i].y * Math.Sin(phi[5, 0]))) + (f * Math.Cos(phi[5, 0])));
                    L_equation[2 * i, 4] = (-f * Math.Sin(phi[5, 0])) -
                                            (L_pixels[i].x / f) * (L_pixels[i].x * Math.Sin(phi[5, 0]) + L_pixels[i].y * Math.Cos(phi[5, 0]));
                    L_equation[2 * i, 5] = L_pixels[i].y;
                    L_equation[2 * i + 1, 0] = 1.0 / _z[i] * (a[1, 0] * f + a[2, 0] * L_pixels[i].y);
                    L_equation[2 * i + 1, 1] = 1.0 / _z[i] * (a[1, 1] * f + a[2, 1] * L_pixels[i].y);
                    L_equation[2 * i + 1, 2] = 1.0 / _z[i] * (a[1, 2] * f + a[2, 2] * L_pixels[i].y);
                    L_equation[2 * i + 1, 3] = -L_pixels[i].x * Math.Sin(phi[4, 0]) - (L_pixels[i].y / f *
                                                (L_pixels[i].x * Math.Cos(phi[5, 0]) - L_pixels[i].y * Math.Sin(phi[5, 0]))
                                                - f * Math.Sin(phi[5, 0])) * Math.Cos(phi[4, 0]);
                    L_equation[2 * i + 1, 4] = -f * Math.Cos(phi[5, 0]) - L_pixels[i].y / f *
                                                (L_pixels[i].x * Math.Sin(phi[5, 0]) +
                                                L_pixels[i].y * Math.Cos(phi[5, 0]));
                    L_equation[2 * i + 1, 5] = -L_pixels[i].x;
                    L_L[2 * i, 0] = (L_pixels[i].x - _x[i]);
                    L_L[2 * i + 1, 0] = (L_pixels[i].y - _y[i]);
                }

                //求解误差方程
                double[,] aT, ata, ata_1, ata_1at, result;
                aT = matrix.T(L_equation, 2 * points.Count(), 6);
                ata = matrix.MatrixMulti(aT, L_equation);
                ata_1 = matrix.juzhqn1(ata);
                ata_1at = matrix.MatrixMulti(ata_1, aT);
                result = matrix.MatrixMulti(ata_1at, L_L);


                //迭代标准
                max = Math.Abs(result[3, 0]);
                //改正
                for (int i = 0; i < 6; i++)
                {
                    phi[i, 0] += result[i, 0];
                }


                for (int i = 0; i < 6; i++)
                {
                    if (max < Math.Abs(result[i, 0]))
                    {
                        max = Math.Abs(result[i, 0]);
                    }

                }

            }
            return phi;
        }
        /// <summary>
        /// 前方交会
        /// </summary>
        /// <param name="c">左像外方位元素</param>
        /// <param name="d">右像外方位元素</param>
        /// <param name="xyf1">左像像空间坐标</param>
        /// <param name="xyf2">右像像空间坐标</param>
        /// <returns>待求点坐标</returns>
        public static double[,] qianfangjiaohui(double[,] c, double[,] d, double[,] xyf1, double[,] xyf2)
        {
            double Bu = d[0, 0] - c[0, 0];
            double Bv = d[1, 0] - c[1, 0];
            double Bw = d[2, 0] - c[2, 0];
            double N1, N2;
            double[,] u1v1w1, u2v2w2;
            double[,] left_R, right_R;
            int length = xyf1.GetLength(1);
            double[,] XAYAZA = new double[3, length];

            for (int i = 0; i < length; i++)
            {
                double[,] xyz1 = new double[3, 1];
                double[,] xyz2 = new double[3, 1];
                for (int j = 0; j < 3; j++)
                {
                    xyz1[0, 0] = xyf1[0, i];
                    xyz1[1, 0] = xyf1[1, i];
                    xyz1[2, 0] = xyf1[2, i];
                    xyz2[0, 0] = xyf2[0, i];
                    xyz2[1, 0] = xyf2[1, i];
                    xyz2[2, 0] = xyf2[2, i];
                }
                left_R = matrix.T(matrix.xuanzhuanjuzhen(c), 3, 3);
                right_R = matrix.T(matrix.xuanzhuanjuzhen(d), 3, 3);

                u1v1w1 = matrix.MatrixMulti(left_R, xyz1);
                u2v2w2 = matrix.MatrixMulti(right_R, xyz2);
                N1 = (Bu * u2v2w2[2, 0] - Bw * u2v2w2[0, 0])
                    / (u1v1w1[0, 0] * u2v2w2[2, 0] - u2v2w2[0, 0] * u1v1w1[2, 0]);
                N2 = (Bu * u1v1w1[2, 0] - Bw * u1v1w1[0, 0])
                    / (u1v1w1[0, 0] * u2v2w2[2, 0] - u2v2w2[0, 0] * u1v1w1[2, 0]);
                XAYAZA[0, i] = c[0, 0] + N1 * u1v1w1[0, 0];
                XAYAZA[1, i] = ((c[1, 0] + N1 * u1v1w1[1, 0])+(d[1, 0] + N2 * u2v2w2[1, 0]))/2;
                XAYAZA[2, i] = c[2, 0] + N1 * u1v1w1[2, 0];

            }
            return XAYAZA;
        }

    }
    /// <summary>
    /// 相对定向绝对定向
    /// </summary>
    public class DingXiang 
    {
        static double u = 0.006, f = 70.5, xm = 0, ym = 0.12;//相机参数
        static double m = 11310, n = 17310, l0, h0;
        /// <summary>
        /// 存放比例系数、旋转矩阵、平移参数
        /// </summary>
        public struct TwoDouble 
        {
            public TwoDouble(double[,] R, double[,] xx,double r) 
            {
                this.R = R;
                this.xx = xx;
                this.r = r;
            }
            public double r;
            public double[,] R;
            public double[,] xx;
            
        }
        /// <summary>
        /// 相对定向
        /// </summary>
        /// <param name="l_SamePoint">左同名像点</param>
        /// <param name="r_SamePoint">右同名像点</param>
        /// <returns>相对定向元素</returns>
        public static double[,] XiangDuiDIngXiang(double[,] l_SamePoint, double[,] r_SamePoint) 
        {
            double phi1 = 0, w1 = 0, k1 = 0, phi2 = 0, w2 = 0, k2 = 0;
            double[,] left, right, dingxiang, u1v1w1, u2v2w2, Xishu, Q;
            dingxiang = new double[6, 1];
            double wucha = 1000;
            int count = l_SamePoint.GetLength(1);
            while (wucha > 1e-6)
            {

                left = matrix.T(matrix.xuanzhuanjuzhen(phi1, w1, k1), 3, 3);
                right = matrix.T(matrix.xuanzhuanjuzhen(phi2, w2, k2), 3, 3);
                u1v1w1 = matrix.MatrixMulti(left, l_SamePoint);
                u2v2w2 = matrix.MatrixMulti(right, r_SamePoint);
                Xishu = new double[count, 5];
                Q = new double[count, 1];
                for (int j = 0; j < count; j++)
                {
                    Xishu[j, 0] = u1v1w1[0, j] * u2v2w2[1, j] / u2v2w2[2, j];
                    Xishu[j, 1] = -u2v2w2[0, j] * u1v1w1[1, j] / u1v1w1[2, j];
                    Xishu[j, 2] = f * (1 + u1v1w1[1, j] * u2v2w2[1, j] / (u1v1w1[2, j] * u2v2w2[2, j]));
                    Xishu[j, 3] = -u1v1w1[0, j];
                    Xishu[j, 4] = u2v2w2[0, j];
                    Q[j, 0] = -f * u1v1w1[1, j] / u1v1w1[2, j] + f * u2v2w2[1, j] / u2v2w2[2, j];
                   

                }
                double[,] AT, ATA, ATA_1, ATA_1AT, result;
                AT = matrix.T(Xishu, count, 5);
                ATA = matrix.MatrixMulti(AT, Xishu);
                ATA_1 = matrix.juzhqn1(ATA);
                ATA_1AT = matrix.MatrixMulti(ATA_1, AT);
                result = matrix.MatrixMulti(ATA_1AT, Q);
                phi1 += result[0, 0];
                phi2 += result[1, 0];
                w2 += result[2, 0];
                k1 += result[3, 0];
                k2 += result[4, 0];
                dingxiang[0, 0] = phi1;
                dingxiang[1, 0] = w1;
                dingxiang[2, 0] = k1;
                dingxiang[3, 0] = phi2;
                dingxiang[4, 0] = w2;
                dingxiang[5, 0] = k2;
                wucha = result[0, 0];
                for (int j = 0; j < 5; j++)
                {
                    if (wucha < result[j, 0])
                    {
                        wucha = result[j, 0];
                    }
                }
            }
            return dingxiang;
        }
        public static double[,] qianfangjiaohui(double[,] c, double[,] d, double[,] xyf1, double[,] xyf2)
        {
            double Bu = d[0, 0] - c[0, 0];
            double Bv = d[1, 0] - c[1, 0];
            double Bw = d[2, 0] - c[2, 0];
            double N1, N2;
            double[,] u1v1w1, u2v2w2;
            double[,] left_R, right_R;
            int length = xyf1.GetLength(1);
            double[,] XAYAZA = new double[3, length];

            for (int i = 0; i < length; i++)
            {
                double[,] xyz1 = new double[3, 1];
                double[,] xyz2 = new double[3, 1];
                for (int j = 0; j < 3; j++)
                {
                    xyz1[0, 0] = xyf1[0, i];
                    xyz1[1, 0] = xyf1[1, i];
                    xyz1[2, 0] = xyf1[2, i];
                    xyz2[0, 0] = xyf2[0, i];
                    xyz2[1, 0] = xyf2[1, i];
                    xyz2[2, 0] = xyf2[2, i];
                }
                left_R = matrix.T(matrix.xuanzhuanjuzhen(c), 3, 3);
                right_R = matrix.T(matrix.xuanzhuanjuzhen(d), 3, 3);

                u1v1w1 = matrix.MatrixMulti(left_R, xyz1);
                u2v2w2 = matrix.MatrixMulti(right_R, xyz2);
                N1 = (Bu * u2v2w2[2, 0] - Bw * u2v2w2[0, 0])
                    / (u1v1w1[0, 0] * u2v2w2[2, 0] - u2v2w2[0, 0] * u1v1w1[2, 0]);
                N2 = (Bu * u1v1w1[2, 0] - Bw * u1v1w1[0, 0])
                    / (u1v1w1[0, 0] * u2v2w2[2, 0] - u2v2w2[0, 0] * u1v1w1[2, 0]);
                XAYAZA[0, i] = N1 * u1v1w1[0, 0];
                XAYAZA[1, i] = 1/2.0*( N1 * u1v1w1[1, 0]+N2*u2v2w2[1,0]+Bv);
                XAYAZA[2, i] = N1 * u1v1w1[2, 0];

            }
            return XAYAZA;
        }
        /// <summary>
        /// 绝对定向
        /// </summary>
        /// <param name="l_jueduidinxgiang">左同名像点（给个空数组）</param>
        /// <param name="r_jueduidingxiang">右同名像点（给个空数组）</param>
        /// <param name="left">左像相对定向结果</param>
        /// <param name="right">右像相对定向结果</param>
        /// <param name="L_pixels">左同名像点</param>
        /// <param name="R_pixels">右同名像点</param>
        /// <param name="points">地面点</param>
        /// <returns>比例系数、旋转矩阵、平移参数</returns>
        public static TwoDouble jueduidingxiang(double [,] l_jueduidinxgiang,double[,] r_jueduidingxiang,double[,]left,double[,]right,List<pixel> L_pixels, List<pixel> R_pixels,List<Point>points) 
        {
            double[,] modelPoint;//模型点
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
            modelPoint = JiaoHui.qianfangjiaohui(left, right, l_jueduidinxgiang, r_jueduidingxiang);//前方交会计算模型点坐标           
            double r,_x = 0, _y = 0, _z = 0, _X = 0, _Y = 0, _Z = 0;//重心化，小写用于重心化模型点坐标，大写用于重心化地面点坐标
            int count = modelPoint.GetLength(1);//控制点数量
            //重心化
            for (int i = 0; i < count; i++)
            {
                _x += modelPoint[0, i];
                _y += modelPoint[1, i];
                _z += modelPoint[2, i];
                _X += pointxyz[0, i];
                _Y += pointxyz[1, i];
                _Z += pointxyz[2, i];

            }
            _x /= count;
            _y /= count;
            _z /= count;
            _X /= count;
            _Y /= count;
            _Z /= count;
            for (int i = 0; i < count; i++)
            {
                modelPoint[0, i] -= _x;
                modelPoint[1, i] -= _y;
                modelPoint[2, i] -= _z;
                pointxyz[0, i] -= _X;
                pointxyz[1, i] -= _Y;
                pointxyz[2, i] -= _Z;
            }

            //重心化完毕

            double[,] R, S, I;//旋转矩阵
            S = new double[3, 3];
            I = new double[3, 3];
            I[0, 0] = I[1, 1] = I[2, 2] = 1;


            double[,] L = new double[3 * count, 1];//3n*1常数阵
            double[,] A = new double[3 * count, 3];//3n*3系数阵
            double[,] XG = new double[3, 1];
            double[,] xg = new double[3, 1];
            xg[0, 0] = _x;
            xg[1, 0] = _y;
            xg[2, 0] = _z;
            XG[0, 0] = _X;
            XG[1, 0] = _Y;
            XG[2, 0] = _Z;
            double r1 = 0, r3 = 0;
            for (int i = 0; i < count; i++)
            {
                //r1 += Math.Sqrt(modelPoint[0, i] * modelPoint[0, i] + modelPoint[1, i] * modelPoint[1, i] + modelPoint[2, i] * modelPoint[2, i])
                //* Math.Sqrt(pointxyz[0, i] * pointxyz[0, i] + pointxyz[1, i] * pointxyz[1, i] + pointxyz[2, i] * pointxyz[2, i]);
                //r3 += modelPoint[0, i] * modelPoint[0, i] + modelPoint[1, i] * modelPoint[1, i] + modelPoint[2, i] * modelPoint[2, i];
                r1 += Math.Sqrt((modelPoint[0, (i + 1) % count] - modelPoint[0, (i) % count]) * (modelPoint[0, (i + 1) % count] - modelPoint[0, (i) % count])
                    + (modelPoint[1, (i + 1) % count] - modelPoint[1, (i) % count]) * (modelPoint[1, (i + 1) % count] - modelPoint[1, (i) % count])
                    + (modelPoint[2, (i + 1) % count] - modelPoint[2, (i) % count]) * (modelPoint[2, (i + 1) % count] - modelPoint[2, (i) % count])
                    );
                r3+= Math.Sqrt((pointxyz[0, (i + 1) % count] - pointxyz[0, (i) % count]) * (pointxyz[0, (i + 1) % count] - pointxyz[0, (i) % count])
                    + (pointxyz[1, (i + 1) % count] - pointxyz[1, (i) % count]) * (pointxyz[1, (i + 1) % count] - pointxyz[1, (i) % count])
                    + (pointxyz[2, (i + 1) % count] - pointxyz[2, (i) % count]) * (pointxyz[2, (i + 1) % count] - pointxyz[2, (i) % count])
                    );
            }
            r = r3 / r1;
            for (int i = 0; i < count; i++)
            {

                A[3 * i, 1] = -(pointxyz[2, i] + r * modelPoint[2, i]);
                A[3 * i, 2] = -(pointxyz[1, i] + r * modelPoint[1, i]);
                A[3 * i + 1, 0] = -(pointxyz[2, i] + r * modelPoint[2, i]);
                A[3 * i + 1, 2] = (pointxyz[0, i] + r * modelPoint[0, i]);
                A[3 * i + 2, 0] = (pointxyz[1, i] + r * modelPoint[1, i]);
                A[3 * i + 2, 1] = (pointxyz[0, i] + r * modelPoint[0, i]);
                L[3 * i, 0] = pointxyz[0, i] - r * modelPoint[0, i];
                L[3 * i + 1, 0] = pointxyz[1, i] - r * modelPoint[1, i];
                L[3 * i + 2, 0] = pointxyz[2, i] - r * modelPoint[2, i];
            }
            //本段在后方交汇用过，确认无误
            double[,] aT, ata, ata_1, ata_1at, result;
            aT = matrix.T(A, 3 * count, 3);//AT
            ata = matrix.MatrixMulti(aT, A);//AT*A
            ata_1 = matrix.juzhqn1(ata);//（AT*A）-1
            ata_1at = matrix.MatrixMulti(ata_1, aT);//（AT*A）-1*AT
            result = matrix.MatrixMulti(ata_1at, L);//（AT*A）-1*A*L
            S[0, 1] = -result[2, 0];
            S[1, 0] = result[2, 0];
            S[0, 2] = -result[1, 0];
            S[2, 0] = result[1, 0];
            S[2, 1] = result[0, 0];
            S[1, 2] = -result[0, 0];
            R = matrix.T(matrix.MatrixMulti(matrix.MatrixAdd(I, S),matrix.juzhqn1(matrix.MatrixSubstract(I, S)) ), 3, 3);
            double[,] model = matrix.MatrixMulti(R, modelPoint);
            double[,] xx = matrix.MatrixSubstract(XG,  matrix.Multi(1/r,matrix.MatrixMulti(R, xg)));
            //double[,] xyz = new double[3, count];
            //for (int i = 0; i < count; i++)
            //{
            //    xyz[0, i] = r * model[0, i] + xx[0, 0];
            //    xyz[1, i] = r * model[1, i] + xx[1, 0];
            //    xyz[2, i] = r * model[2, i] + xx[2, 0];
            //}
            TwoDouble two = new TwoDouble(R,xx,r);
            return two;

        }
        public static double[,] jueduidingxiang(double[,]modelPoint,double[,]pointxyz, double[,] l_jueduidinxgiang, double[,] r_jueduidingxiang,double[,]left,double[,]right,ref double r11) 
        {
            double r = 1, _x = 0, _y = 0, _z = 0, _X = 0, _Y = 0, _Z = 0;//重心化，小写用于重心化模型点坐标，大写用于重心化地面点坐标
            modelPoint = JiaoHui.qianfangjiaohui(left, right, l_jueduidinxgiang, r_jueduidingxiang);//前方交会计算模型点坐标 
            int count = modelPoint.GetLength(1);//控制点数量
            double r1 = 0, r3 = 0;
            for (int i = 0; i < count; i++)
            {
                r1 += Math.Sqrt((modelPoint[0, (i + 1) % count] - modelPoint[0, (i) % count]) * (modelPoint[0, (i + 1) % count] - modelPoint[0, (i) % count])
                   + (modelPoint[1, (i + 1) % count] - modelPoint[1, (i) % count]) * (modelPoint[1, (i + 1) % count] - modelPoint[1, (i) % count])
                   + (modelPoint[2, (i + 1) % count] - modelPoint[2, (i) % count]) * (modelPoint[2, (i + 1) % count] - modelPoint[2, (i) % count])
                   );
                r3 += Math.Sqrt((pointxyz[0, (i + 1) % count] - pointxyz[0, (i) % count]) * (pointxyz[0, (i + 1) % count] - pointxyz[0, (i) % count])
                    + (pointxyz[1, (i + 1) % count] - pointxyz[1, (i) % count]) * (pointxyz[1, (i + 1) % count] - pointxyz[1, (i) % count])
                    + (pointxyz[2, (i + 1) % count] - pointxyz[2, (i) % count]) * (pointxyz[2, (i + 1) % count] - pointxyz[2, (i) % count])
                    );
            }
            r11 = r3 / r1;
            for (int i = 0; i < modelPoint.GetLength(1); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    modelPoint[j, i] *= r11;
                }
            }
            //重心化
            for (int i = 0; i < count; i++)
            {
                _x += modelPoint[0, i];
                _y += modelPoint[1, i];
                _z += modelPoint[2, i];
                _X += pointxyz[0, i];
                _Y += pointxyz[1, i];
                _Z += pointxyz[2, i];

            }
            _x /= count;
            _y /= count;
            _z /= count;
            _X /= count;
            _Y /= count;
            _Z /= count;
            for (int i = 0; i < count; i++)
            {
                modelPoint[0, i] -= _x;
                modelPoint[1, i] -= _y;
                modelPoint[2, i] -= _z;
                pointxyz[0, i] -= _X;
                pointxyz[1, i] -= _Y;
                pointxyz[2, i] -= _Z;
            }
            double phi = 0, w = 0, k = 0;
            double[,] R;
            double[,] A = new double[3 * count, 4];
            double[,] L = new double[3 * count, 1];
            //重心化完毕
            double wucha = 1000;
            while (wucha > 1e-6)
            {
                
                R = matrix.T(matrix.xuanzhuanjuzhen(phi, w, k), 3, 3);/**/
                for (int i = 0; i < count; i++)
                {
                    //与书上一致

                    A[3 * i, 0] = modelPoint[0, i];
                    A[3 * i, 1] = -modelPoint[2, i];
                    A[3 * i, 3] = -modelPoint[1, i];
                    A[3 * i + 1, 0] = modelPoint[1, i];
                    A[3 * i + 1, 2] = -modelPoint[2, i];
                    A[3 * i + 1, 3] = modelPoint[0, i];
                    A[3 * i + 2, 0] = modelPoint[2, i];
                    A[3 * i + 2, 1] = modelPoint[0, i];
                    A[3 * i + 2, 2] = modelPoint[1, i];
                }
                double[,] xyz = new double[3, 1];
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        xyz[j, 0] = modelPoint[j, i];
                    }

                    double[,] R_UVW = matrix.MatrixMulti(R, xyz);
                    for (int j = 0; j < 3; j++)
                    {

                        L[3 * i + j, 0] = pointxyz[j, i] - r * R_UVW[j, 0];

                    }
                }
                double[,] aT, ata, ata_1, ata_1at, result;
                aT = matrix.T(A, 3 * count, 4);//AT
                ata = matrix.MatrixMulti(aT, A);//AT*A
                ata_1 = matrix.juzhqn1(ata);//（AT*A）-1
                ata_1at = matrix.MatrixMulti(ata_1, aT);//（AT*A）-1*AT
                result = matrix.MatrixMulti(ata_1at, L);//（AT*A）-1*A*L

                r += result[0, 0];
                phi += result[1, 0];
                w += result[2, 0];
                k += result[3, 0];
                wucha = Math.Abs(result[1, 0]);
                for (int i = 0; i < 4; i++)
                {
                    if (Math.Abs(wucha) < Math.Abs(result[i, 0]))
                    {
                        wucha = Math.Abs(result[i, 0]);
                    }
                }
            }
           
            double[,] dingxiang = new double[10, 1] { { _X }, { _Y }, { _Z }, { r }, { phi }, { w }, { k }, { _x }, { _y }, { _z } };
            return dingxiang;
        }
    }

    /// <summary>
    /// 面积和周长
    /// </summary>
    class areaAndCircum 
    {
        /// <summary>
        /// 面积
        /// </summary>
        /// <param name="a">点坐标</param>
        /// <returns>面积</returns>
        public static double area(double[,]a) 
        {       
        
            double sum = 0;
            int n = a.GetLength(1);
            for (int i = 0; i < n; i++) 
            {
                sum += (a[0, (i + 1) % n] - a[0, i % n]) * (a[1, (i + 1) % n] + a[1, i % n]) * 1 / 2.0;
                
            }
            return Math.Abs(sum);
        }
        /// <summary>
        /// 周长
        /// </summary>
        /// <param name="a">点坐标</param>
        /// <returns>周长</returns>
        public static double Circum(double[,] a)
        {
            double circum = 0;
            int n = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                circum += Math.Sqrt((a[0, (i + 1) % n] - a[0, i % n]) * (a[0, (i + 1) % n] - a[0, i % n])+
                    (a[1, (i + 1) % n] - a[1, i % n]) * (a[1, (i + 1) % n] - a[1, i % n])
                    +  (a[2, (i + 1) % n] - a[2, i % n]) * (a[2, (i + 1) % n] - a[2, i % n])) ;
            }
            return Math.Abs(circum);
        }
    }
}
