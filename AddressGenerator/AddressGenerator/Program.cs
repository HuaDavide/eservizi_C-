using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressGenerator generator = new AddressGenerator("11000111010100010010111011111001");
            Console.WriteLine(generator.generateIPv4());
            Console.WriteLine(generator.generateSubnet());
            Console.ReadLine();

            try
            {
                AddressGenerator generatorTest = new AddressGenerator("11");
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }

            try
            {
                AddressGenerator Test = new AddressGenerator("ciaosonounostudentediquartaeciao");
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }

            Console.ReadLine();
        }
    }
}
