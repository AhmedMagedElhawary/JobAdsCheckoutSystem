using System.Collections.Generic;

namespace JobAdsCheckoutSystem
{
	public interface IPricingRulesRepository
	{
		List<ISpecialPricingRule> GetSpecialPricingRules();
	}
}