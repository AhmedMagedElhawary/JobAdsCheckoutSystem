using JobAdsCheckoutSystem.Models;

namespace JobAdsCheckoutSystem.Repositories
{
	public interface IProductRepository
	{
		#nullable enable
		Product? GetProduct(string code);
	}
}