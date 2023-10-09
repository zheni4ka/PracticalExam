using System.Globalization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "sukablyatsukablyatsuka";

            int b = a.Split("blyat").Count()-1;

            Console.WriteLine($"Count of word \"blyat\" : {b}");

        }
    }
}