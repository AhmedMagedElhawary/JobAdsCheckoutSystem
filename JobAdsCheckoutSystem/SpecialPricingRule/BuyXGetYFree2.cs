﻿using JobAdsCheckoutSystem.Products;
using System.Collections.Generic;
using System.Linq;

namespace JobAdsCheckoutSystem
{
	public class BuyXGetYFree2 : SpecialPricingRule, ISpecialPricingRule
	{
		public int Buy { get; set; }
		public int Charge { get; set; }

		public override void Apply(List<Product> products)
		{
			var matchedProducts = GetMatchedProducts(products);
			if (matchedProducts.Count() >= Buy)
			{
				var matchedBuyCount = matchedProducts.Count() - (matchedProducts.Count() % Buy);
				var freeProductsCount = (matchedProducts.Count() - (matchedProducts.Count() % Buy)) * (Buy - Charge) / Buy;

				matchedProducts.Take(matchedBuyCount - freeProductsCount).ToList().ForEach(X => X.SpecialPricingRuleID = ID);
				matchedProducts.Take(matchedBuyCount - freeProductsCount).ToList().ForEach(X => X.privilegedPrice = X.Price);

				matchedProducts = GetMatchedProducts(products);
				matchedProducts.Take(freeProductsCount).ToList().ForEach(X => X.SpecialPricingRuleID = ID);
				matchedProducts.Take(freeProductsCount).ToList().ForEach(X => X.privilegedPrice = 0.0);
			}
		}
	}
}
