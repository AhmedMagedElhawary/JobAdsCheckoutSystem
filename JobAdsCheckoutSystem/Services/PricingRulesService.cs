using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobAdsCheckoutSystem.Services
{
	public class PricingRulesService : IpricingRulesService
	{
		IPricingRulesRepository pricingRulesRepository;

		public PricingRulesService()
		{
			pricingRulesRepository = new JsonPricingRulesRepository();
		}

		public PricingRulesService(IPricingRulesRepository PricingRulesRepository)
		{
			pricingRulesRepository = PricingRulesRepository;
		}

		public List<SPR> GetSpecialPricingRules()
		{
			return pricingRulesRepository.GetSpecialPricingRules()
				.Where(X => X != null).ToList(); ;
		}

		public List<SPR> GetActiveSpecialPricingRules()
		{
			return GetSpecialPricingRules()
				.Where(X => ((SPR)X).IsActive).ToList();
		}

		public List<SPR> GetActiveSpecialPricingRules(Guid customerId)
		{
			return GetActiveSpecialPricingRules()
				.Where(X => X.CustomerId == customerId).ToList();
		}
	}
}
