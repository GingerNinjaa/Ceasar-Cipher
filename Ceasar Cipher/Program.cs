using System;
using System.IO;
using System.Net.Mime;
using System.Text;

namespace Ceasar_Cipher
{
    class Program
    {
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }

        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }

        public static void ENC()
        {
            Console.WriteLine("Type a path to txt that you want to encrypt: ");
            string path = Console.ReadLine();

            var content = File.ReadAllText(path);

            Console.WriteLine("\n");

            Console.Write("Enter your Key ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            Console.WriteLine("Encrypted Data ");

            string cipherText = Encipher(content, key);
            Console.WriteLine(cipherText);
            Console.Write("\n");

            Console.WriteLine("Decrypted Data: ");

            string t = Decipher(cipherText, key);
            Console.WriteLine(t);
            Console.Write("\n");

            path = Path.GetPathRoot(path) + Path.GetFileNameWithoutExtension(path) + "ENC.txt";
            Console.WriteLine("Encryptet file was save in this path -> " + path);
            File.WriteAllText(path, cipherText, Encoding.UTF8);
            Console.ReadKey();
        }

        public static void DEC()
        {
            Console.WriteLine("Type a path to txt that you want to encrypt: ");
            string path = Console.ReadLine();

            var content = File.ReadAllText(path);

            Console.WriteLine("\n");

            Console.Write("Enter your Key ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            Console.WriteLine("Decrypted Data: ");

            string t = Decipher(content, key);
            Console.WriteLine(t);
            Console.Write("\n");

            path = Path.GetPathRoot(path) + Path.GetFileNameWithoutExtension(path) + "DEC.txt";
            Console.WriteLine("Encryptet file was save in this path -> " + path);
            File.WriteAllText(path, t, Encoding.UTF8);
            Console.ReadKey();
        }


        static void Main(string[] args)
        {

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=======================================================================");
                Console.WriteLine("1) Szyfrowanie ");
                Console.WriteLine("2) Deszyfrowanie ");
                Console.WriteLine("3) Wyjście ");
                Console.Write("Wybór: ");
                var pick = Console.ReadLine();

                switch (pick)
                {
                    case "1":
                        ENC();
                        break;
                    case "2":
                        DEC();
                        break;
                    case "3":
                       Environment.Exit(0);
                        break;
                }
                Console.Clear();
            } while (true);
          

        }
    }
}
