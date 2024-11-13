using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Assignment_2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Assignment 2.3.2
             * 
             * Design a tip calculator : enter the bill total, tip % and display grand total after adding tip.
             * Use the format specifiers to display currency, % symbol.
             * 
             * Console.WriteLine(amount.ToString("C")); // Outputs: $12,345.67
             * Console.WriteLine(number.ToString("P")); // Outputs: 12.34%
             */

            BillCalculator calculator = new ();
                
            Console.WriteLine("Tip Calculator");
            Console.WriteLine("\nBill total:");
            calculator.Bill = Convert.ToDouble( Console.ReadLine() );

            double billTotal = calculator.Bill * calculator.taxModifier;
            double tax = calculator.taxModifier - 1;
            Console.WriteLine($"\nPlus {tax:P} tax: {billTotal:C} ({billTotal})");

            double tip18Perc = 0.18 * calculator.Bill;
            double tip20Perc = 0.20 * calculator.Bill;
            double tip22Perc = 0.22 * calculator.Bill;
            Console.WriteLine($"\nTip recommendations: 18% ({tip18Perc:C}) 20% ({tip20Perc:C}) 22% ({tip22Perc:C})");
            Console.WriteLine("Enter tip %:");
            calculator.TipPerc = Convert.ToDouble( Console.ReadLine() );

            double tip = (calculator.TipPerc / 100) * calculator.Bill;
            double grandTotal = billTotal + Math.Round(tip, 2);
            Console.WriteLine($"\nYou tipped {calculator.TipPerc/100:P} or {tip:C}\nGrand total: {grandTotal:C}");
            Console.Read();
        }
    }

    public class BillCalculator
    {
        // fields
        public double taxModifier = 1.1;

        // properties
        public double Bill { get; set; }
        public double TipPerc { get; set; }
    }
}
