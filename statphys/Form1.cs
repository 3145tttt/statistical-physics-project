using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Numerics;
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
        double mean = 0, var = 1;

        RandomGenerator? gen;
        readonly NumericMethods calc = new();
        readonly TestingSystem test = new();
        List<double> mean_list = new();
        List<double> var_list = new();
        List<double> entropy_list = new();

        public Form1()
        {
            InitializeComponent();

            set_NumericUpDown();
            reset();

            //init debug logger
            Trace.Listeners.Add(new TextWriterTraceListener("debugOut.log"));
            Trace.AutoFlush = true;

            formsPlot1.Plot.Title("Среднее");
            formsPlot2.Plot.Title("Дисперсия");
            formsPlot3.Plot.Title("Энтропия");

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
            add_mean_var();
            add_entropy();
            update_mean_var_labels();
            update_plot();
            if(delta_arr.Count() % 10 == 0)
            {
                plot_dist();
            }
        }

        void get_new_sample()
        {
            double sigma = Math.Sqrt(var);
            double delta = gen!.sample_delta(-10*sigma, 10*sigma);
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

        void update_plot()
        {
            double[] X = Enumerable.Range(1, mean_list.Count()).Select(x => (double)x).ToArray();
            clear_plot();

            formsPlot1.Plot.AddScatter(X, mean_list.ToArray());
            formsPlot2.Plot.AddScatter(X, var_list.ToArray());
            formsPlot3.Plot.AddScatter(X, entropy_list.ToArray());

            refresh_plot();
        }

        void clear_plot()
        {
            formsPlot1.Plot.Clear();
            formsPlot2.Plot.Clear();
            formsPlot3.Plot.Clear();
        }

        void refresh_plot()
        {
            formsPlot1.Refresh();
            formsPlot2.Refresh();
            formsPlot3.Refresh();
        }

        void add_mean_var()
        {
            double mean = 0, var = 0;
            calc.get_mean_var(ref mean, ref var, delta_arr);
            mean_list.Add(mean);
            var_list.Add(var);
        }

        void add_entropy()
        {
            Dictionary<double, double> prob = calc.get_prob(delta_arr);
            entropy_list.Add(calc.get_entropy(prob));

            double[] pos = prob.Keys.ToArray();
            double[] y = prob.Values.ToArray();
            var plt = new Plot(600, 400);

        }
        
        void plot_dist()
        {
            if (delta_arr.Count() <= 1)
            {
                return;
            }
            const double k = 0.8;
            double sigma = Math.Sqrt(var);
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

        void update_mean_var_labels(double mean = 0, double var = 0)
        {            
            label_mean.Text = $"Mean = {mean}";
            label_var.Text = $"Variance = {var}";
            label_count.Text = $"Count = {mean_list.Count()}";

            label_var.Refresh();
            label_mean.Refresh();
            label_count.Refresh();
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
            test.test_integrator();
            test.test_root();
            update_plot();
        }

        // Test N sampling from distrubition;
        // out => statphys\statphys\bin\Debug\net6.0-windows\debugOut.log
        private void button3_Click(object sender, EventArgs e)
        {
            double sigma = Math.Sqrt(var);
            test.test_sampling(-10 * sigma, 10 * sigma, x => normal_dist(x, mean, sigma));
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
            entropy_list = new List<double> { };
            mean_list = new(); 
            var_list = new();

            gen = new RandomGenerator(x => normal_dist(x, mean, Math.Sqrt(var)));
            update_label(0, 0);
            pictureBox1.Refresh();
            update_mean_var_labels();
            clear_plot();
            refresh_plot();

            formsPlot4.Plot.Clear();
            formsPlot4.Refresh();
        }

        // Set property NumercicUpDown mean var
        void set_NumericUpDown()
        {
            this.numericUpDownMean.Maximum = 100;
            this.numericUpDownMean.Minimum = -100;
            this.numericUpDownMean.ThousandsSeparator = true;
            this.numericUpDownMean.DecimalPlaces = 1;
            this.numericUpDownMean.Increment = new decimal(0.1);

            this.numericUpDownVar.Maximum = 400;
            this.numericUpDownVar.Minimum = 1;
            this.numericUpDownVar.ThousandsSeparator = true;
            this.numericUpDownVar.DecimalPlaces = 1;
            this.numericUpDownVar.Increment = new decimal(0.1);
        }
    }
}