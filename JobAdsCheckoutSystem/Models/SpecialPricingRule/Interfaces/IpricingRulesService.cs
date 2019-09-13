using System.Collections.Generic;

namespace JobAdsCheckoutSystem
{
	public interface IpricingRulesService
	{
		List<ISpecialPricingRule> GetSpecialPricingRules();
		List<ISpecialPricingRule> GetActiveSpecialPricingRules();
		List<ISpecialPricingRule> GetActiveSpecialPricingRules(string customerId);
	}
}