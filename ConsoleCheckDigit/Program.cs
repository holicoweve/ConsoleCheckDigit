using System;

namespace ConsoleCheckDigit
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] ctnrList = { "MSKU2666542", "NYKU3086856", "HLXU1234567" };
            foreach (string containerNumber in ctnrList)
            {
                string result = CtnrCheckDigit.IsValid(containerNumber) ? "Valid" : "Invalid";
                Console.WriteLine($" {containerNumber} is {result}");
            }

            Console.WriteLine();
            Console.WriteLine("Pres any key to exit...");
            Console.ReadKey();
        }
    }

    internal class CtnrCheckDigit
    {
        static public bool IsValid(string containerNumber)
        {
            if (CheckDigit(containerNumber.Substring(0,10)) == containerNumber[10])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public char CheckDigit(string containerNumber)
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += ToInt(containerNumber[i]) * (int)Math.Pow(2, i);
            }

            int CheckDigit = sum - (sum / 11 * 11);
            return (char)(CheckDigit + 48);
        }

        static internal int ToInt(char source)
        {
            if (source >= 48 && source <= 57)
                return source - 48;

            source = char.ToUpper(source);

            if (source >= 65 && source <= 90)
                return (source - 55) + (source - 55) / 11;

            return 0;
        }
    }
}