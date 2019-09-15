using JobAdsCheckoutSystem.Models;
using System;

namespace JobAdsCheckoutSystem.Repositories
{
	public interface IProductRepository
	{
		#nullable enable
		Product? GetProduct(string code);

		Product? GetProduct(Guid Id);
	}
}