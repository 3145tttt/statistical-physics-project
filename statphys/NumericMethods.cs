using System.Diagnostics;
using static System.Windows.Forms.DataFormats;

namespace statphys
{
    class NumericMethods
    {
        // Numeric intregral
        // integral{b}{a}f(x)dx = ...
        public double integrate_numeric(Func<double, double> f, double a, double b, int n)
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

        // Numeric find root
        // f(x) = y;
        // f'(x) >= 0;
        // x in [a, b];
        public double find_root(Func<double, double> f, double y, double a, double b, int n, double eps)
        {
            double l = a, r = b;
            double x = (l + r) / 2;

            for (int i = 0; i < n; ++i)
            {
                double x_prev = x;
                if (f(x) > y)
                {
                    r = x;
                }
                else if (f(x) < y)
                {
                    l = x;
                }
                else
                {
                    return x;
                }
                x = (l + r) / 2;
                if (Math.Abs(x - x_prev) < eps)
                {
                    return x;
                }
            }

            return x;
        }

        public void get_mean_var(ref double mean, ref double var, List<double> arr)
        {
            if (arr.Count() == 0)
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
    }
}