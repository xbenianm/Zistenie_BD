using System;
using System.Collections.Generic;

namespace AbaqusBDConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Nelineárny Abaqus BD kalkulátor ===");
            Console.WriteLine("Materiály:");
            Console.WriteLine("1 = 11373");
            Console.WriteLine("2 = AISI 304");
            Console.WriteLine("3 = AISI 316");
            Console.WriteLine("4 = Pozink");
            Console.WriteLine("5 = RAL 9016");
            Console.Write("Vyber materiál: ");
            int mat = int.Parse(Console.ReadLine());

            MaterialType type = MaterialType.Steel11373;

            switch (mat)
            {
                case 1: type = MaterialType.Steel11373; break;
                case 2: type = MaterialType.AISI304; break;
                case 3: type = MaterialType.AISI316; break;
                case 4: type = MaterialType.Pozink; break;
                case 5: type = MaterialType.RAL9016; break;
                default: Console.WriteLine("Neplatný výber."); return;
            }

            var material = MaterialDatabase.GetMaterial(type);

            Console.WriteLine("
Zvolený materiál: " + material.Name);
            Console.WriteLine("E = " + material.Young + " MPa");
            Console.WriteLine("Re = " + material.Yield + " MPa
");

            Console.Write("Hrúbka t [mm]: ");
            double t = double.Parse(Console.ReadLine());

            Console.Write("Vnútorný polomer R [mm]: ");
            double R = double.Parse(Console.ReadLine());

            Console.Write("Šírka V-die V [mm]: ");
            double Vd = double.Parse(Console.ReadLine());

            Console.Write("Uhol ohybu [°]: ");
            double angle = double.Parse(Console.ReadLine());

            Console.Write("Rameno A [mm]: ");
            double A = double.Parse(Console.ReadLine());

            Console.Write("Rameno B [mm]: ");
            double B = double.Parse(Console.ReadLine());

            var calc = new AbaqusNonlinearBD
            {
                Thickness = t,
                Radius = R,
                DieWidth = Vd,
                AngleDeg = angle,
                ArmA = A,
                ArmB = B,
                Young = material.Young,
                Curve = material.Curve
            };

            double bd = calc.ComputeBD();

            Console.WriteLine("
=== Výsledok ===");
            Console.WriteLine("BD = " + bd.ToString("F3") + " mm");

            Console.WriteLine("
Stlač ENTER pre ukončenie.");
            Console.ReadLine();
        }
    }
}
