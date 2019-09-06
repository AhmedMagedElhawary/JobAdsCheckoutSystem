using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobAdsCheckoutSystemWeb.Models
{
	public class Product
	{ 
		[Key]
		public Guid Id { get; set; }

		public string Name { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
	}
}