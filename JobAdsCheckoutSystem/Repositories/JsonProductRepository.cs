using JobAdsCheckoutSystem.Data;
using JobAdsCheckoutSystem.Models;
using System;
using System.Linq;

namespace JobAdsCheckoutSystem.Repositories
{
	internal class JsonProductRepository : IProductRepository
	{

		#nullable enable
		public Product? GetProduct(string code)
		{
			var deserializedRules =
				AppJsonContext.JsonResourceDeserializer(Properties.Resources.Products);

			var deserializedProduct = deserializedRules.ToList().
				FirstOrDefault(X => string.Compare(X.Code, code, StringComparison.OrdinalIgnoreCase) == 0);

			if (deserializedProduct == null)
			{
				return null;
			}

			return new Product()
			{
				Code = deserializedProduct.Code,
				Name = deserializedProduct.Name,
				Price = (double)deserializedProduct.Price,
				Description = deserializedProduct.Description,
				IsActive = (bool)deserializedProduct.IsActive
			};
		}
	}
}