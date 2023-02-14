using MathNet.Numerics.Distributions;
using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;
using static ScottPlot.Plottable.PopulationPlot;
using static System.Net.Mime.MediaTypeNames;

namespace statphys
{
    public partial class Form1 : Form
    {
        List<double> points_x = new() { 0 };
        List<double> delta_arr = new() { };
        const bool DEBUG = false;
        double par1 = 40, par2 = 30;

        RandomGenerator? gen;
        readonly NumericMethods calc = new();
        List<double> mean_list = new();
        List<double> var_list = new();
        List<double> period_list = new();

        string cur_dist = "norm";

        Dictionary<string, Dictionary<string, double>> dist_params = new();
        Dictionary<string, Dictionary<string, string>> dist_params_names = new();

        Form2 par_;

        public Form1(Form2 parent)
        {

            InitializeComponent();

            par_ = parent;
            /*FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;*/

            init_dict();
            set_NumericUpDown();

            List<string> dist_list = new ();
            dist_list.Add("Нормальное");
            // dist_list.Add("Экспоненциальное");
            dist_list.Add("Гамма");
            dist_list.Add("Парето");
            dist_list.Add("Вейбулла");
            dist_list.Add("Пуассона");
            dist_list.Add("Бернулли");
            comboBox1.DataSource = dist_list;
            comboBox1.SelectedIndex = 0;
            timer1.Interval = 500;
            this.freqUpDown.Value = 500;
            reset();

            //init debug logger
            Trace.Listeners.Add(new TextWriterTraceListener("debugOut.log"));
            Trace.AutoFlush = true;

            formsPlot1.Plot.Title("Среднее", size: 26);
            formsPlot2.Plot.Title("Дисперсия", size: 26);
            formsPlot4.Plot.Title("Распределение", size: 26);
            formsPlot5.Plot.Title("Периодичность", size: 26);


        }

        // Start timer
        private void button_start_timer_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        // Stop timer
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
            par1 = (double)numericUpDownMean.Value;
            reset();
        }

        private void numericUpDownVar_ValueChanged(object sender, EventArgs e)
        {
            par2 = (double)numericUpDownVar.Value;
            reset();
        }

