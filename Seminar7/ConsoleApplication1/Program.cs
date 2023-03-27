using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApplication1
{
    class Lab6 {
        public static void Main() {
            Random rand = new Random();
            Masini masini = new Masini();
            masini.Cirite();
            int valTotal = masini.ValTotalParcAuto();
            Console.WriteLine("Valoarea totala a parcului auto: " + valTotal);
            masini.Sortare();
            masini.Afisare();
            var dictionar = masini.PretMinimPerMarca();
            int valMinim = masini.PretMinimParcAuto(dictionar);
            Console.WriteLine("Valoarea minima a parcului auto: " + valMinim);
            Masina masina = masini.getList()[0];
            Masina masina2 = masini.getList()[1];
            masina.Reducere(20);
            Console.WriteLine(masina.ToString());
            Console.WriteLine("-===========================-");
            masina2 = masina + 50;
            Console.WriteLine("Masina 1: " + masina.ToString());
            Console.WriteLine("Masina 2: " + masina2.ToString());
            Console.WriteLine("Masinile sunt egale ca si pret? " + masini.CompareMasini(masina, masina2));
            masina = masina + 50;
            Console.WriteLine("Masinile sunt egale ca si pret? " + masini.CompareMasini(masina, masina2));
            masini.Salvare();
            return;
        }
    }
}
