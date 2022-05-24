namespace hw2
{
    public interface IDialogue
    {
        public static Product Show() => throw new NotImplementedException();
    }

    public class AddProductDialogue : IDialogue
    {
        public static Product Show()
        {
            int price, weight;

            Console.Write("enter name: ");
            string name = "" + Console.ReadLine();
            Console.Write("enter price: ");
            while (!int.TryParse(Console.ReadLine(), out price));
            Console.Write("enter weight: ");
            while (!int.TryParse(Console.ReadLine(), out weight));

            return new Product(name, price, weight);
        }
    }

    public class AddMeatDialogue : AddProductDialogue
    {
        public static new Product Show()
        {
            var product = AddProductDialogue.Show();

            bool isRunning = true;
            Category category = Category.HighSort;
            Type type = Type.mutton;

            while (isRunning)
            {
                // select category
                Console.WriteLine("meat categories:" +
                    "\n\t1 - high sort" +
                    "\n\t2 - sort 1" +
                    "\n\t3 - sort 2" +
                    "\n-> ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        category = Category.HighSort;
                        isRunning = false;
                        break;
                    case 2:
                        category = Category.Sort1;
                        isRunning = false;
                        break;
                    case 3:
                        category = Category.Sort2;
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("[E] No such category!");
                        continue;
                }
                // select type
                Console.WriteLine("meat type:" +
                    "\n\t1 - mutton" +
                    "\n\t2 - veal" +
                    "\n\t3 - pork" +
                    "\n\t4 - chicken" +
                    "\n-> ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        type = Type.mutton;
                        isRunning = false;
                        break;
                    case 2:
                        type = Type.veal;
                        isRunning = false;
                        break;
                    case 3:
                        type = Type.pork;
                        isRunning = false;
                        break;
                    case 4:
                        type = Type.chicken;
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("[E] No such type!");
                        continue;
                }
            }

            return new Meat(product.Name, product.Price, product.Weight, category, type);
        }
    }

    public class AddDiaryProductsDialogue : AddProductDialogue
    {
        public static new Product Show()
        {
            var product = AddProductDialogue.Show();
            Console.WriteLine("enter expiration period: ");
            int timeToExpire = Convert.ToInt32(Console.ReadLine());

            return new Dairy_products(product.Name, product.Price, product.Weight, timeToExpire);
        }
    }
}
