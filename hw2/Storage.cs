namespace hw2
{
    public class Storage
    {
        public List<Product> ProductsList { get; private set; }
        public Storage(params Product[] products)
        {
            ProductsList = new List<Product>();
            foreach(var product in products)
            {
                ProductsList.Add(product);
            }
        }

        public Product this[int i]
        {
            get
            {
                return ProductsList[i];
            }
        }

        public void ShowDialogue()
        {
            bool isRunning = true;
            while (isRunning)
            {
                PrintOptionsMsg();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddDialogue();
                        break;
                    case 2:
                        RemoveDialogue();
                        break;
                    case 3:
                        PrintProductsInfo();
                        break;
                    case 4:
                        PrintAllMeatProducts();
                        break;
                    case 5:
                        ChangeAllPricesByPercent();
                        break;
                    case 10:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("[E] No such option!");
                        continue;
                }
            }
        }

        private void ChangeAllPricesByPercent()
        {
            while (true)
            {
                Console.WriteLine("enter percent: ");
                int percentage = Convert.ToInt32(Console.ReadLine());
                if (percentage < 0)
                {
                    Console.WriteLine("[E] Invalid percentage value!");
                    continue;
                }
                foreach(var product in ProductsList)
                {
                    product.SetPrice((int)(product.Price * (percentage / 100d)));
                }
                break;
            }
        }

        private void PrintProductsInfo()
        {
            foreach(var product in ProductsList)
            {
                Console.WriteLine(product + "\n");
            }
        }

        private void AddDialogue()
        {
            bool isRunning = true;

            while(isRunning)
            {
                Console.Write("select product type:" +
                    "\n\t1 - Product" +
                    "\n\t2 - Dairy_products" +
                    "\n\t3 - Meat" +
                    "\n-> ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ProductsList.Add(AddProductDialogue.Show());
                        isRunning = false;
                        break;
                    case 2:
                        ProductsList.Add(AddDiaryProductsDialogue.Show());
                        isRunning = false;
                        break;
                    case 3:
                        ProductsList.Add(AddMeatDialogue.Show());
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("[E] No such type of product!");
                        continue;
                }
            }
        }

        private void PrintAllMeatProducts()
        {
            for (int i = 0; i < ProductsList.Count; i++)
            {
                if (ProductsList[i].GetType() == typeof(Meat))
                {
                    Console.WriteLine("\n--- {0}", i + 1);
                    Console.WriteLine(ProductsList[i]);
                }
            }
        }

        private void RemoveDialogue()
        {                
            while(true)
            {
                if (ProductsList.Count == 0)
                {
                    Console.WriteLine("[E] Products list is already empty!");
                    break;
                }
                // print products menu
                Console.WriteLine("select product:");
                for (int i = 0; i < ProductsList.Count; i++)
                {
                    Console.WriteLine("\n--- {0}" +
                        "\n{1}", i + 1, ProductsList[i]);
                }
                Console.Write("\n-> ");
                // read & process value
                int option = Convert.ToInt32(Console.ReadLine());
                if (option > ProductsList.Count || option <= 0)
                {
                    Console.WriteLine("[E] No such product!");
                    continue;
                }
                ProductsList.RemoveAt(option - 1);
                break;
            }
        }

        private void PrintOptionsMsg()
        {
                Console.Write("options:" +
                    "\n\t1 - add product" +
                    "\n\t2 - remove product" +
                    "\n\t3 - get products info" +
                    "\n\t4 - find all meat products" +
                    "\n\t5 - change all prices by percent" +
                    "\n\t10 - exit" +
                    "\n-> ");
        }
    }
}
