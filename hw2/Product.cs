namespace hw2
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; protected set; }
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

        public void SetPrice(int price)
        {
            Price = price;
        }

        public void ChangePrice(int price)
        {
            if (price < 0)
            {
                throw new ArgumentException();
            }
            Price = price;
        }

        public override string ToString()
        {
            return String.Format("name: {0}\nprice: {1}$\nweight: {2}kg",
                this.Name, this.Price, this.Weight);
        }
    }
}