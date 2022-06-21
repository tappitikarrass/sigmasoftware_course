namespace hw6task1
{
    public class Apartment
    {
        private IApartmentToString _strategy;
        public int Number { get; }
        public string Owner { get; }
        public DateOnly[] MeterReadingDates { get; }
        public KeyValuePair<int, int>[] ReadingsPairs { get; }

        public Apartment()
        {
            _strategy = new ApartmentToStringDefault();
            Number = 0;
            Owner = "";
            MeterReadingDates = new DateOnly[1];
            ReadingsPairs = new KeyValuePair<int, int>[1];
        }

        public Apartment(IApartmentToString strategy) : this()
        {
            _strategy = strategy;
        }

        public Apartment(int Number, string Owner,
            DateOnly[] meterReadingDates,
            KeyValuePair<int, int>[] readingsPairs) : this()
        {
            if (meterReadingDates.Length < 3 || readingsPairs.Length < 3 ||
                meterReadingDates.Length > 3 || readingsPairs.Length > 3)
            {
                throw new ArgumentException();
            }
            this.Number = Number;
            this.Owner = Owner;
            this.MeterReadingDates = meterReadingDates;
            this.ReadingsPairs = readingsPairs;
        }

        public Apartment(string apartmentString) : this()
        {
            string[] props = apartmentString.Split(" ");
            DateOnly[] dates = new DateOnly[1];
            KeyValuePair<int, int>[] readings = new KeyValuePair<int, int>[1];
            try
            {
                dates = new DateOnly[]
                {
                    DateOnly.Parse(props[2]),
                    DateOnly.Parse(props[5]),
                    DateOnly.Parse(props[8]),
                };
                readings = new KeyValuePair<int, int>[]
                {
                    new KeyValuePair<int, int>(Int32.Parse(props[3]), Int32.Parse(props[4])),
                    new KeyValuePair<int, int>(Int32.Parse(props[6]), Int32.Parse(props[7])),
                    new KeyValuePair<int, int>(Int32.Parse(props[9]), Int32.Parse(props[10])),
                };
            } catch (FormatException)
            {
                Console.WriteLine("Incorrect date or reading set!");
                System.Environment.Exit(1);
            }

            Owner = props[1];
            try
            {
                Number = Int32.Parse(props[0]);
            } catch (FormatException)
            {
                Console.WriteLine("Incorrect apartment number set!");
                System.Environment.Exit(1);
            }
            MeterReadingDates = dates;
            ReadingsPairs = readings;
        }

        public void SetToString(IApartmentToString strategy)
        {
            _strategy = strategy;
        }

        public double getDebt()
        {
            double debt = 0;

            foreach(var reading in ReadingsPairs)
            {
                debt += reading.Value - reading.Key;
            }

            return debt;
        }

        public override string ToString()
        {
            return _strategy.ToString(this);
        }
    }
}
