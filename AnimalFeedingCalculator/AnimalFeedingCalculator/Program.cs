using AnimalFeedingCalculator.Backend;
using AnimalFeedingCalculator.Common;
using System;
using System.Data;
using System.IO;

namespace AnimalFeedingCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Animal feeding Calculatore");
            Console.WriteLine("Press enter to get Total cost involved to feed all the animals at zoo.");
            Console.ReadLine();

            PerDayCalculator pc = new PerDayCalculator();
            double d = pc.CalculatePerDayRate();
            Console.WriteLine("Total cost for the animals currently at the zoo : " + d);
            Console.ReadLine();
        }
    }
}
