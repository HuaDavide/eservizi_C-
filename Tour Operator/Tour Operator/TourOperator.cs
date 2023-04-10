using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Tour_Operator
{
    interface CD
    {
        void insert(IComparable key, Object attribute);
        object find(IComparable key);
        object remove(IComparable key, Object attribute);
    }

    interface Container
    {
        bool IsEmpty();
        void makeEmpty();
        int size();
    }
   
    internal class TourOperator : Dictionary<string, Client>
    {
        string nextClientCode;

        public TourOperator(string initialClientCode) : base()
        {
            try
            {
                Control(initialClientCode);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }

            this.nextClientCode = initialClientCode;
        }

        private void Control(string code)
        {
            if (code.Length != 4)
                throw new Exception("Lunghezza codice errata");
            else if (!char.IsUpper(code[0]))
                throw new Exception("Primo carattere errato, deve essere una lettera maiuscola");
            else if (!char.IsDigit(code[1]))
                    throw new Exception("Secondo carattere errato, deve essere una cifra numerica");
             else if (!char.IsDigit(code[2]))
                    throw new Exception("Terzo carattere errato, deve essere una cifra numerica");
             else if (!char.IsDigit(code[3]))
                    throw new Exception("Quarto carattere errato, deve essere una cifra numerica");
        }

        public void add(string nome, string dest)
        {
            Client client = new Client(nome, dest);

            base.Add(nextClientCode, client);
            NextCode(ref nextClientCode);
        }

        private void NextCode(ref string code)
        {
            char L = code[0];
            int numbers = Convert.ToInt32(code.Substring(1));

            if (numbers == 999)
            {
                if (L == 90)
                    throw new Exception("Codice finita");
                else
                    L++;
            }
            else
            {
                numbers++;
            }

            code = L + numbers.ToString();
        }

        public override string ToString()
        {
            string tmp = "";
            Dictionary<string, Client>.KeyCollection keys = base.Keys;
            foreach (string k in keys)
            {
                tmp += k + " : " + base[k].Name + " : " + base[k].Dest + "\n";
            }

            return tmp;
            
        }

        public static void main(string[] args)
        {
            Console.WriteLine("Inserisci il codice iniziale nel formato Lnnn (dove L è  una stringa e n è una cifra): ");
            string codiceIniziale = Console.ReadLine();
            TourOperator dizionario = new TourOperator(codiceIniziale);

            foreach (string s in args)
            {
                string[] cliente = s.Split(':');

                dizionario.add(cliente[0], cliente[1]);
            }

            Console.Clear();
            Console.WriteLine(dizionario.ToString());
        }

        private class Coppia
        {
            string code;
            Client client;

            public Coppia(string aCode, Client aClient)
            {
                code = aCode; 
                client = aClient;
            }

            public override bool Equals(object obj)
            {
                Coppia tmpC = (Coppia)obj;
                return code.Equals(tmpC.code);
            }
        }
    }
    internal class Client
    {
        string name;
        string dest;

        public Client(string aName, string aDest)
        {
            Name = aName;
            Dest = aDest;
        }

        public string Name { get => name; set => name = value; }
        public string Dest { get => dest; set => dest = value; }
    }
}
