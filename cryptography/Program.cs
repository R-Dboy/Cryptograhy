using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptography
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
        static void Main(string[] args)
        {            
            Console.WriteLine("Choose from following options: \n(1)ENCTRYPT \n(2)DECRYPT \n(3)BRUTE FORCE DECRYPT");
            string input = Console.ReadLine();
            while(input!="1"&&input!="2"&&input!="3")
            {
                Console.WriteLine("Select from available options only!");
                input = Console.ReadLine();
            }

            switch(input)
            {
                case "1":
                    string messgaE = Encrypt();
                    Console.WriteLine(messgaE);
                    break;
                case "2":
                    string messageD = Decrypt();
                    Console.WriteLine(messageD);
                    break;
                case "3":
                    bruteForceDecrypt();
                    break;

            }
        }

        public static string Encrypt()
        {
            string messageToEncrypt = "";
            string messageEncrypted = "";
            int cipherKey = 0;

            Console.WriteLine("Enter Message to encrypt: ");
            messageToEncrypt = Console.ReadLine();

            Console.WriteLine("Enter key: ");
            cipherKey = Convert.ToInt32(Console.ReadLine());

            messageEncrypted = Encipher(messageToEncrypt, cipherKey);
            return messageEncrypted;
        }

        public static string Decrypt()
        {
            string messageToDecrypt = "";
            string messageDecrypted = "";
            int cipherKey = 0;

            Console.WriteLine("Enter Message to decrypt: ");
            messageToDecrypt = Console.ReadLine();

            Console.WriteLine("Enter key: ");
            cipherKey = Convert.ToInt32(Console.ReadLine());

            messageDecrypted = Decipher(messageToDecrypt, cipherKey);
            return messageDecrypted;
        }

        public static void bruteForceDecrypt()
        {
            string messageToDecrypt = "";
            string messageDecrypted = "";

            Console.WriteLine("Enter Message to brute force decrypt: ");
            messageToDecrypt = Console.ReadLine();

            for(int i = 0; i<25;i++)
            {
                messageDecrypted = Decipher(messageToDecrypt, i);
                Console.WriteLine("{0}  key={1}",messageDecrypted, i);
            }
        }
    }
}
