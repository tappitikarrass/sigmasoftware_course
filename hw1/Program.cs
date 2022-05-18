namespace hw1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Product1 = new Product("Potato", 3, 5);
            var Product2 = new Product("Tomato", 5, 1);
            var Product3 = new Product("Apple", 4, 2);

            var Buy1 = new Buy();
            Buy1.AddProduct(Product1, 3);
            Buy1.AddProduct(Product3, 5);
            Buy1.AddProduct(Product1, 7);

            Check.PrintBuyInfo(Buy1);
        }
    }
}