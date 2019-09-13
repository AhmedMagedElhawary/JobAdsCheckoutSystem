using System.Collections.Generic;
using JobAdsCheckoutSystem.Products;

namespace JobAdsCheckoutSystem
{
	public interface ISpecialPricingRule
	{
		void Apply(List<Product> products);
	}
}