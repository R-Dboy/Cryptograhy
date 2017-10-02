using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affineChiper
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Enter <1> to encrypt, <2> to  decrypt, <3> to brute force decrypt: ");
            string input = Console.ReadLine();   
                    
            while (input != "1" && input != "2" && input !="3")
            {

                Console.WriteLine("Enter <1> to encrypt, <2> to  decrypt, <3> to brute force decrypt: ");
                input = Console.ReadLine();
                Console.WriteLine("input = {0}", input);
            }

            switch (input)
            {
                case "1":
                    string s = selection1();
                    Console.WriteLine("Encrypted Message is: {0}", s);
                    break;
                case "2":
                    string g = selection2();
                    Console.WriteLine("Decrypted Message is: {0}", g);
                    break;
                case "3":
                    bruteForceAffineDecrypt();
                    break;
            }          
        }
        public static void bruteForceAffineDecrypt()
        {
            Console.WriteLine("Type message to decrypt (without spaces): ");
            string messgeEncrypt = Console.ReadLine();
            int a = 0;
            List<string> possibleMessages = new List<string>();
            string message = "";
            for (int i = 0; i<12; i++)
            {
                switch(i)
                {
                    case 0:
                        a = 1;
                        break;
                    case 1:
                        a = 3;
                        break;
                    case 2:
                        a = 5;
                        break;
                    case 3:
                        a = 7;
                        break;
                    case 4:
                        a = 9;
                        break;
                 
                    case 5:
                        a = 11;
                        break;
                    case 6:
                        a = 15;
                        break;
                    case 7:
                        a = 17;
                        break;
                    case 8:
                        a = 19;
                        break;
                    case 9:
                        a = 21;
                        break;
                    case 10:
                        a = 23;
                        break;
                    case 11:
                        a = 25;
                        break;
                   
                }
                for(int j =0;j<25;j++)
                {
                    message = AffineDecrypt(messgeEncrypt, a, j);
                 
                    Console.WriteLine("{0} a={1} b={2}", message, a, j);
                                     
                                       
                }
            }
           
           
        }

        public static string AffineEncrypt(string plainText, int a, int b)
        {
            string cipherText = "";

            // Put Plain Text (all capitals) into Character Array
            char[] chars = plainText.ToUpper().ToCharArray();

            // Compute e(x) = (ax + b)(mod m) for every character in the Plain Text
            foreach (char c in chars)
            {
                int x = Convert.ToInt32(c-65);
                cipherText += Convert.ToChar(((a * x + b) % 26)+65);
            }

            return cipherText;
        }
        ///
        /// This function takes cipher text and decrypts it using the Affine Cipher
        /// d(x) = aInverse * (e(x)  b)(mod m).
        ///
        public static string AffineDecrypt(string cipherText, int a, int b)
        {
            string plainText = "";

            // Get Multiplicative Inverse of a
            int aInverse = MultiplicativeInverse(a);

            // Put Cipher Text (all capitals) into Character Array
            char[] chars = cipherText.ToUpper().ToCharArray();

            // Computer d(x) = aInverse * (e(x)  b)(mod m)
            foreach (char c in chars)
            {
                int x = Convert.ToInt32(c - 65);
                if (x - b < 0) x = Convert.ToInt32(x) + 26;
                plainText += Convert.ToChar(((aInverse * (x - b)) % 26) + 65);
            }

            return plainText;
        }
        public static string selection2()
        {
            Console.WriteLine("Enter message to decrypt: ");
            string messgeDecrypt = Console.ReadLine();

            Console.WriteLine("Enter value of (a): ");
            string a = Console.ReadLine();
            int A = 0;
            while (int.TryParse(a, out A) == false)
            {
                Console.WriteLine("Enter value of (a) Must be an integer: ");
                a = Console.ReadLine();
            }

            Console.WriteLine("Enter value of (b): ");
            string b = Console.ReadLine();
            int B = 0;
            while (int.TryParse(b, out B) == false)
            {
                Console.WriteLine("Enter value (b) Must be an integer: ");
                b = Console.ReadLine();
            }

            string decryptedMsg = AffineDecrypt(messgeDecrypt, A, B);
            return decryptedMsg;
        }

        public static string selection1()
        {

            Console.WriteLine("Type message to encrypt (without spaces): ");
            string messgeEncrypt = Console.ReadLine();

            Console.WriteLine("Enter value of (a): ");
            string a = Console.ReadLine();

            int A = 0;

            while (int.TryParse(a, out A) == false)
            {
                Console.WriteLine("Enter value of (a): ");
                a = Console.ReadLine();
            }

            MultiplicativeInverse(A);

            Console.WriteLine("Enter value of (b): ");
            string b = Console.ReadLine();
            int B = 0;

            while (int.TryParse(b, out B) == false)
            {
                Console.WriteLine("Enter value of (b): ");
                b = Console.ReadLine();
            }

            string encryptedMsg = AffineEncrypt(messgeEncrypt, A, B);

            return encryptedMsg;
        }

 
        ///
        /// This functions returns the multiplicative inverse of integer a mod 26.
        ///
        public static int MultiplicativeInverse(int a)
        {
            for (int x = 1; x < 27; x++)
            {
                if ((a * x) % 26 == 1)
                {
                    return x;
                }
            }

            throw new Exception("No multiplicative inverse found!");
        }

    }
}
