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
            var number = apartment.Number;
            var owner = apartment.Owner;
            var meterReadingDates = apartment.MeterReadingDates;
            var readingsPairs = apartment.ReadingsPairs;

            return $"" +
                $"| {number,2} | {owner,8} | {meterReadingDates[0],10} | {readingsPairs[0].Key, 6}  | {readingsPairs[0].Value, 6} |\n" +
                $"| {number,2} | {owner,8} | {meterReadingDates[1],10} | {readingsPairs[1].Key, 6}  | {readingsPairs[1].Value, 6} |\n" +
                $"| {number,2} | {owner,8} | {meterReadingDates[2],10} | {readingsPairs[2].Key, 6}  | {readingsPairs[2].Value, 6} |";
        }
    }

    public class ApartmentToStringTotalExpenses : IApartmentToString
    {
        public string ToString(Apartment apartment)
        {
            var number = apartment.Number;
            var owner = apartment.Owner;
            var expenses = AccountingService.kwPrice * apartment.getDebt();
            return $"| {number,2} | {owner,6}  | {expenses,5:N2}   \t|";
        }
    }

    public class ApartmentToStringFileOutput : IApartmentToString
    {
        public string ToString(Apartment apartment)
        {
            double expenses = apartment.getDebt() * AccountingService.kwPrice;
            double month1debt = apartment.ReadingsPairs[0].Value - apartment.ReadingsPairs[0].Key;
            double month2debt = apartment.ReadingsPairs[1].Value - apartment.ReadingsPairs[1].Key;
            double month3debt = apartment.ReadingsPairs[2].Value - apartment.ReadingsPairs[2].Key;

            return $"\n| {apartment.Number, 3} | {apartment.Owner,6}\t " +
                $"| {month1debt,7} | {month2debt,8} | {month3debt,5} | {expenses, 8:N2} |";
        }
    }

}
