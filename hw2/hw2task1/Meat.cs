namespace hw2
{	public enum Category
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

		public new void ChangePrice(int percentage)
		{
			switch(MeatCategory)
            {
				case Category.HighSort:
					percentage += 25;
					break;
				case Category.Sort1:
					percentage += 10;
					break;
				case Category.Sort2:
					percentage += 5;
					break;
            }
			Price = (int)(Price * (percentage / 100d));
		}

		public override string ToString()
        {
            return base.ToString() + String.Format("\ncategory {0}\ntype: {1}", MeatCategory, MeatType);
        }
    }
}
