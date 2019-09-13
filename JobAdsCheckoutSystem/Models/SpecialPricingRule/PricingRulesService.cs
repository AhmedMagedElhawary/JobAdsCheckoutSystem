using System;
using System.Collections.Generic;
using System.Linq;

namespace JobAdsCheckoutSystem
{
	public class PricingRulesService : IpricingRulesService
	{
		IPricingRulesRepository pricingRulesRepository;

		public PricingRulesService()
		{
			pricingRulesRepository = new PricingRulesRepository();
		}

		public PricingRulesService(IPricingRulesRepository PricingRulesRepository)
		{
			pricingRulesRepository = PricingRulesRepository;
		}

		public List<ISpecialPricingRule> GetSpecialPricingRules()
		{
			return pricingRulesRepository.GetSpecialPricingRules();
		}

		public  List<ISpecialPricingRule> GetActiveSpecialPricingRules()
		{
			return GetSpecialPricingRules()
				.Where(X => ((SpecialPricingRule)X).IsActive).ToList();
		}

		public  List<ISpecialPricingRule> GetActiveSpecialPricingRules(string customerId)
		{
			return GetActiveSpecialPricingRules()
				.Where(X => string.Compare(((SpecialPricingRule)X).CustomerId, customerId, StringComparison.OrdinalIgnoreCase) == 0).ToList();
		}
	}
}
