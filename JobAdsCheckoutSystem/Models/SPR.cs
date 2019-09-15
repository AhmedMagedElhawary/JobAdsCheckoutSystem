using JobAdsCheckoutSystem.Models;
using System;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem.Models
{
	//SpecialPricingRule
	public abstract class SPR //: ISpecialPricingRule
	{
		public Guid Id { get; set; }
		public Guid CustomerId { get; set; }
		public Guid ProductId { get; set; }
		public bool IsActive { get; set; }

		//public virtual void Apply(List<Product> products)
		//{}

		public abstract void Apply(List<Product> products);

		public List<Product> GetMatchedProducts(List<Product> products)
		{
			return products.FindAll(X => X.Id== ProductId && X.SpecialPricingRuleID == null);
		}
	}
}