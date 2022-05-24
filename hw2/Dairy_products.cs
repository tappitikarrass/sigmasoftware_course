namespace hw2
{
	public class Dairy_products : Product
	{
		public int timeToExpire { get; private set; }
		public Dairy_products(string name, int price, int weight, int days) : base(name, price, weight)
		{
			timeToExpire = days;
		}

		public new void ChangePrice(int percentage)
		{
			Price = timeToExpire < 14 && percentage > 50 ? percentage -= 30 : percentage;
			Price = (int)(Price * (percentage / 100d));
		}

		public override string ToString()
		{
			return base.ToString() + String.Format("\nexpires in {0} days", timeToExpire);
		}
	}
}
