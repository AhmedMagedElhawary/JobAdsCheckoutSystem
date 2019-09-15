using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace JobAdsCheckoutSystem.Models
{
	public class Customer
	{
		[Key]
		public Guid Id { get; set; }

		public string Name { get; set; }
		public bool IsActive { get; set; }
	}
}