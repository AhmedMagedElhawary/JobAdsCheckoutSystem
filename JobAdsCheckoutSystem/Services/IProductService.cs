using JobAdsCheckoutSystem.Models;

namespace JobAdsCheckoutSystem.Services
{
	public interface IProductService
	{
		#nullable enable
		public Product? GetProduct(string code);
	}
}