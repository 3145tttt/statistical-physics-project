using MathNet.Numerics;
using MathNet.Numerics.Integration;
using MathNet.Numerics.Statistics;
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
            return SimpsonRule.IntegrateComposite(f, a, b, n);
        }

        // Numeric find root
        // f(x) = y;
        public double find_root(Func<double, double> f, double y, double a, double b, double accuracy, int maxIterations)
        {
            Func<double, double> _f = x => (f(x) - y);
            return FindRoots.OfFunction(_f, a, b, accuracy, maxIterations);
        }

        public void get_mean_var(ref double mean, ref double var, List<double> arr)
        {
            mean = Statistics.Mean(arr);
            var = Statistics.Variance(arr);
        }

        public Dictionary<double, double> get_prob(List<double> arr)
        {
            const int N = 1;

            double[] t = arr.Select(x => Math.Round(x, N)).ToArray();
            Dictionary<double, double> prob = new();
            foreach (double x in t)
            {
                if (prob.ContainsKey(x))
                {
                    ++prob[x];
                }
                else
                {
                    prob[x] = 1;
                }
            }
            foreach (KeyValuePair<double, double> x in prob)
            {
                prob[x.Key] = x.Value / t.Length;
            }

            return prob;
        }

        public double get_entropy(List<double> arr)
        {
            return Statistics.Entropy(arr);
        }
    }
}