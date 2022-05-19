namespace hw2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Product1 = new Product("Potato", 3, 5);
            var Product2 = new Product("Tomato", 5, 1);
            var Product3 = new Product("Apple", 4, 2);

            /* var Buy1 = new Buy(new KeyValuePair<Product, int>(Product1,3 ),
                new KeyValuePair<Product, int>(Product3, 5),
                new KeyValuePair<Product, int>(Product1, 7));
            Buy1.AddProduct(Product1, 3);
            Buy1.AddProduct(Product3, 5);
            Buy1.AddProduct(Product1, 7);

            Check.PrintBuyInfo(Buy1);
            */

            var DairyProduct1 = new Dairy_products("Milk", 10, 1, 7);
            var Meat1 = new Meat("Chicken breasts", 15, 1, Category.HighSort, Type.chicken);
            var Meat2 = new Meat("Chicken wings", 15, 1, Category.Sort1, Type.chicken);
            var Meat3 = new Meat("Mutton", 15, 1, Category.Sort2, Type.mutton);
            //Check.PrintProductInfo(Meat1);
            //Check.PrintProductInfo(DairyProduct1);

            var Storage1 = new Storage(Meat1, Meat2, DairyProduct1, Meat3);
            Storage1.ShowDialogue();
            Console.WriteLine(Storage1[0]);
        }
    }
}