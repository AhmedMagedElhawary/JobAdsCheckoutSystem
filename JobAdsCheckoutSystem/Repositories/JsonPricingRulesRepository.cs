
using JobAdsCheckoutSystem.Data;
using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace JobAdsCheckoutSystem.Repositories
{
	public class JsonPricingRulesRepository : IPricingRulesRepository
	{
		public List<SPR> GetSpecialPricingRules()
		{
			var deserializedRules =
				AppJsonContext.JsonResourceDeserializer(Properties.Resources.SpecialPricingRules);

			var specialPricingRules = new List<SPR>();
			deserializedRules.ToList().ForEach(X => specialPricingRules.Add(MapRule(X)));

			return specialPricingRules;
		}

		#region Helper functions  
		private static SPR MapRule(dynamic deserializedRule)
		{
			switch (deserializedRule.Rule.Type)
			{
				case "BuyXGetYFree":
					return new SPRBuyXGetYFree()
					{
						Id = deserializedRule.Id,
						CustomerId = deserializedRule.CustomerId,
						ProductId = deserializedRule.Rule.ProductId,
						Buy = (int)deserializedRule.Rule.Parameters.Buy,
						Charge = (int)deserializedRule.Rule.Parameters.Charge,
						IsActive = (bool)deserializedRule.IsActive
					};

				case "QuantityDiscount":
					return new SPRQuantityDiscount()
					{
						Id = deserializedRule.Id,
						CustomerId = deserializedRule.CustomerId,
						ProductId = deserializedRule.Rule.ProductId,
						NewPrice = (double)deserializedRule.Rule.Parameters.NewPrice,
						MinimumQuantity = (int)deserializedRule.Rule.Parameters.MinimumQuantity,
						IsActive = (bool)deserializedRule.IsActive
					};

				default:
					return null;
					//return new SpecialPricingRule()
					//{
					//	Id = deserializedRule.Id,
					//	IsActive = false
					//};
			}
		}
		#endregion
	}
}