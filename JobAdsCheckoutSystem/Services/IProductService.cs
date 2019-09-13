using JobAdsCheckoutSystem.Products;

namespace JobAdsCheckoutSystem.Services
{
	public interface IProductService
	{
		#nullable enable
		public Product? GetProduct(string code);
	}
}