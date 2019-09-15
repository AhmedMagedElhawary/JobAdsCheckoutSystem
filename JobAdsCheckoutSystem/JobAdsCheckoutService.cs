using System;
using System.Collections.Generic;
using System.Linq;
using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using JobAdsCheckoutSystem.Services;

namespace JobAdsCheckoutSystem
{
	public class JobAdsCheckoutService
	{
		IpricingRulesService pricingRulesService;

		public JobAdsCheckoutService()
		{
			pricingRulesService = new PricingRulesService();
		}

		public JobAdsCheckoutService(IpricingRulesService pricingRulesService)
		{
			this.pricingRulesService = pricingRulesService;
		}

		public double Checkout(Guid CustomerId, List<Product> Products)
		{
			Products = GetValidActiveProducts(Products);

			var SpecialPricingRules = pricingRulesService.GetActiveSpecialPricingRules(CustomerId);
			SpecialPricingRules.ForEach(X => X.Apply(Products));
			return CalculateTotal(Products);
		}

		private List<Product> GetValidActiveProducts(List<Product> products)
		{
			return products.Where(X => X != null && X.IsActive).ToList();
		}

		//public double Checkout(Guid CustomerId, List<Product> Products, PricingRulesService pricingRulesService)
		//		{
		//			var SpecialPricingRules = pricingRulesService.GetActiveSpecialPricingRules(CustomerId);
		//			SpecialPricingRules.ForEach(X => X.Apply(Products));
		//			return CalculateTotal(Products);
		//		}

		public static double CalculateTotal(List<Product> Products)
		{
			return Products.Sum(X => (X.SpecialPricingRuleID == null ? X.Price : X.privilegedPrice));
		}
	}
}