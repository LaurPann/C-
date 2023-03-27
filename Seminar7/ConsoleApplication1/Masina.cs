using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Masina
    {
        public int Pret { get; set; }
        public string VIN { get; set; }
        public String Marca { get; set; }
        public int Kilometraj { get; set; }

        public Masina()
        {
            this.Kilometraj = 0;
            this.Marca = "Marca neinitializata";
            this.VIN = "VIN neinitializat";
        }
        public Masina(int pret, string vIN, string marca, int kilometraj)
        {
            Pret = pret;
            VIN = vIN;
            Marca = marca;
            Kilometraj = kilometraj;
        }
        public override String ToString()
        {
            return "Masina: Pret: " + Pret + " Marca: " + Marca + " VIN: " + VIN + " Kilometraj: " + Kilometraj;
        }
        public static int CompareTo(Masina m, Masina m1)
        {
            return m.Pret.CompareTo(m1.Pret);
        }
        public void Reducere(int value)
        {
            this.Pret -= this.Pret * value / 100;
        }
        public static Masina operator +(Masina m, int value)
        {
            return new Masina(m.Pret + value, m.VIN, m.Marca, m.Kilometraj);
        }
        public static bool operator ==(Masina m1, Masina m2)
        {
            return m1.Pret == m2.Pret;
        }
        public static bool operator !=(Masina m1, Masina m2)
        {
            return m1.Pret != m2.Pret;
        }
    }
    class MasinaElectrica : Masina
    {
        public double Energy { get; set; }
        public double Autonomie { get; set; }

        public MasinaElectrica(int pret, string vIN, string marca, int kilometraj, double energy, double autonomie)
            : base(pret, vIN, marca, kilometraj)
        {
            this.Energy = energy;
            this.Autonomie = autonomie;
        }

        public override string ToString()
        {
            return base.ToString() + " Energy: " + Energy + " Autonomie: " + Autonomie;
        }
    }

    class Tir : Masina
    {
        public double Tonaj { get; set; }

        public Tir(int pret, string vIN, string marca, int kilometraj, double tonaj)
            : base(pret, vIN, marca, kilometraj)
        {
            this.Tonaj = tonaj;
        }

        public override string ToString()
        {
            return base.ToString() + " Tonaj: " + Tonaj;
        }
    }
}

