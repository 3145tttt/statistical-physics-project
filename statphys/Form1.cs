using System.Diagnostics;
using System.Numerics;

namespace statphys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            get_new_sample();
            pictureBox1.Refresh();
        }

        int x = 0;
        private void button_update_Click(object sender, EventArgs e)
        {
            get_new_sample();
            pictureBox1.Refresh();
        }

        void get_new_sample()
        {
            int delta = sample_delta();
            x += delta;
            points_x.Add(x);
            label1.Text = $"x = {x} delta = {delta}";
            label1.Refresh();
        }
        List<int> points_x = new List<int>{0};
        int sample_delta()
        {
            double mean = 0, stdDev = 10;
            Random rand = new Random(); //reuse this if you are generating many
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal =
                mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
            Console.WriteLine(randNormal);
            return Convert.ToInt32(Math.Round(randNormal));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int HIEGHT_2 = pictureBox1.Size.Height / 2, WIDTH_2 = pictureBox1.Size.Width / 2;
            int POINT_HIEGHT = 10, POINT_WIDTH = 10;
            e.Graphics.DrawLine(
                new Pen(Color.Red, 2f),
                new Point(0, HIEGHT_2),
                new Point(pictureBox1.Size.Width, HIEGHT_2));
            SolidBrush commonBrush = new SolidBrush(Color.Orange);
            SolidBrush lastBrush = new SolidBrush(Color.Blue);

            for (int i = 0; i < points_x.Count - 1; ++i)
            {
                e.Graphics.FillEllipse(commonBrush,
                WIDTH_2 + points_x[i], HIEGHT_2 - POINT_HIEGHT / 2, POINT_WIDTH, POINT_HIEGHT);
            }
            e.Graphics.FillEllipse(lastBrush,
            WIDTH_2 + points_x.Last(), HIEGHT_2 - POINT_HIEGHT / 2, POINT_WIDTH, POINT_HIEGHT);
        }

        //Численное нахождение корня и тесты
        double find_root(Func<double, double> f, double y, double a, double b, int n, double eps)
        {
            double l = a, r = b;
            double x = (l + r) / 2;

            for(int i = 0; i < n; ++i)
            {
                double x_prev = x;
                if(f(x) > y)
                {
                    r = x;
                } else if(f(x) < y)
                {
                    l = x;
                } else
                {
                    return x;
                }
                x = (l + r) / 2;
                if(Math.Abs(x - x_prev) < eps)
                {
                    return x;
                }
            }

            return x;
        }

        void test_root()
        {
            double r1 = find_root(g1, 0.2, 0.1, 100, 1000, 0.000001);
            double r2 = find_root(g2, 0.2, 1, 3, 1000, 0.000001);
            double r3 = find_root(g3, 10, 0.1, 100, 1000, 0.000001);
            const double x1 = 0.22314355131420;
            const double x2 = 2.49809;
            const double x3 = 1.5174271293;
            const double eps = 0.00001;
            Debug.Assert(Math.Abs(x1 - r1) < eps);
            Debug.Assert(Math.Abs(x2 - r2) < eps);
            Debug.Assert(Math.Abs(x3 - r3) < eps);
        }

        double g1(double x)
        {
            return 1 - Math.Exp(-x);
        }

        double g2(double x)
        {
            return -(Math.Sin(x) + Math.Cos(x));
        }
        double g3(double x)
        {
            return Math.Exp(x*x);
        }

        //Численное интегрирование и тесты
        double integrate_numeric(Func<double, double> f, double a, double b, int n)
        {
            double h = (b - a) / n;
            double S = 0;
            for (int i = 0; i < n; ++i)
            {
                double x1 = a + i * h;
                double x2 = a + (i + 1) * h;
                // Метод Симпсона https://habr.com/ru/post/479202/
                S += h / 6.0 * (f(x1) + 4.0 * f((x1 + x2) / 2) + f(x2));
            }
            return S;
        }

        void test_integrator()
        {
            double r1 = integrate_numeric(f1, -0.5, 4, 1000);
            double r2 = integrate_numeric(f2, -0.5, 4, 1000);
            double r3 = integrate_numeric(f3, -0.5, 4, 1000);
            const double S1 = 7.875;
            const double S2 = 23.625;
            const double S3 = 0.06376463084945965;
            const double eps = 0.00001;
            Debug.Assert(Math.Abs(S1 - r1) < eps);
            Debug.Assert(Math.Abs(S2 - r2) < eps);
            Debug.Assert(Math.Abs(S3 - r3) < eps);
        }

        double f1(double x)
        {
            return x;
        }

        double f2(double x)
        {
            return x * 2 + x;
        }

        double f3(double x)
        {
            return Math.Sin(x) * Math.Exp(-x) + Math.Cos(x);
        }

        //sample test
        void test_sampling()
        {
            const int N = 500;
            List<double> arr = new List<double> { };
            for(int i = 0; i < N; ++i)
            {
                arr.Add(sample_delta());
            }
            for (int i = 0; i < arr.Count(); ++i)
            {
                Debug.Write($"{arr[i]}, ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            test_integrator();
            test_root();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            test_sampling();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}