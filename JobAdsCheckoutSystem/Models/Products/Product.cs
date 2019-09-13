using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace JobAdsCheckoutSystem.Products
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
		public string SpecialPricingRuleID { get; set; }
		public double privilegedPrice { get; set; }


		public Product()
		{}

		//Somthing is wrong here
		public Product(Product product)
		{
			Id = product.Id;
			Code = product.Code;
			Name = product.Name;
			Price = product.Price;
			Description = product.Description;
			IsActive = product.IsActive;
			SpecialPricingRuleID = product.SpecialPricingRuleID;
			privilegedPrice = product.privilegedPrice;
		}
	}		
}