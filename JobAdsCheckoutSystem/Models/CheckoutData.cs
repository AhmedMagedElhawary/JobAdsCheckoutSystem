using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdsCheckoutSystem.Models
{
	public class CheckoutData
	{
		public Guid cutomerId { get; set; }
		public List<Guid> productsId { get; set; }

		public CheckoutData()
		{ }
		public CheckoutData(Guid customerId, List<Guid> productsId)
		{
			this.cutomerId = customerId;
			this.productsId = productsId;
		}
	}
}
