using JobAdsCheckoutSystem.Models;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem.Repositories
{
	public interface IPricingRulesRepository
	{
		List<SPR> GetSpecialPricingRules();
	}
}