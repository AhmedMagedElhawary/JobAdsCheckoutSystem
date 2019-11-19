using JobAdsCheckoutSystem.Models;
using System;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem.Repositories
{
	public interface IProductRepository
	{
		#nullable enable
		//Product? GetProduct(string code);

		Product? GetProduct(Guid Id);
		List<Product> GetAllProducts();
	}
}