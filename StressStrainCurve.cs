using System.Collections.Generic;

namespace AbaqusBDConsole
{
    public class StressStrainCurve
    {
        public List<double> Strain { get; set; } = new List<double>();
        public List<double> Stress { get; set; } = new List<double>();

        public double StressAt(double eps)
        {
            if (eps <= Strain[0]) return Stress[0];
            if (eps >= Strain[Strain.Count - 1])
                return Stress[Stress.Count - 1];

            for (int i = 0; i < Strain.Count - 1; i++)
            {
                if (eps >= Strain[i] && eps <= Strain[i + 1])
                {
                    double t = (eps - Strain[i]) / (Strain[i + 1] - Strain[i]);
                    return Stress[i] + t * (Stress[i + 1] - Stress[i]);
                }
            }
            return Stress[Stress.Count - 1];
        }

        public double Integrate(double epsMax)
        {
            double result = 0.0;

            for (int i = 0; i < Strain.Count - 1; i++)
            {
                double e1 = Strain[i];
                double e2 = Strain[i + 1];

                if (e2 > epsMax)
                {
                    double sigma1 = StressAt(e1);
                    double sigma2 = StressAt(epsMax);
                    result += 0.5 * (sigma1 + sigma2) * (epsMax - e1);
                    break;
                }

                double s1 = Stress[i];
                double s2 = Stress[i + 1];
                result += 0.5 * (s1 + s2) * (e2 - e1);
            }

            return result;
        }
    }
}
