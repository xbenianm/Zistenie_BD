using System;

namespace AbaqusBDConsole
{
    public class AbaqusNonlinearBD
    {
        public double Thickness;
        public double Radius;
        public double DieWidth;
        public double AngleDeg;
        public double ArmA;
        public double ArmB;
        public double Young;

        public StressStrainCurve Curve;

        public double ComputeBD()
        {
            double t = Thickness;
            double R = Radius;
            double V = DieWidth;

            double angle = AngleDeg * Math.PI / 180.0;

            double eps_p = t / (2.0 * (R + t));

            double integral = Curve.Integrate(eps_p);

            double hp = t * (integral / Young) * (V / (2.0 * (R + t)));
            if (hp > t) hp = t;

            double alpha = hp / t;

            double rhoNA = R + t * (0.5 - alpha);

            double BA = rhoNA * angle;

            return ArmA + ArmB - BA;
        }
    }
}
