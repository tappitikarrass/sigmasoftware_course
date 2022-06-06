namespace hw6task1
{
    public enum Q1 { January, February, March }
    public enum Q2 { April, May, June }
    public enum Q3 { July, August, September }
    public enum Q4 { October, November, December }
    public enum Quarter { Q1, Q2, Q3, Q4}
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var Service = AccountingService.GetInstance();

            const string filePath = @"..\..\..\input.txt";
            AccountingService.LoadFlatsFromFile(filePath);
            var flats = AccountingService.GetFlatsList();

            {
                const string title = "| # | Name        | Reading    | Start | End  |";
                string separator = MakeSeparator(title.Length, 0, 4, 18, 31, 39, 46);

                Console.WriteLine("Apartments list:\n" + separator + "\n" + title + "\n" + separator);
                foreach (var flat in flats)
                {
                    Console.WriteLine(flat);
                }
                
                Console.WriteLine(separator);
            }
            {
                string separator = MakeSeparator(47, 0, 4, 18, 31, 39, 46);
                
                int maxDebtOwnerIndex = AccountingService.FindMaxDebtOwner();
                int noUsageApartmentIndex = AccountingService.FindNoUsageApartment();

                Console.WriteLine("\nMax debt entry: \n{0}\n{1}\n{0}",
                    separator, AccountingService.GetFlatsList()[maxDebtOwnerIndex]);
                Console.WriteLine("Max debt: {0} kW",
                    AccountingService.GetFlatsList()[maxDebtOwnerIndex].getDebt());
                Console.WriteLine("\nNo usage apartment: \n{0}\n{1}\n{0}",
                    separator, AccountingService.GetFlatsList()[noUsageApartmentIndex]);
            }
            {
                AccountingService.kwPrice = 1.5;
                string separator = MakeSeparator(33, 0, 4, 18, 32);
                Console.WriteLine("\nExpenses per apartment: \n{0}{1}\n{0}",
                    separator, AccountingService.GetExpensesPerApartment());
            }
            {
                Console.WriteLine("\nDays passed from last meter reading: {0}",
                    AccountingService.TimePassedFromLastMeterReading());
            }
        }

        private static string MakeSeparator(int length, params int[] positions)
        {
            string separator = String.Concat(Enumerable.Repeat("-", length));
            char[] temp = separator.ToCharArray();
            
            foreach(var position in positions)
            {
                temp[position] = '+';
            }
            separator = new string(temp);

            return separator;
        }
    }
}