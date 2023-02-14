using MathNet.Numerics;
using MathNet.Numerics.Integration;
using MathNet.Numerics.Statistics;
using System.Diagnostics;
using static System.Windows.Forms.DataFormats;

namespace statphys
{
    class NumericMethods
    {
    

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
    }
}