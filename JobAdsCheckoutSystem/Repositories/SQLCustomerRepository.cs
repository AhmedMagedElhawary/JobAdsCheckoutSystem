using JobAdsCheckoutSystem.Data;
using JobAdsCheckoutSystem.Models;
using System;
using System.Collections.Generic;
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
			throw new NotImplementedException();
		}
	}
}