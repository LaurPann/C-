using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Masini
    {
        private String fileName = "cars.json";
        private static List<Masina> masini { get; set; }
        private List<String> marcii = new List<string>()
        {
            "Audi", "BMW", "Logan"
        };
        public Masini()
        {
           masini = new List<Masina>();
        }
        public List<Masina> getList()
        {
            return masini;
        }
        public void Cirite() {
            Random rand = new Random();
            List<Masina> masiniL = JsonConvert.DeserializeObject<List<Masina>>(File.ReadAllText(this.fileName));
            if (masiniL == null || masini.Count <= 0)
            {
                if (masiniL == null) masiniL = new List<Masina>();
                for (int i = 0; i < 4; i++)
                {
                    masiniL.Add(new Masina(rand.Next(1000), "222", marcii[rand.Next(marcii.Count)], rand.Next(10000)));
                }
            }
            masini = masini;
        }
        public void Salvare()
        {
            string json = JsonConvert.SerializeObject(masini, Formatting.Indented);
            File.WriteAllText(this.fileName, json);
        }
        public void Sortare()
        {
            masini.Sort(Masina.CompareTo);
        }
        public bool CompareMasini(Masina m2, Masina m)
        {
            return m == m2;
        }
        public int ValTotalParcAuto()
        {
            int total = 0;
            masini.ForEach((m) =>
            {
                total += m.Pret;
            });
            return total;
        }
        public void Afisare()
        {
            masini.ForEach((m) => Console.WriteLine(m.ToString()));
        }
        public int PretMinimParcAuto(Dictionary<String, int> minPret) {
            int valMin = int.MaxValue;
            for (int i = 0; i < minPret.Count; i++)
            {
                var pos = minPret.ElementAt(i);
                if (pos.Value < valMin)
                {
                    valMin = pos.Value;
                }
            }
            return valMin;
        }
        public int AfisarePretMinimPerMarca(Dictionary<String, int> minPret)
        {
            int valMin = int.MaxValue;
            for (int i = 0; i < minPret.Count; i++)
            {
                var pos = minPret.ElementAt(i);
                if (pos.Value < valMin)
                {
                    valMin = pos.Value;
                }
            }
            return valMin;
        }
        public Dictionary<String, int> PretMinimPerMarca() {
            Dictionary<String, int> minPret = new Dictionary<string, int>();
            masini.ForEach((m) =>
            {

                String marca = m.Marca;
                int curpret = m.Pret;
                if (minPret.ContainsKey(marca))
                {
                    var key = minPret.ElementAtOrDefault(0);
                    if (curpret < key.Value)
                    {
                        minPret.Remove(marca);
                        minPret.Add(marca, curpret);
                    }
                }
                else
                {
                    minPret.Add(marca, curpret);
                }
            });
            return minPret;
        }
        public static int operator +(Masina m)
        {
            masini.Add(m);
            return 0;
        }
    }
}
