using JobAdsCheckoutSystem.Models;

namespace JobAdsCheckoutSystem.Services
{
	public interface ICustomerService
	{
		#nullable enable
		public Customer? GeCustomer(string name);
	}
}