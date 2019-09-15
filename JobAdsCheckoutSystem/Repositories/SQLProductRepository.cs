using JobAdsCheckoutSystem.Data;
using JobAdsCheckoutSystem.Models;
using System;
using System.Linq;

namespace JobAdsCheckoutSystem.Repositories
{
	internal class SQLProductRepository : IProductRepository
	{

		#nullable enable
		public Product? GetProduct(string code)
		{
			throw new NotImplementedException();
		}

		public Product? GetProduct(Guid Id)
		{
			throw new NotImplementedException();
		}
	}
}