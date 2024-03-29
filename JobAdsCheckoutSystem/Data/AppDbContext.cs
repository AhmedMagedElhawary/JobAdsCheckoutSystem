﻿using JobAdsCheckoutSystem.Models;
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
		public DbSet<Customer> Customers { get; set; }
		public DbSet<SPR> SPR { get; set; }
		public DbSet<SPRBuyXGetYFree> SPRBuyXGetYFree { get; set; }
		public DbSet<SPRQuantityDiscount> SPRQuantityDiscount { get; set; }
	}
}