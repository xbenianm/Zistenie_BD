namespace AbaqusBDConsole
{
    public static class MaterialDatabase
    {
        public static MaterialModel GetMaterial(MaterialType type)
        {
            switch (type)
            {
                case MaterialType.Steel11373: return Steel11373();
                case MaterialType.AISI304: return AISI304();
                case MaterialType.AISI316: return AISI316();
                case MaterialType.Pozink: return Pozink();
                case MaterialType.RAL9016: return RAL9016();
                default: throw new System.Exception("Neznámy materiál.");
            }
        }

        private static MaterialModel Steel11373()
        {
            var c = new StressStrainCurve();
            c.Strain.AddRange(new double[] { 0.0, 0.002, 0.01, 0.03, 0.07, 0.12 });
            c.Stress.AddRange(new double[] { 0, 240, 300, 360, 405, 430 });

            return new MaterialModel
            {
                Name = "11373",
                Young = 210000,
                Yield = 240,
                Curve = c
            };
        }

        private static MaterialModel AISI304()
        {
            var c = new StressStrainCurve();
            c.Strain.AddRange(new double[] { 0.0, 0.002, 0.01, 0.05, 0.15, 0.30 });
            c.Stress.AddRange(new double[] { 0, 280, 360, 550, 650, 720 });

            return new MaterialModel
            {
                Name = "AISI 304",
                Young = 193000,
                Yield = 280,
                Curve = c
            };
        }

        private static MaterialModel AISI316()
        {
            var c = new StressStrainCurve();
            c.Strain.AddRange(new double[] { 0.0, 0.002, 0.01, 0.05, 0.15, 0.30 });
            c.Stress.AddRange(new double[] { 0, 290, 370, 560, 670, 760 });

            return new MaterialModel
            {
                Name = "AISI 316",
                Young = 193000,
                Yield = 290,
                Curve = c
            };
        }

        private static MaterialModel Pozink()
        {
            var c = new StressStrainCurve();
            c.Strain.AddRange(new double[] { 0.0, 0.002, 0.01, 0.03, 0.08, 0.12 });
            c.Stress.AddRange(new double[] { 0, 210, 270, 320, 350, 380 });

            return new MaterialModel
            {
                Name = "Pozink",
                Young = 210000,
                Yield = 210,
                Curve = c
            };
        }

        private static MaterialModel RAL9016()
        {
            var c = new StressStrainCurve();
            c.Strain.AddRange(new double[] { 0.0, 0.002, 0.01, 0.03, 0.07, 0.12 });
            c.Stress.AddRange(new double[] { 0, 230, 290, 340, 380, 410 });

            return new MaterialModel
            {
                Name = "RAL 9016 coated steel",
                Young = 210000,
                Yield = 230,
                Curve = c
            };
        }
    }
}
