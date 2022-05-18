namespace hw1
{
    public class Check
    {
        public static void PrintBuyInfo(Buy buy)
        {
            foreach(var entry in buy.ProductsDict)
            {
                PrintProductInfo(entry.Key);
                Console.WriteLine("\nquantity: {0}\n", entry.Value);
            }
            Console.WriteLine("total quantity: {0}\ntotal price: {1}\ntotal weight: {2}",
                buy.TotalQuantity, buy.TotalPrice, buy.TotalWeight);
        }

        public static void PrintProductInfo(Product product)
        {
            Console.Write("name: {0}\nprice: {1}$\nweight: {2}kg",
                product.Name, product.Price, product.Weight);
        }
    }
}