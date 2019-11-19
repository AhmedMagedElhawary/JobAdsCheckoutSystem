using JobAdsCheckoutSystem.Models;
using System;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem.Services
{
	public interface IpricingRulesService
	{
		public List<SPR> GetSpecialPricingRules();

		public List<SPR> GetActiveSpecialPricingRules();

		public List<SPR> GetActiveSpecialPricingRules(Guid customerId);
	}
}