using System;
using System.Collections.Generic;
using System.Linq;
using JobAdsCheckoutSystem.Products;

namespace JobAdsCheckoutSystem
{
	public class JobAdsCheckoutService
	{
		public static double Checkout(string CustomerID, List<Product> Products)
		{
			var SpecialPricingRules = new PricingRulesService().GetActiveSpecialPricingRules(CustomerID);
			SpecialPricingRules.ForEach(X => X.Apply(Products));
			return CalculateTotal(Products);
		}

		public static double Checkout(string CustomerID, List<Product> Products, IpricingRulesService pricingRulesService)
		{
			var SpecialPricingRules = pricingRulesService.GetActiveSpecialPricingRules(CustomerID);
			SpecialPricingRules.ForEach(X => X.Apply(Products));
			return CalculateTotal(Products);
		}

		public static double CalculateTotal(List<Product> Products)
		{
			return Products.Sum(X => (string.IsNullOrEmpty(X.SpecialPricingRuleID) ? X.Price : X.privilegedPrice));
		}
	}
}
