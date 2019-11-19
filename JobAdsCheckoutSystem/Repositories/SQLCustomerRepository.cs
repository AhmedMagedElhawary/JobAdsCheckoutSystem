using JobAdsCheckoutSystem.Data;
using JobAdsCheckoutSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace JobAdsCheckoutSystem.Repositories
{
	internal class SQLCustomerRepository : ICustomerRepository
	{
		public List<Customer> GeCustomers()
		{
			throw new NotImplementedException();
		}

#nullable enable
		public Customer? GetCustomer(string name)
		{
			var ctx = new AppDbContext();
			var product = ctx.Customers
				.SqlQuery("Select * from Customers where name=@name", new SqlParameter("@name", name))
				.FirstOrDefault();

			return product;
		}
	}
}