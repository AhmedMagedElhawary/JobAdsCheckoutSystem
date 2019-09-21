using JobAdsCheckoutSystem.Models;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem.Services
{
	public interface ICustomerService
	{
		#nullable enable
		public Customer? GeCustomer(string name);

		List<Customer> GeCustomers();
	}
}