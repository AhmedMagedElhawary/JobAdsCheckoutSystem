using System.Collections.Generic;
using JobAdsCheckoutSystem.Models;

namespace JobAdsCheckoutSystem.Repositories
{
	public interface ICustomerRepository
	{
		#nullable enable
		public Customer? GetCustomer(string name);
		List<Customer> GeCustomers();
	}
}