using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdsCheckoutSystem.Services
{
	public class CustomerService : ICustomerService
	{
		private ICustomerRepository customerRepository;

		public CustomerService()
		{
			customerRepository = new JsonCustomerRepository();
		}
		public CustomerService(ICustomerRepository customerRepository)
		{
			this.customerRepository = customerRepository;
		}

#nullable enable
		public Customer? GeCustomer(string name)
		{
			return customerRepository.GetCustomer(name);
		}

	}
}