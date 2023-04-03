using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Contact other = (Contact)obj;

            return Name.Equals(other.Name) && PhoneNumber.Equals(other.PhoneNumber);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ PhoneNumber.GetHashCode();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "contacts.txt";
            List<Contact> phoneBook = new List<Contact>();

            LoadContacts(filePath, phoneBook);

            while (true)
            {
                Console.WriteLine("1. Adauga un contact");
                Console.WriteLine("2. Cauta un contact");
                Console.WriteLine("3. Sterge un contact");
                Console.WriteLine("4. Listeaza toate contactele");
                Console.WriteLine("5. Iesire");

                Console.Write("Alege o optiune: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Introduceti numele: ");
                        string name = Console.ReadLine();
                        Console.Write("Introduceti numarul de telefon: ");
                        string phoneNumber = Console.ReadLine();

                        Contact newContact = new Contact(name, phoneNumber);

                        if (phoneBook.Contains(newContact))
                        {
                            Console.WriteLine("Contactul cu numele {0} deja exista in agenda telefonica.", name);
                        }
                        else
                        {
                            phoneBook.Add(newContact);
                           
                            Console.WriteLine("Contactul a fost adaugat cu succes.");
                        }

                        break;

                    case "2":
                        Console.Write("Introduceti numele contactului pe care doriti sa il cautati: ");
                        string searchName = Console.ReadLine();

                        Contact foundContact = phoneBook.Find(contact => contact.Name == searchName);

                        if (foundContact != null)
                        {
                            Console.WriteLine("Nume: {0}, Numar de telefon: {1}", foundContact.Name, foundContact.PhoneNumber);
                        }
                        else
                        {
                            Console.WriteLine("Contactul cu numele {0} nu a fost gasit.", searchName);
                        }

                        break;

                    case "3":
                        Console.Write("Introduceti numele contactului pe care doriti sa il stergeti: ");
                        string deleteName = Console.ReadLine();

                        Contact deletedContact = phoneBook.Find(contact => contact.Name == deleteName);

                        if (phoneBook.Remove(deletedContact))
                        {
                            
                            Console.WriteLine("Contactul cu numele {0} a fost sters cu succes.", deleteName);
                        }
                        else
                        {
                            Console.WriteLine("Contactul cu numele {0} nu a fost gasit.", deleteName);
                        }

                        break;

                    case "4":
                        Console.WriteLine("Lista de contacte:");

                        foreach (Contact contact in phoneBook)
                        {
                            Console.WriteLine("Nume: {0}, Numar de telefon: {1}", contact.Name, contact.PhoneNumber);
                        }

                        break;

                    case "5":
                        Console.WriteLine("La revedere!");
                        return;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void LoadContacts(string filePath, List<Contact> phoneBook)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string name = parts[0];
                        string phoneNumber = parts[1];

                        Contact contact = new Contact(name, phoneNumber);
                        phoneBook.Add(contact);
                    }
                }
            }
        }
    }
}

