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
                foreach(var date in apartment.MeterReadingDates)
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

        public static string PrepareFileOutput()
        {
            Enum[] months = new Enum[3];

            switch (AccountingService.Quarter)
            {
                case Quarter.Q1:
                    months[0] = Q1.January;
                    months[1] = Q1.February;
                    months[2] = Q1.March;
                    break;
                case Quarter.Q2:
                    months[0] = Q2.April;
                    months[1] = Q2.May;
                    months[2] = Q2.June;
                    break;
                case Quarter.Q3:
                    months[0] = Q3.July;
                    months[1] = Q3.August;
                    months[2] = Q3.September;
                    break;
                case Quarter.Q4:
                    months[0] = Q4.October;
                    months[1] = Q4.November;
                    months[2] = Q4.December;
                    break;
                default:
                    throw new ArgumentException();
            }

            string result = "";

            result += Utils.MakeSeparator(58, 0, 6, 17, 27, 38, 46, 57);
            result += $"\n| Num | Name{' ',4} | {months[0], 6} | {months[1]} | {months[2]} | Expenses |\n";
            result += Utils.MakeSeparator(58, 0, 6, 17, 27, 38, 46, 57);


            foreach (var apartment in _apartments)
            {
                apartment.SetToString(new ApartmentToStringFileOutput());
                result += apartment.ToString();
                apartment.SetToString(new ApartmentToStringDefault());
            }

            result += "\n";
            result += Utils.MakeSeparator(58, 0, 4, 17, 27, 38, 46, 57);

            return result;
        }

    }
}
