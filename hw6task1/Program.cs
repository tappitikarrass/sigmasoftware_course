using System.IO;

namespace hw6task1
{
    public enum Q1 { January, February, March }
    public enum Q2 { April, May, June }
    public enum Q3 { July, August, September }
    public enum Q4 { October, November, December }
    public enum Quarter { Q1, Q2, Q3, Q4 }

    public class Program
    {
        public static void Main(string[] args)
        {
            var Service = AccountingService.GetInstance();

            const string filePath = @"..\..\..\input.txt";
            AccountingService.LoadFlatsFromFile(filePath);
            var flats = AccountingService.GetFlatsList();

            {
                string title = $"| #{' ',1} | Name{' ',4} | Reading{' ',3} | Start{' ',2} | End{' ',2}  |";
                string separator = Utils.MakeSeparator(title.Length, 0, 5, 16, 29, 39, 48);

                Console.WriteLine("Apartments list:\n" + separator + "\n" + title + "\n" + separator);
                foreach (var flat in flats)
                {
                    Console.WriteLine(flat);
                }

                Console.WriteLine(separator);
            }
            {
                string title = $"| #{' ',1} | Name{' ',4} | Reading{' ',3} | Start{' ',2} | End{' ',2}  |";
                string separator = Utils.MakeSeparator(title.Length, 0, 5, 16, 29, 39, 48);

                int maxDebtOwnerIndex = AccountingService.FindMaxDebtOwner();
                int noUsageApartmentIndex = AccountingService.FindNoUsageApartment();

                Console.WriteLine("\nMax debt entry: \n{0}\n{2}\n{0}\n{1}\n{0}",
                    separator, AccountingService.GetFlatsList()[maxDebtOwnerIndex], title);
                Console.WriteLine("Max debt: {0} kW",
                    AccountingService.GetFlatsList()[maxDebtOwnerIndex].getDebt());
                Console.WriteLine("\nNo usage apartment: \n{0}\n{2}\n{0}\n{1}\n{0}",
                    separator, AccountingService.GetFlatsList()[noUsageApartmentIndex], title);
            }
            {
                AccountingService.kwPrice = 1.5;
                string separator = Utils.MakeSeparator(33, 0, 5, 15, 32);
                Console.WriteLine("\nExpenses per apartment: \n{0}{1}\n{0}",
                    separator, AccountingService.GetExpensesPerApartment());
            }
            {
                Console.WriteLine("\nDays passed from last meter reading: {0}",
                    AccountingService.TimePassedFromLastMeterReading());
            }
            using(TextWriter writer = File.CreateText(@"..\..\..\output.txt"))
            {
                string fileOutput = AccountingService.PrepareFileOutput();
                Console.WriteLine(fileOutput);
                writer.WriteLine(fileOutput);
            }
        }
    }
}

public static class Utils
{
    public static string MakeSeparator(int length, params int[] positions)
    {
        string separator = String.Concat(Enumerable.Repeat("-", length));
        char[] temp = separator.ToCharArray();

        foreach (var position in positions)
        {
            temp[position] = '+';
        }
        separator = new string(temp);

        return separator;
    }
}
