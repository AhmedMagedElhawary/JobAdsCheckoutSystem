using JobAdsCheckoutSystem.Data;
using JobAdsCheckoutSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace JobAdsCheckoutSystem.Repositories
{
	internal class SQLProductRepository : IProductRepository
	{

		#nullable enable
		public Product? GetProduct(Guid Id)
		{
			var ctx = new AppDbContext();
			var product = ctx.Products
				.SqlQuery("Select * from Products where Id=@Id", new SqlParameter("@Id", Id))
				.FirstOrDefault();

			return product;
		}

		public List<Product> GetAllProducts()
		{
			throw new NotImplementedException();
		}
	}
}