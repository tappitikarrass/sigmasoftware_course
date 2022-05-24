namespace hw2
{
    public class Storage
    {
        private List<Product> _products;
        public Storage(params Product[] products)
        {
            _products = products == null ? new List<Product>() : new List<Product>(products);
        }

        public Product this[int index]
        {
            get
            {
                if (index < 0 && index > _products.Count)
                {
                    return _products[index];
                }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index < 0 && index > _products.Count)
                {
                    _products[index] = value;
                }
                throw new ArgumentOutOfRangeException();
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
                foreach(var product in _products)
                {
                    product.SetPrice((int)(product.Price * (percentage / 100d)));
                }
                break;
            }
        }

        private void PrintProductsInfo()
        {
            foreach(var product in _products)
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
                        _products.Add(AddProductDialogue.Show());
                        isRunning = false;
                        break;
                    case 2:
                        _products.Add(AddDiaryProductsDialogue.Show());
                        isRunning = false;
                        break;
                    case 3:
                        _products.Add(AddMeatDialogue.Show());
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
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].GetType() == typeof(Meat))
                {
                    Console.WriteLine("\n--- {0}", i + 1);
                    Console.WriteLine(_products[i]);
                }
            }
        }

        private void RemoveDialogue()
        {                
            while(true)
            {
                if (_products.Count == 0)
                {
                    Console.WriteLine("[E] Products list is already empty!");
                    break;
                }
                // print products menu
                Console.WriteLine("select product:");
                for (int i = 0; i < _products.Count; i++)
                {
                    Console.WriteLine("\n--- {0}" +
                        "\n{1}", i + 1, _products[i]);
                }
                Console.Write("\n-> ");
                // read & process value
                int option = Convert.ToInt32(Console.ReadLine());
                if (option > _products.Count || option <= 0)
                {
                    Console.WriteLine("[E] No such product!");
                    continue;
                }
                _products.RemoveAt(option - 1);
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
