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
                $"| {Number} | {Owner} \t  | {meterReadingDates[0]} | {readingsPairs[0].Key}  | {readingsPairs[0].Value} |\n" +
                $"| {Number} | {Owner} \t  | {meterReadingDates[1]} | {readingsPairs[1].Key}  | {readingsPairs[1].Value} |\n" +
                $"| {Number} | {Owner} \t  | {meterReadingDates[2]} | {readingsPairs[2].Key}  | {readingsPairs[2].Value} |";
        }
    }

    public class ApartmentToStringTotalExpenses : IApartmentToString
    {
        public string ToString(Apartment apartment)
        {
            var Number = apartment.Number;
            var Owner = apartment.Owner;
            var Expenses = AccountingService.kwPrice * apartment.getDebt();
            return $"| {Number} | {Owner}\t  | {Expenses:N2}   \t|";
        }
    }
}
