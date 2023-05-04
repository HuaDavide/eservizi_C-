using System;

namespace AddressGenerator
{
    interface IAddress
    {
        string generateIPv4();
        string generateSubnet();
    }
    internal class AddressGenerator : IAddress
    {
        string bit32;

        public AddressGenerator(string bit32)
        {
            if (bit32.Length == 32)
            {
                for (int i = 0; i < 32; i++)
                    if (bit32[i] != '0' && bit32[i] != '1')
                        throw new Exception("Errore: deve essere sequenza di bit");

                this.bit32 = bit32;
            }
            else
                throw new Exception("Errore: deve essere di 32 caratteri");
        }


        public string generateIPv4()
        {
            string ipGenerated = "";
            byte[] net_ID = new byte[4];
            bool[] ottetto_ip_address_bool = new bool[8];

            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 8; k++)
                    if (bit32[i * 8 + k] == '0')
                        ottetto_ip_address_bool[k] = false;
                    else
                        ottetto_ip_address_bool[k] = true;


                net_ID[i] = BoolToByte(ottetto_ip_address_bool);
            }

            ipGenerated = net_ID[0] + "." + net_ID[1] + "." + net_ID[2] + "." + net_ID[3];
            return ipGenerated;
        }

        public string generateSubnet()
        {
            string ipGenerated = generateIPv4();
            string[] ottetti = ipGenerated.Split('.');
            int CIDR;
            Random estrazione = new Random();

            if (ottetti[3] == "0" || ottetti[3] == "255")
            {
                CIDR = estrazione.Next(0, 24);
            }
            else
                CIDR = estrazione.Next(0, 30);

            bool[,] ip_address_binaria = new bool[4, 8];
            bool[] ottetto_ip_address_binaria = new bool[8];
            string subnetGenerated = "";
            byte[] subnet_mask = new byte[4];
            for (int i = 0; i < CIDR; i++)
            {
                ip_address_binaria[i / 8, i % 8] = true;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 8; k++)
                    ottetto_ip_address_binaria[k] = ip_address_binaria[i, k];

                subnet_mask[i] = BoolToByte(ottetto_ip_address_binaria);
            }

            subnetGenerated = subnet_mask[0] + "." + subnet_mask[1] + "." + subnet_mask[2] + "." + subnet_mask[3];

            return subnetGenerated;
        }

        public static byte BoolToByte(bool[] bn)
        {
            int esponente = 0;
            byte tmp = 0;

            for (int i = 7; i >= 0; i--)
            {
                if (bn[i])
                    tmp += Convert.ToByte(Math.Pow(2, esponente));
                esponente++;
            }

            return tmp;
            throw new Exception();
        }
    }
}
