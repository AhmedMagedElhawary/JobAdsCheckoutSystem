using JobAdsCheckoutSystem.Products;
using System;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem
{
	public  class SpecialPricingRule : ISpecialPricingRule
	{
		public string Id { get; set; }
		public string CustomerId { get; set; }
		public string ProductId { get; set; }
		public bool IsActive { get; set; }

		public virtual void Apply(List<Product> products)
		{}

		public List<Product> GetMatchedProducts(List<Product> products)
		{
			return products.FindAll(X => string.Compare(X.Code, ProductId, StringComparison.OrdinalIgnoreCase) == 0
									   && string.IsNullOrEmpty(X.SpecialPricingRuleID));
		}
	}
}