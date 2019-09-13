using JobAdsCheckoutSystem.Services;

namespace JobAdsCheckoutSystem.Products
{
	public class Premium : Product
	{
		public Premium() : base(new ProductService().GetProduct("Premium"))
		{ }
	}
}