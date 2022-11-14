using System.Diagnostics;
using System.Drawing;
using System.Globalization;

namespace statphys
{
    class TestingSystem 
    {
        NumericMethods calc = new NumericMethods();

        // Test numeric root f(x) = y;
        public void test_root()
        {

            Func<double, double> g1 = x => 1 - Math.Exp(-x);
            Func<double, double> g2 = x => -(Math.Sin(x) + Math.Cos(x));
            Func<double, double> g3 = x => Math.Exp(x * x);

            double r1 = calc.find_root(g1, 0.2, 0.1, 100, 0.000001, 1000);
            double r2 = calc.find_root(g2, 0.2, 1, 3, 0.000001, 1000);
            double r3 = calc.find_root(g3, 10, 0.1, 100, 0.000001, 1000);
            const double x1 = 0.22314355131420;
            const double x2 = 2.49809;
            const double x3 = 1.5174271293;
            const double eps = 0.00001;
            Debug.Assert(Math.Abs(x1 - r1) < eps);
            Debug.Assert(Math.Abs(x2 - r2) < eps);
            Debug.Assert(Math.Abs(x3 - r3) < eps);
        }

        // Test numeric integral
        public void test_integrator()
        {
            Func<double, double> f1 = x => x;
            Func<double, double> f2 = x => x * 2 + x;
            Func<double, double> f3 = x => Math.Sin(x) * Math.Exp(-x) + Math.Cos(x);

            const double eps = 0.00001;
            double r1 = calc.integrate_numeric(f1, -0.5, 4, 1000);
            double r2 = calc.integrate_numeric(f2, -0.5, 4, 1000);
            double r3 = calc.integrate_numeric(f3, -0.5, 4, 1000);
            const double S1 = 7.875;
            const double S2 = 23.625;
            const double S3 = 0.06376463084945965;
            Debug.Assert(Math.Abs(S1 - r1) < eps);
            Debug.Assert(Math.Abs(S2 - r2) < eps);
            Debug.Assert(Math.Abs(S3 - r3) < eps);
        }

        //sample test
        public void test_sampling(double a, double b, Func<double, double> pdf)
        {
            RandomGenerator gen = new RandomGenerator("norm", 0, 10);
            const int N = 1000;
            List<double> arr = new List<double> { };
            for (int i = 0; i < N; ++i)
            {
                arr.Add(gen.sample_delta());
            }
            for (int i = 0; i < arr.Count(); ++i)
            {
                Trace.WriteLine(arr[i].ToString(CultureInfo.GetCultureInfo("en-GB")));
            }
        }
    }
}