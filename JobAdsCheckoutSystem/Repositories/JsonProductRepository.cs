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
				Id = new Guid(deserializedProduct.Id),
				Code = deserializedProduct.Code,
				Name = deserializedProduct.Name,
				Price = (double)deserializedProduct.Price,
				Description = deserializedProduct.Description,
				IsActive = (bool)deserializedProduct.IsActive
			};
		}

#nullable enable
		public Product? GetProduct(Guid Id)
		{
			var deserializedRules =
				AppJsonContext.JsonResourceDeserializer(Properties.Resources.Products);

			var deserializedProduct = deserializedRules.ToList().
				FirstOrDefault(X => new Guid(X.Id) == Id);

			if (deserializedProduct == null)
			{
				return null;
			}

			return new Product()
			{
				Id = new Guid(deserializedProduct.Id),
				Code = deserializedProduct.Code,
				Name = deserializedProduct.Name,
				Price = (double)deserializedProduct.Price,
				Description = deserializedProduct.Description,
				IsActive = (bool)deserializedProduct.IsActive
			};
		}
	}
}