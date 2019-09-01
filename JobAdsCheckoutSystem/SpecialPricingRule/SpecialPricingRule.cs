using JobAdsCheckoutSystem.Products;
using System;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem
{
	public  class SpecialPricingRule : ISpecialPricingRule
	{
		public string ID { get; set; }
		public string CustomerID { get; set; }
		public string ProductID { get; set; }
		public bool IsActive { get; set; }

		public virtual void Apply(List<Product> products)
		{}

		public List<Product> GetMatchedProducts(List<Product> products)
		{
			return products.FindAll(X => string.Compare(X.ID, ProductID, StringComparison.OrdinalIgnoreCase) == 0
									   && string.IsNullOrEmpty(X.SpecialPricingRuleID));
		}
	}
}