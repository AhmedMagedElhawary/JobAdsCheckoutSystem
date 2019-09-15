using JobAdsCheckoutSystem.Data;
using JobAdsCheckoutSystem.Models;
using System;
using System.Linq;

namespace JobAdsCheckoutSystem.Repositories
{
	internal class JsonCustomerRepository : ICustomerRepository
	{

		#nullable enable
		public Customer? GetCustomer(string name)
		{
			var deserializedRules =
				AppJsonContext.JsonResourceDeserializer(Properties.Resources.Customer);

			var deserializedCustomer= deserializedRules.ToList().
				FirstOrDefault(X => string.Compare(X.Name, name, StringComparison.OrdinalIgnoreCase) == 0);

			if (deserializedCustomer == null)
			{
				return null;
			}

			return new Customer()
			{
				Id = new Guid(deserializedCustomer.Id),
				Name = deserializedCustomer.Name,
				IsActive = (bool)deserializedCustomer.IsActive
			};
		}
	}
}