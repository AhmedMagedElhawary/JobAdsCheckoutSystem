using JobAdsCheckoutSystem.Services;

namespace JobAdsCheckoutSystem.Products
{
	public class Standout : Product
	{
		public Standout() : base(new ProductService().GetProduct("Standout"))
		{ }
	}
}