using JobAdsCheckoutSystem.Models;
using System;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem.Services
{
	public interface IProductService
	{
		#nullable enable
		//public Product? GetProduct(string code);

		public Product? GetProduct(Guid productId);
		public List<Product> GetProducts();
	}
}