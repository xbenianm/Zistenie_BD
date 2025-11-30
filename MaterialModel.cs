namespace AbaqusBDConsole
{
    public class MaterialModel
    {
        public string Name { get; set; }
        public double Young { get; set; }      
        public double Yield { get; set; }      
        public StressStrainCurve Curve { get; set; }
    }
}
