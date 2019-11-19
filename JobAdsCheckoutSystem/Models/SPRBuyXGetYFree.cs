using JobAdsCheckoutSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace JobAdsCheckoutSystem.Models
{
	public class SPRBuyXGetYFree : SPR
	{
		//public int Buy { get; set; }
		//public int Charge { get; set; }

		public override void Apply(List<Product> products)
		{
			var FreeCount = Buy - Charge;

			List<Product> matchedProducts = GetMatchedProducts(products);
			while (matchedProducts.Count() >= Buy && Buy > 0)
			{
				matchedProducts.Take(Buy).ToList().ForEach(X => X.SpecialPricingRuleID = Id);
				matchedProducts.Take(Buy).ToList().ForEach(X => X.privilegedPrice = X.Price);
				matchedProducts.Take(FreeCount).ToList().ForEach(X => X.privilegedPrice = 0.0);

				matchedProducts = GetMatchedProducts(products);
			}
		}
	}
}
