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
		IProductService productService;

		public JobAdsCheckoutService()
		{
			pricingRulesService = new PricingRulesService();
			productService = new ProductService();
		}

		public JobAdsCheckoutService(IpricingRulesService pricingRulesService, IProductService productService)
		{
			this.pricingRulesService = pricingRulesService;
			this.productService = productService;
		}

		public double Checkout(CheckoutData data)
		{
			return Checkout(data.cutomerId, data.productsId);
		}
			public double Checkout(Guid CustomerId, List<Guid> ProductsId)
		{
			List<Product> Products = new List<Product>();
			ProductsId.ForEach(x => Products.Add(productService.GetProduct(x)));
			Products = GetValidActiveProducts(Products);

			var SpecialPricingRules = pricingRulesService.GetActiveSpecialPricingRules(CustomerId);

			//Why not get a better overview ?
			//select Customers.Name, Products.Name, sprs.IsActive, SPRs.Buy, sprs.Charge, sprs.NewPrice, sprs.MinimumQuantity
			//from sprs
			//inner join Customers on Customers.id = CustomerId
			//inner join Products on Products.Id = ProductId

			//where customers.name = 'Ford'
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