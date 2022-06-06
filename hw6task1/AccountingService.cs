namespace hw6task1
{
    public class AccountingService
    {
        public static Quarter Quarter { get; private set; }
        private static AccountingService? _instance;
        private static List<Apartment> _apartments;
        private static double _kwPrice;
        public static double kwPrice
        {
            get
            {
                return _kwPrice;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                } else
                {
                    _kwPrice = value;
                }
            }
        }

        private AccountingService()
        {
            _kwPrice = 1.0;
            _apartments = new List<Apartment>();
            Quarter = Quarter.Q1;
        }

        public static AccountingService GetInstance()
        {
            if  (_instance == null)
            {
                _instance = new AccountingService();
            }
            return _instance;
        }

        public static List<Apartment> GetFlatsList()
        {
            return _apartments;
        }

        public static void LoadFlatsFromFile(string filePath)
        {
            using (TextReader reader = File.OpenText(filePath))
            {
                string line = "" + reader.ReadLine();
                string[] header = line.Split(" ");
                int apartmentsCount, quarter;
                (apartmentsCount, quarter) = (0, 0);

                try
                {
                    apartmentsCount = Int32.Parse(header[0]);
                    quarter = Int32.Parse(header[1]);

                    if (quarter > 4 || quarter < 1 || apartmentsCount < 1)
                    {
                        throw new ArgumentException();
                    }

                } catch (FormatException)
                {
                    Console.WriteLine("Incorrect first line!");
                    System.Environment.Exit(1);
                } catch (ArgumentException)
                {
                    Console.WriteLine("Incorrect quater or apartments count set!");
                    System.Environment.Exit(1);
                }

                switch (quarter)
                {
                    case 1:
                        Quarter = Quarter.Q1;
                        break;
                    case 2:
                        Quarter = Quarter.Q2;
                        break;
                    case 3:
                        Quarter = Quarter.Q3;
                        break;
                    case 4:
                        Quarter = Quarter.Q4;
                        break;
                    default:
                        throw new ArgumentException();
                }

                try
                {
                    for (int i = 0; i < apartmentsCount; i++)
                    {
                        Apartment apartment = new Apartment("" + reader.ReadLine());
                        foreach (var currentFlat in _apartments)
                        {
                            if (apartment.Number == currentFlat.Number)
                            {
                                throw new Exception();
                            }
                        }
                        _apartments.Add(apartment);
                    }
                } catch (Exception)
                {
                    Console.WriteLine("Duplicate apartment number found!");
                    System.Environment.Exit(1);
                }
            }
        }

        private static int FindExtremumIndex(bool min = false)
        {
            int apartmentIndex = 0;
            double Debt = 0;
            
            foreach(var apartment in _apartments)
            {
                double debt = apartment.getDebt();

                if (min)
                {
                    if (debt <= Debt)
                    {
                        Debt = debt;
                        apartmentIndex = _apartments.IndexOf(apartment);
                    }
                    continue;
                }
                if (debt > Debt)
                {
                    Debt = debt;
                    apartmentIndex = _apartments.IndexOf(apartment);
                }
            }

            return apartmentIndex;
        }

        public static int FindMaxDebtOwner()
        {
            return FindExtremumIndex();
        }

        public static int FindNoUsageApartment()
        {
            int index = FindExtremumIndex(min: true);
            return index;
        }

        public static string GetExpensesPerApartment()
        {
            string result = "";
            foreach(var apartment in _apartments)
            {
                apartment.SetToString(new ApartmentToStringTotalExpenses());
                result += "\n" + apartment.ToString();
                apartment.SetToString(new ApartmentToStringDefault());
            }
            return result;
        }

        public static int TimePassedFromLastMeterReading()
        {
            // TODO: Improve stupid DateOnly to DateTime and backwards convertation
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            int maxDifference = 0;
            foreach(var apartment in _apartments)
            {
                foreach(var date in apartment.meterReadingDates)
                {
                    DateTime temp = new DateTime(date.Year, date.Month, date.Day);
                    DateTime tempCurrentDate = new DateTime(currentDate.Year,
                        currentDate.Month, currentDate.Day);

                    int difference = (int)(tempCurrentDate - temp).TotalDays;

                    if(difference > maxDifference)
                    {
                        maxDifference = difference;
                    }
                }
            }
            return maxDifference;
        }
    }
}
