using JobAdsCheckoutSystem.Models;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem.Services
{
	public interface IpricingRulesService
	{
		List<SPR> GetSpecialPricingRules();
		List<SPR> GetActiveSpecialPricingRules();
		List<SPR> GetActiveSpecialPricingRules(string customerId);
	}
}