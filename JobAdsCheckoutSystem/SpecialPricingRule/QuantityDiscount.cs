using JobAdsCheckoutSystem.Products;
using System.Collections.Generic;
using System.Linq;

namespace JobAdsCheckoutSystem
{
	public class QuantityDiscount : SpecialPricingRule, ISpecialPricingRule
	{
		public double NewPrice { get; set; }
		public int MinimumQuantity { get; set; }

		public override void Apply(List<Product> products)
		{
			List<Product> matchedProducts = GetMatchedProducts(products);
			if(matchedProducts.Count() >= MinimumQuantity)
			{
				matchedProducts.ToList().ForEach(X => X.SpecialPricingRuleID = ID);
				matchedProducts.ToList().ForEach(X => X.privilegedPrice = NewPrice);
			}

		}
	}
}
