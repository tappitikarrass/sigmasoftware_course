namespace hw1
{
    public class Buy
    {
        public Dictionary<Product, int> ProductsDict { get; private set; }
        public int TotalQuantity { get; private set; }
        public int TotalWeight { get; private set; }
        public int TotalPrice { get; private set; }

        public Buy(params KeyValuePair<Product, int>[] products)
        {
            ProductsDict = new Dictionary<Product, int>();
            foreach(var product in products)
            {
                AddProduct(product.Key, product.Value);
            }
        }

        public Buy()
        {
            ProductsDict = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException();
            }

            if (ProductsDict.ContainsKey(product))
            {
                ProductsDict[product] += quantity;
                return;
            }

            ProductsDict.Add(product, quantity);
            UpdateTotals();
        }

        public void RemoveProduct(Product product)
        {
            if (!ProductsDict.ContainsKey(product))
            ProductsDict.Remove(product);
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            TotalQuantity = TotalPrice = TotalWeight = 0;

            foreach(var entry in ProductsDict)
            {
                TotalQuantity += entry.Value;
                TotalPrice += entry.Key.Price;
                TotalWeight += entry.Key.Weight;
            }
        }
    }
}