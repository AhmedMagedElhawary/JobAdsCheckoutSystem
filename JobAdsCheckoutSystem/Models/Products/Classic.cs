using JobAdsCheckoutSystem.Repositories;
using JobAdsCheckoutSystem.Services;

namespace JobAdsCheckoutSystem.Products
{
	public	class Classic : Product
	{
		public Classic() : base(new ProductService(new JsonProductRepository()).GetProduct("Classic"))
		{}

	}
}