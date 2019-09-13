using JobAdsCheckoutSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobAdsCheckoutSystemWeb.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base("name=JobAdsCheckoutSystemDB")
		{

		}
		public DbSet<Product> Products { get; set; }
	}
}