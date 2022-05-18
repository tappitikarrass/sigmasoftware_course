namespace hw1
{
    public class Product
    {
        public string Name { get; set; }
        private int _price;
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _price = value;
            }
        }
        private int _weight;
        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _weight = value;
            }
        }

        public Product(string name, int price, int weight)
        {
            if (price < 0 || weight < 0)
            {
                throw new ArgumentException();
            }
            Name = name;
            Price = price;
            Weight = weight;
        }
    }
}