using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace JobAdsCheckoutSystem.Models
{
	public class Product
	{
		[Key]
		public Guid Id { get; set; }

		public string Code { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public Guid? SpecialPricingRuleID { get; set; }
		public double privilegedPrice { get; set; }
	}		
}