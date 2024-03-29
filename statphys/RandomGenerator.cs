using MathNet.Numerics;
using MathNet.Numerics.Distributions;
using ScottPlot.MarkerShapes;
using System.Diagnostics;
using System.Drawing;

namespace statphys
{

    // Sample from custom distrubition
    class RandomGenerator
    {
        Random? rnd;
        double _par1, _par2;

        string _cur_dist;
        bool _discret_dist;
        public RandomGenerator(string dist_str, double par1, double par2 = 0)
        {
            //init Random gen U(0, 1)
            _cur_dist = dist_str;
            _par1 = par1;
            _par2 = par2;

            _discret_dist = dist_str == "puass" || dist_str == "bernoulli";
        }

        public double sample_delta(int n = 10000, double eps = 0.000001)
        {
            rnd = new Random(Guid.NewGuid().GetHashCode());
            if (_discret_dist)
            {
                return sample_delta_discret(n, eps);
            }
            if (_cur_dist == "norm")
            {
                return Normal.Sample(rnd, _par1, _par2);
            }
            else if (_cur_dist == "exp")
            {
                return Exponential.Sample(rnd, _par1);
            }
            else if (_cur_dist == "gamma")
            {
                return Gamma.Sample(rnd, _par1, 1/_par2);
            }
            else if (_cur_dist == "pareto")
            {
                return Pareto.Sample(rnd, _par1, _par2);
            }
            else if (_cur_dist == "weibull")
            {
                return Weibull.Sample(_par1, _par2);
            }

            return 0;
        }

        double sample_delta_discret(int n, double eps)
        {
            if(_cur_dist == "bernoulli")
            {
                return Bernoulli.Sample(rnd, _par1) * _par2;
            } else if(_cur_dist == "puass")
            {
                return Poisson.Sample(rnd, _par1) * _par2;
            }
            return 0;
        }

        public double get_moment1()
        {
            if (_cur_dist == "norm")
            {
                return _par1;
            }
            else if (_cur_dist == "exp")
            {
                return 1.0 / _par1;
            }
            else if (_cur_dist == "puass")
            {
                return _par1 * _par2;
            }
            else if (_cur_dist == "bernoulli")
            {
                return _par1 * _par2;
            } 
            else if (_cur_dist == "gamma")
            {
                return _par1 * _par2;
            }
            else if (_cur_dist == "pareto")
            {
                if (_par2 > 1)
                {
                    return _par1 * _par2 / (_par2 - 1);
                }
                return 1000;
            }
            else if (_cur_dist == "weibull")
            {
                return _par2 * SpecialFunctions.Gamma(1 + 1 / _par1);
            }
            Debug.Print("Error\n");
            return 0;
        }

        public double get_moment2()
        {
            if (_cur_dist == "norm")
            {
                return _par2 * _par2;
            }
            else if (_cur_dist == "exp")
            {
                return 1.0 / _par1 / _par1;
            }
            else if (_cur_dist == "puass")
            {
                return _par1 * _par2 * _par2;
            }
            else if (_cur_dist == "bernoulli")
            {
                return _par1*(1-_par1) * _par2 * _par2;
            }
            else if (_cur_dist == "gamma")
            {
                return _par1 * _par2 * _par2;
            }
            else if (_cur_dist == "pareto")
            {
                if(_par2 > 2)
                {
                    return _par1 * _par1 * _par2 / ((_par2 - 1) * (_par2 - 1) * ((_par2 - 2)));
                }
                return 1000;
            }
            else if (_cur_dist == "weibull")
            {
                double mu = get_moment1();
                return _par2 * _par2 * SpecialFunctions.Gamma(1 + 2 / _par1) - mu*mu;
            }
            Debug.Print("Error\n");
            return 0;
        }
    }
}