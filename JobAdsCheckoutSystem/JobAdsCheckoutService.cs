using System;
using System.Collections.Generic;
using System.Linq;
using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Services;

namespace JobAdsCheckoutSystem
{
	public class JobAdsCheckoutService
	{
		public static double Checkout(string CustomerId, List<Product> Products)
		{
			Products = GetValidActiveProducts(Products);
			
			var SpecialPricingRules = new PricingRulesService().GetActiveSpecialPricingRules(CustomerId);
			SpecialPricingRules.ForEach(X => X.Apply(Products));
			return CalculateTotal(Products);
		}

		private static List<Product> GetValidActiveProducts(List<Product> products)
		{
			return products.Where(X => X != null && X.IsActive ).ToList();
		}

		public static double Checkout(string CustomerId, List<Product> Products, IpricingRulesService pricingRulesService)
		{
			var SpecialPricingRules = pricingRulesService.GetActiveSpecialPricingRules(CustomerId);
			SpecialPricingRules.ForEach(X => X.Apply(Products));
			return CalculateTotal(Products);
		}

		public static double CalculateTotal(List<Product> Products)
		{
			return Products.Sum(X => (string.IsNullOrEmpty(X.SpecialPricingRuleID) ? X.Price : X.privilegedPrice));
		}
	}
}
