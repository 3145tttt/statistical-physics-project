using System.Diagnostics;

namespace statphys
{

    // Sample from custom distrubition
    class RandomGenerator
    {
        Random rnd;
        Func<double, double> pdf;
        NumericMethods calc = new NumericMethods();
        public RandomGenerator(Func<double, double> f)
        {
            //init Random gen U(0, 1)
            rnd = new Random(12);
            pdf = f;
        }

        public double sample_delta(double a, double b, int n = 4000, double eps = 0.00001)
        {
            double val = rnd.NextDouble();
            
            Func<double, double> get_cdf = x => calc.integrate_numeric(pdf, a, x, n);
            double delta = calc.find_root(get_cdf, val, a, b, n, eps);

            // Check cdf(delta) == val
            Debug.Assert(Math.Abs(val - calc.integrate_numeric(pdf, a, delta, n * 10)) < eps);
            return delta;
        }
    }
}