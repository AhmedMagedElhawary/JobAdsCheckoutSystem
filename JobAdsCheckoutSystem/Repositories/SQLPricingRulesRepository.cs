
using JobAdsCheckoutSystem.Data;
using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace JobAdsCheckoutSystem.Repositories
{
	public class SQLPricingRulesRepository : IPricingRulesRepository
	{
		public List<SPR> GetSpecialPricingRules()
		{
			var context = new AppDbContext();
			//var x = context.SPR
			//	.SqlQuery("SELECT * SPRs")
			//	.ToList<SPR>();


			var rules = new List<SPR>();
			rules.AddRange(
				context.SPRQuantityDiscount
				.SqlQuery("Select * from SPRs where MinimumQuantity<>0")
				.ToList());
			rules.AddRange(
				context.SPRBuyXGetYFree
				.SqlQuery("Select * from SPRs where MinimumQuantity=0")
				.ToList());


			return rules;
		}
	}
}