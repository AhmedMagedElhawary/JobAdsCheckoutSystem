namespace JobAdsCheckoutSystem.Migrations
{
    using JobAdsCheckoutSystem.Services;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JobAdsCheckoutSystem.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JobAdsCheckoutSystem.Data.AppDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.
			context.Products.AddOrUpdate(new ProductService().GetProducts().ToArray());
			context.Customers.AddOrUpdate(new CustomerService().GeCustomers().ToArray());
			context.SPR.AddOrUpdate(new PricingRulesService().GetSpecialPricingRules().ToArray());
		}
	}
}
