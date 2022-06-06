namespace hw6task1
{
    public interface IApartmentToString
    {
        public string ToString(Apartment apartment);
    }

    public class ApartmentToStringDefault : IApartmentToString
    {
        public string ToString(Apartment apartment)
        {
            var Number = apartment.Number;
            var Owner = apartment.Owner;
            var meterReadingDates = apartment.meterReadingDates;
            var readingsPairs = apartment.readingsPairs;

            return $"" +
                $"| {Number,2} | {Owner,8} | {meterReadingDates[0],10} | {readingsPairs[0].Key, 6}  | {readingsPairs[0].Value, 6} |\n" +
                $"| {Number,2} | {Owner,8} | {meterReadingDates[1],10} | {readingsPairs[1].Key, 6}  | {readingsPairs[1].Value, 6} |\n" +
                $"| {Number,2} | {Owner,8} | {meterReadingDates[2],10} | {readingsPairs[2].Key, 6}  | {readingsPairs[2].Value, 6} |";
        }
    }

    public class ApartmentToStringTotalExpenses : IApartmentToString
    {
        public string ToString(Apartment apartment)
        {
            var Number = apartment.Number;
            var Owner = apartment.Owner;
            var Expenses = AccountingService.kwPrice * apartment.getDebt();
            return $"| {Number,2} | {Owner,6}  | {Expenses,5:N2}   \t|";
        }
    }

    public class ApartmentToStringFileOutput : IApartmentToString
    {
        public string ToString(Apartment apartment)
        {
            double expenses = apartment.getDebt() * AccountingService.kwPrice;
            double month1debt = apartment.readingsPairs[0].Value - apartment.readingsPairs[0].Key;
            double month2debt = apartment.readingsPairs[1].Value - apartment.readingsPairs[1].Key;
            double month3debt = apartment.readingsPairs[2].Value - apartment.readingsPairs[2].Key;

            return $"\n| {apartment.Number, 3} | {apartment.Owner,6}\t " +
                $"| {month1debt,7} | {month2debt,8} | {month3debt,5} | {expenses, 8:N2} |";
        }
    }

}
