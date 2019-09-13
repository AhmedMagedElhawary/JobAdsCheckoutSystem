using JobAdsCheckoutSystem.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobAdsCheckoutSystem.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base("name=JobAdsCheckoutSystemDB")
		{

		}
		public DbSet<Product> Products { get; set; }
	}
}