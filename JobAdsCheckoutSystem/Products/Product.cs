using JobAdsCheckoutSystem.Resources;
using System;
using System.Linq;

namespace JobAdsCheckoutSystem.Products
{
	public class Product
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public string SpecialPricingRuleID { get; set; }
		public double privilegedPrice { get; set; }

		public Product()
		{ }
		public Product(string ID)
		{
			var deserializedRules =
				JsonService.JsonResourceDeserializer(Properties.Resources.Products);

			var deserializedProduct = deserializedRules.ToList().
				FirstOrDefault(X => string.Compare(X.ID, ID, StringComparison.OrdinalIgnoreCase) == 0);

			if (deserializedProduct != null)
			{
				this.ID = deserializedProduct.ID;
				Name = deserializedProduct.Name;
				Price = (double)deserializedProduct.Price;
				Description = deserializedProduct.Description;
				IsActive = (bool)deserializedProduct.IsActive;
			}
			else
			{
				IsActive = false;
			}
		}
	}
}