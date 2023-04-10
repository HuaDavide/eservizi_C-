using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dizionario = new string[3];

            try
            {
                TourOperator d1 = new TourOperator("A123");
                d1.add("davide", "Cina");

                d1.add("avide", "Cina");
                d1.add("vide", "Cina");
                d1.add("ide", "Cina");
                Console.WriteLine(d1.ToString());
                Console.ReadLine();
                Console.Clear();

                for (int i = 0; i < dizionario.Length; i++)
                {
                    Console.WriteLine("Inserisci il attributo secondo questo formato 'nome':'destinazione'");
                    dizionario[i] = Console.ReadLine();
                    Console.Clear();
                }
                TourOperator.main(dizionario);
                Console.ReadLine();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);

                Console.ReadLine();
            }

        }
    }
}
