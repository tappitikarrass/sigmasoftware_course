namespace hw2
{
	public enum Category
	{
		HighSort,
		Sort1,
		Sort2
	}

	public enum Type
	{
		mutton,	// баранина
		veal,	// телятина
		pork,	// cвинина
		chicken // курятина
	}

	public class Meat : Product
    {
		public Category MeatCategory { get; private set; }
		public Type MeatType { get; private set; }
        public Meat(string name, int price, int weight, Category category, Type type) : base(name, price, weight)
        {
			MeatCategory = category;
			MeatType = type;
        }
    }

	public class Dairy_products : Product
    {
		public DateTime timeToExpire { get; private set; }
		public Dairy_products(string name, int price, int weight, DateTime date) : base (name, price, weight)
        {
			timeToExpire = date;
        }
    }
}
