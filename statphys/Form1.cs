using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace statphys
{
    public partial class Form1 : Form
    {
        List<double> points_x = new List<double> { 0 };
        List<double> delta_arr = new List<double> { };
        Random rnd;
        const bool DEBUG = true;
        double mean = 0, var = 100;

        public Form1()
        {
            InitializeComponent();

            set_NumericUpDown();

            //init Random gen U(0, 1)
            rnd = new Random(12);
            //init debug logger
            Trace.Listeners.Add(new TextWriterTraceListener("debugOut.log"));
            Trace.AutoFlush = true;
        }

        // Start timer
        private void button_start_timer_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button_stop_timer_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            get_new_iteration();
        }

        // Manually sampling
        private void button_update_Click(object sender, EventArgs e)
        {
            get_new_iteration();
        }

        private void numericUpDownMean_ValueChanged(object sender, EventArgs e)
        {
            reset();
            mean = (double)numericUpDownMean.Value;
        }

        private void numericUpDownVar_ValueChanged(object sender, EventArgs e)
        {
            reset();
            var = (double)numericUpDownVar.Value;
        }

        void get_new_iteration()
        {
            get_new_sample();
            pictureBox1.Refresh();
            update_mean_var_labels();
        }

        void get_new_sample()
        {
            double delta = sample_delta();
            double cur_x = points_x.Last() + delta;
            points_x.Add(cur_x);
            delta_arr.Add(delta);
            update_label(cur_x, delta);

            if (DEBUG)
            {
                Trace.WriteLine(delta.ToString(CultureInfo.GetCultureInfo("en-GB")));
            }
        }

        void update_label(double x, double delta)
        {
            label1.Text = $"x = {x} delta = {delta}";
            label1.Refresh();
        }

        void update_mean_var_labels()
        {
            double mean = 0, var = 0;
            get_mean_var(ref mean, ref var, delta_arr);

            label_mean.Text = $"Mean = {mean}";
            label_var.Text = $"Variance = {var}";
            label_count.Text = $"Count = {delta_arr.Count()}";

            label_var.Refresh();
            label_mean.Refresh();
            label_count.Refresh();
        }

        double sample_delta()
        {
            double val = rnd.NextDouble();

            const double eps = 0.00001;
            const int n = 4000;

            // Find cdf(delta) = val
            double sigma = Math.Sqrt(var);
            double a = -10*sigma, b = 10*sigma;

            Func<double, double> normal = x => normal_dist(x, mean, Math.Sqrt(var));
            Func<double, double> get_cdf = x => integrate_numeric(normal, a, x, n);
            double delta = find_root(get_cdf, val, a, b, n, eps);

            // Check cdf(delta) == val
            Debug.Assert(Math.Abs(val - integrate_numeric(normal, a, delta, n*10)) < eps);
            return delta;
        }

        double normal_dist(double x, double m, double std)
        {
            double exponent = (x - m) * (x - m) / (std * std);
            return 1.0 / (std * Math.Sqrt(2 * Math.PI)) * Math.Exp(-exponent / 2.0);
        }

        // Paint line and points
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Line
            int HIEGHT_2 = pictureBox1.Size.Height / 2, WIDTH_2 = pictureBox1.Size.Width / 2;
            int POINT_HIEGHT = 10, POINT_WIDTH = 10;
            e.Graphics.DrawLine(
                new Pen(Color.Red, 2f),
                new Point(0, HIEGHT_2),
                new Point(pictureBox1.Size.Width, HIEGHT_2));

            // Points
            SolidBrush commonBrush = new SolidBrush(Color.Orange);
            SolidBrush lastBrush = new SolidBrush(Color.Blue);
            for (int i = 0; i < points_x.Count; ++i)
            {
                int x = Convert.ToInt32(points_x[i]);
                SolidBrush brush = i == points_x.Count - 1 ? lastBrush : commonBrush;
                e.Graphics.FillEllipse(brush, WIDTH_2 + x, HIEGHT_2 - POINT_HIEGHT / 2, POINT_WIDTH, POINT_HIEGHT);
            }
        }

        // Test numeric methods
        private void button_numeric_methods_Click(object sender, EventArgs e)
        {
            test_integrator();
            test_root();
        }

        // Test N sampling from distrubition;
        // out => statphys\statphys\bin\Debug\net6.0-windows\debugOut.log
        private void button3_Click(object sender, EventArgs e)
        {
            test_sampling();
        }

        // Reset programm
        private void button_reset_Click(object sender, EventArgs e)
        {
            reset();

        }

        void reset()
        {
            timer1.Stop();
            points_x = new List<double> { 0 };
            delta_arr = new List<double> { };

            update_label(0, 0);
            pictureBox1.Refresh();
            update_mean_var_labels();
        }

        // Numeric find root
        // f(x) = y;
        // f'(x) >= 0;
        // x in [a, b];
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

        // Numeric intregral
        // integral{b}{a}f(x)dx = ...
        double integrate_numeric(Func<double, double> f, double a, double b, int n)
        {
            double h = (b - a) / n;
            double S = 0;
            for (int i = 0; i < n; ++i)
            {
                double x1 = a + i * h;
                double x2 = a + (i + 1) * h;
                // Simpson's rule https://habr.com/ru/post/479202/
                S += h / 6.0 * (f(x1) + 4.0 * f((x1 + x2) / 2) + f(x2));
            }
            return S;
        }

        void get_mean_var(ref double mean, ref double var, List<double> arr)
        {
            if(arr.Count() == 0)
            {
                mean = 0;
                var = 0;
                return;
            }
            mean = arr.Average();
            var = get_var(arr, mean);
        }

        // Calculate var
        double get_var(List<double> arr, double mean)
        {
            return arr.Sum(x => (x - mean) * (x - mean)) / arr.Count();
        }

        // Set property NumercicUpDown mean var
        void set_NumericUpDown()
        {
            this.numericUpDownMean.Maximum = 100;
            this.numericUpDownMean.Minimum = -100;
            this.numericUpDownMean.ThousandsSeparator = true;
            this.numericUpDownMean.DecimalPlaces = 1;
            this.numericUpDownMean.Increment = new decimal(0.1);

            this.numericUpDownVar.Maximum = 100;
            this.numericUpDownVar.Minimum = 1;
            this.numericUpDownVar.ThousandsSeparator = true;
            this.numericUpDownVar.DecimalPlaces = 1;
            this.numericUpDownVar.Increment = new decimal(0.1);
        }

        // Test numeric root f(x) = y;
        void test_root()
        {

            Func<double, double> g1 = x => 1 - Math.Exp(-x);
            Func<double, double> g2 = x => -(Math.Sin(x) + Math.Cos(x));
            Func<double, double> g3 = x => Math.Exp(x * x);

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

        // Test numeric integral
        void test_integrator()
        {
            Func<double, double> f1 = x => x;
            Func<double, double> f2 = x => x * 2 + x;
            Func<double, double> f3 = x => Math.Sin(x) * Math.Exp(-x) + Math.Cos(x);

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

        //sample test
        void test_sampling()
        {

            const int N = 1000;
            List<double> arr = new List<double> { };
            for (int i = 0; i < N; ++i)
            {
                arr.Add(sample_delta());
            }
            for (int i = 0; i < arr.Count(); ++i)
            {
                Trace.WriteLine(arr[i].ToString(CultureInfo.GetCultureInfo("en-GB")));
            }
        }
    }
}