        private void freqUpDownValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int) freqUpDown.Value;
            reset();
        }

        void get_new_iteration()
        {
            get_new_sample();
            pictureBox1.Refresh();
            add_mean_var();
            add_period();

            update_labels(
                points_x.Last(),
                delta_arr.Last(),
                mean_list.Last(),
                var_list.Last(),
                period_list.Last(),
                points_x.Count()
                );

            if (delta_arr.Count() > 3)
            {
                update_plot();
                if (delta_arr.Count() % 10 == 0)
                {
                    plot_dist();
                }
            }
            int lim = 10000;
            int C = 5000;
            if(delta_arr.Count() > lim)
            {
                delta_arr.RemoveRange(0, C);
                points_x.RemoveRange(0, C);
                mean_list.RemoveRange(0, C);
                var_list.RemoveRange(0, C);
                period_list.RemoveRange(0, C);
            }
        }

        void get_new_sample()
        {
            double delta = gen!.sample_delta();
            double cur_x = points_x.Last() + delta;
            points_x.Add(cur_x);
            delta_arr.Add(delta);
            update_label(cur_x, delta);
        }

        void update_label(double x, double delta)
        {
            
            label1.Text = $"x = {String.Format("{0:N4}", x)} delta = {String.Format("{0:N4}", delta)}";
            label1.Refresh();
        }

        void update_plot()
        {
            int k = 3;
            if (delta_arr.Count() < k)
            {
                return;
            }
            double[] X = Enumerable.Range(1, mean_list.Count()).Select(x => (double)x).Skip(k).ToArray();
            clear_plot();
            
            formsPlot1.Plot.AddScatter(X, mean_list.Skip(k).ToArray());
            formsPlot2.Plot.AddScatter(X, var_list.Skip(k).ToArray());
            formsPlot5.Plot.AddScatter(X, period_list.Skip(k).ToArray());

            refresh_plot();
        }

        void clear_plot()
        {
            formsPlot1.Plot.Clear();
            formsPlot2.Plot.Clear();
            formsPlot5.Plot.Clear();
        }

        void refresh_plot()
        {

            formsPlot1.Refresh();
            formsPlot2.Refresh();
            formsPlot5.Refresh();
        }

        void add_mean_var()
        {
            double mean = 0, var = 0;
            calc.get_mean_var(ref mean, ref var, delta_arr);
            mean_list.Add(mean);
            var_list.Add(var);
        }
        

        void add_period()
        {
            period_list.Add(1 - var_list.Last() / mean_list.Last() / mean_list.Last());
        }
        void plot_dist()
        {
            if (delta_arr.Count() <= 1)
            {
                return;
            }
            const double k = 0.8;
            double mean = gen!.get_moment1();
            double sigma = Math.Sqrt(gen!.get_moment2());
            double len = 10 * sigma;
            double binSize = len / 30.0;
            (double[] counts, double[] binEdges) = 
            ScottPlot.Statistics.Common.Histogram(
                delta_arr.ToArray(),
                min: mean - 5 * sigma,
                max: mean + 5 * sigma,
                binSize: binSize,
                density: true
                );
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            var plt = new Plot(600, 400);
            var bar = plt.AddBar(values: counts, positions: leftEdges);
            bar.BarWidth = binSize*k;
            
            formsPlot4.Plot.Clear();
            formsPlot4.Plot.Add(bar);
            formsPlot4.Refresh();
        }

        void update_labels(double x, double delta, double mean, double var, double period, int count)
        {
            label1.Text = $"x = {String.Format("{0:N2}", x)} delta = {String.Format("{0:N2}", delta)}";
            label_mean.Text = $"Среднее = {String.Format("{0:N2}", mean)}";
            label_var.Text = $"Дисперсия = {String.Format("{0:N2}", var)}";
            label_period.Text = $"Периодичность = {String.Format("{0:N2}", period)}";
            label_count.Text = $"Количество точек = {count}";

            label1.Refresh();
            label_var.Refresh();
            label_mean.Refresh();
            label_period.Refresh();
            label_count.Refresh();
        }

        // Paint line and points
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Line
            int HIEGHT_3 = pictureBox1.Size.Height / 3, WIDTH_2 = pictureBox1.Size.Width / 2;
            int HIEGHT_2 = pictureBox1.Size.Height / 2;
            int HIEGHT_6 = pictureBox1.Size.Height / 6;
            int LINE_UP = HIEGHT_2 - HIEGHT_3;
            int LINE_DOWN = HIEGHT_2 + HIEGHT_3;
            int R = (LINE_DOWN - LINE_UP) / 2;
            int C = (LINE_DOWN + LINE_UP) / 2;
            int offset = R + 20;

            int POINT_HIEGHT = 15, POINT_WIDTH = 15;
            e.Graphics.DrawLine(
                new Pen(Color.Red, 3f),
                new Point(offset, LINE_UP),
                new Point(pictureBox1.Size.Width - offset + 1, LINE_UP)
            );

            e.Graphics.DrawLine(
                new Pen(Color.Red, 3f),
                new Point(offset, LINE_DOWN),
                new Point(pictureBox1.Size.Width - offset + 1, LINE_DOWN)
            );

            e.Graphics.DrawArc(
                new Pen(Color.Red, 3f),
                pictureBox1.Size.Width - offset - R,
                C - R,
                2 * R,
                2 * R,
                270,
                180
            );

            e.Graphics.DrawArc(
                new Pen(Color.Red, 3f),
                offset - R,
                C - R,
                2*R,
                2*R,
                90,
                180
            );

            // Points
            SolidBrush brush = new SolidBrush(Color.Blue);

            double LINE_WIDTH = pictureBox1.Size.Width - 2*offset;
            double ARC_WIDTH = Math.PI * R / 2;
            for (int i = 0; i < points_x.Count; ++i)
            {
                if (points_x[i] > 1e9 || points_x[i] < -1e9)
                {
                    reset();
                }
                int x = Convert.ToInt32(points_x[i]);
                int points_hieght = i == points_x.Count - 1 ? POINT_HIEGHT + 10 : POINT_HIEGHT;
                int points_width = i == points_x.Count - 1 ? POINT_WIDTH + 10 : POINT_WIDTH;
                if (x > 2 * LINE_WIDTH + 2 * ARC_WIDTH || x < 0)
                {
                    x %= (int)(2 * (LINE_WIDTH + ARC_WIDTH));
                }
                if(x < 0)
                {
                    x += (int)(2 * (LINE_WIDTH + ARC_WIDTH));
                }
                if(x >= 0 && x <= LINE_WIDTH)
                {
                    e.Graphics.FillEllipse(brush, offset + x, LINE_UP - points_hieght / 2, points_width, points_hieght);
                }

                if (x > LINE_WIDTH && x < LINE_WIDTH  + ARC_WIDTH)
                {
                    double t = x - LINE_WIDTH;
                    double angle = t * Math.PI / ARC_WIDTH;
                    double t_x = R * Math.Cos(angle - Math.PI / 2);
                    double t_y = R * Math.Sin(angle - Math.PI / 2);
                    double c_x = LINE_WIDTH + offset;
                    double c_y = C;

                    int p_x = (int)(c_x + t_x);
                    int p_y = (int)(c_y + t_y);

                    e.Graphics.FillEllipse(brush, p_x - 4, p_y - points_hieght / 2, points_width, points_hieght);
                }
                if (x >= LINE_WIDTH + ARC_WIDTH && x <= 2*LINE_WIDTH + ARC_WIDTH)
                {
                    double t = pictureBox1.Size.Width - offset - (x - LINE_WIDTH - ARC_WIDTH);
                    e.Graphics.FillEllipse(brush, (int) t, LINE_DOWN - points_hieght / 2, points_width, points_hieght);
                }
                if (x > 2 * LINE_WIDTH + ARC_WIDTH && x <= 2 * (LINE_WIDTH + ARC_WIDTH))
                {
                    double t = x - 2 * LINE_WIDTH - ARC_WIDTH;
                    double angle = t * Math.PI / ARC_WIDTH;
                    double t_x = R * Math.Cos(angle - 3*Math.PI / 2);
                    double t_y = R * Math.Sin(angle - 3*Math.PI / 2);
                    double c_x = offset;
                    double c_y = C;

                    int p_x = (int)(c_x + t_x);
                    int p_y = (int)(c_y + t_y);
                    e.Graphics.FillEllipse(brush, p_x - 4, p_y - points_hieght / 2, points_width, points_hieght);
                }
            }
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
            period_list = new List<double> { };
            mean_list = new(); 
            var_list = new();

            
            gen = new RandomGenerator(cur_dist, par1, par2);

            update_labels(0, 0, 0, 0, 0, 0);
            pictureBox1.Refresh();
            clear_plot();
            refresh_plot();

            formsPlot4.Plot.Clear();
            formsPlot4.Refresh();
        }



        // Set property NumercicUpDown mean var
        void set_NumericUpDown()
        {

            Dictionary<string, double> dist = dist_params[cur_dist];
            Dictionary<string, string> dist_name = dist_params_names[cur_dist];

            ParametrLabel1.Text = dist_name["par1"];
            numericUpDownMean.Maximum = (decimal)dist["max_par1"];
            numericUpDownMean.Minimum = (decimal)dist["min_par1"];
            numericUpDownMean.ThousandsSeparator = true;
            numericUpDownMean.DecimalPlaces = (int)dist["DecimalPlaces1"];
            numericUpDownMean.Increment = (decimal)dist["step_par1"];
            numericUpDownMean.Value = (decimal)dist["par1"];

            if (dist["count"] == 2)
            {
                ParametrLabel2.Text = dist_name["par2"];
                numericUpDownVar.Maximum = (decimal)dist["max_par2"];
                numericUpDownVar.Minimum = (decimal)dist["min_par2"];
                numericUpDownVar.ThousandsSeparator = true;
                numericUpDownVar.DecimalPlaces = (int)dist["DecimalPlaces2"];
                numericUpDownVar.Increment = (decimal)dist["step_par2"];
                numericUpDownVar.Value = (decimal)dist["par2"];
            }
            ParametrLabel2.Visible = dist["count"] == 2;
            numericUpDownVar.Visible = dist["count"] == 2;

            freqUpDown.Maximum = 10000;
            freqUpDown.Minimum = 1;
            freqUpDown.ThousandsSeparator = true;
            freqUpDown.Increment = 1;
            freqUpDown.Value = 500;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = comboBox1.SelectedIndex;
            List<string> hash_name = new() { "norm", "gamma", "pareto", "weibull", "puass", "bernoulli" };
            cur_dist = hash_name[id];
            set_NumericUpDown();
            reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
            par_.Show();
            Hide();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            par_.Close();
        }

        void init_dict()
        {
            //norm
            Dictionary<string, double> dist = new();
            Dictionary<string, string> dist_name = new();
            dist["count"] = 2;
            dist["min_par1"] = -1000;
            dist["max_par1"] = 1000;
            dist["min_par2"] = 1;
            dist["max_par2"] = 1000;
            dist["step_par1"] = 0.1;
            dist["step_par2"] = 0.1;
            dist["DecimalPlaces1"] = 1;
            dist["DecimalPlaces2"] = 1;

            dist["par1"] = 40;
            dist["par2"] = 30;

            dist_name["par1"] = "m";
            dist_name["par2"] = "\u03C3"; //sigma

            dist_params["norm"] = new(dist);
            dist_params_names["norm"] = new(dist_name);

            dist.Clear();
            dist_name.Clear();

            //exp
            dist["count"] = 1;
            dist["min_par1"] = 0.1;
            dist["max_par1"] = 1000;
            dist["step_par1"] = 0.1;
            dist["par1"] = 1;
            dist["DecimalPlaces1"] = 1;

            dist_name["par1"] = "\u03BB"; //lambda

            dist_params["exp"] = new(dist);
            dist_params_names["exp"] = new(dist_name);
            
            dist.Clear();
            dist_name.Clear();

            //puass
            dist["count"] = 2;
            dist["min_par1"] = 0.1;
            dist["max_par1"] = 1000;
            dist["step_par1"] = 0.1;
            dist["min_par2"] = 1;
            dist["max_par2"] = 1000;
            dist["step_par2"] = 1;
            dist["par1"] = 1;
            dist["par2"] = 30;
            dist["DecimalPlaces1"] = 1;
            dist["DecimalPlaces2"] = 1;

            dist_name["par1"] = "\u03BB"; //lambda
            dist_name["par2"] = "Масштаб";

            dist_params["puass"] = new(dist);
            dist_params_names["puass"] = new(dist_name);

            dist.Clear();
            dist_name.Clear();

            //bernoulli
            dist["count"] = 2;
            dist["min_par1"] = 0.1;
            dist["max_par1"] = 0.9;
            dist["step_par1"] = 0.1;
            dist["min_par2"] = 1;
            dist["max_par2"] = 1000;
            dist["step_par2"] = 1;
            dist["par1"] = 0.5;
            dist["par2"] = 30;
            dist["DecimalPlaces1"] = 1;
            dist["DecimalPlaces2"] = 1;

            dist_name["par1"] = "p";
            dist_name["par2"] = "Масштаб";

            dist_params["bernoulli"] = new(dist);
            dist_params_names["bernoulli"] = new(dist_name);

            dist.Clear();
            dist_name.Clear();

            //gamma
            dist["count"] = 2;
            dist["min_par1"] = 0.01;
            dist["max_par1"] = 1000;
            dist["step_par1"] = 0.01;
            dist["min_par2"] = 0.01;
            dist["max_par2"] = 1000;
            dist["step_par2"] = 0.01;
            dist["par1"] = 1;
            dist["par2"] = 1;
            dist["DecimalPlaces1"] = 2;
            dist["DecimalPlaces2"] = 2;

            dist_name["par1"] = "k";
            dist_name["par2"] = "\u03B8"; //theta

            dist_params["gamma"] = new(dist);
            dist_params_names["gamma"] = new(dist_name);

            dist.Clear();
            dist_name.Clear();

            //pareto
            dist["count"] = 2;
            dist["min_par1"] = 0.1;
            dist["max_par1"] = 1000;
            dist["step_par1"] = 0.1;
            dist["min_par2"] = 1;
            dist["max_par2"] = 1000;
            dist["step_par2"] = 0.1;
            dist["par1"] = 30;
            dist["par2"] = 3;
            dist["DecimalPlaces1"] = 1;
            dist["DecimalPlaces2"] = 1;

            dist_name["par1"] = "xm";
            dist_name["par2"] = "\u03B1"; //alpha

            dist_params["pareto"] = new(dist);
            dist_params_names["pareto"] = new(dist_name);

            dist.Clear();
            dist_name.Clear();

            //weibull
            dist["count"] = 2;
            dist["min_par1"] = 0.1;
            dist["max_par1"] = 1000;
            dist["step_par1"] = 0.1;
            dist["min_par2"] = 0.1;
            dist["max_par2"] = 1000;
            dist["step_par2"] = 0.1;
            dist["par1"] = 1;
            dist["par2"] = 3;
            dist["DecimalPlaces1"] = 1;
            dist["DecimalPlaces2"] = 1;

            dist_name["par1"] = "k";
            dist_name["par2"] = "\u03BB"; //lambda

            dist_params["weibull"] = new(dist);
            dist_params_names["weibull"] = new(dist_name);

            dist.Clear();
            dist_name.Clear();
        }
    }
}