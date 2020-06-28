using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using JobAdsCheckoutSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.SelfHost;

namespace JobAdsCheckoutSystem
{
	class Program
	{
		public static bool JsonDBMod { get; private set; }
		//Products
		 static readonly Guid Classic = new Guid("018a5e88-0f30-4409-b78c-2d8a824d70b7");
		static readonly Guid Standout = new Guid("9c3c4f04-ddc2-4647-9aa3-a86cba651666");
		static readonly Guid Premium = new Guid("c5b2084c-9bd7-400f-bf9a-9be14453c7c0");
		
			
		static void Main(string[] args)
		{
			ConsoleMod();
			//APIMod();
		}

		#region Console Mod
		static void ConsoleMod()
		{
			JsonDBMod = true;
			//JsonDBMod = false;
			Console.WriteLine("Console Demo with Json data layer\n");
			CalculateScenarios1();
			CalculateScenarios2();
			CalculateScenarios3();
			CalculateScenarios4();

			Console.WriteLine("Extreme scenario \n");
			CalculateScenarios5();

			Console.ReadLine();
		}

		private static void CalculateScenarios1()
		{
			double price;
			Console.WriteLine("{0} \n{1} \n{2}", "Customer: default Id",
								 "Added: 'classic', 'standout', 'premium'",
								 "Total expected: $987.97");
			price = Checkout("Anonymous",new List<Guid>(){Classic,Standout,Premium});
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}

		private static void CalculateScenarios2()
		{
			double price;
			Console.WriteLine("{0} \n{1} \n{2}", "Customer: Unilever",
								 "SKUs Scanned: 'classic', 'classic', 'classic', 'premium'",
								 "Total expected: $934.97");

			price = Checkout("Unilever", new List<Guid>() { Classic, Classic, Classic, Premium});
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}

		private static void CalculateScenarios3()
		{
			double price;
			Console.WriteLine("{0} \n{1} \n{2}", "Customer: Apple",
					 "SKUs Scanned: 'standout', 'standout', 'standout', 'premium'",
					 "Total expected: $1294.96");

			price = Checkout("Apple", new List<Guid>() { Standout, Standout, Standout, Premium});
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}

		private static void CalculateScenarios4()
		{
			double price;
			Console.WriteLine("{0} \n{1} \n{2}", "Customer: Nike",
					 "SKUs Scanned: 'premium', 'premium','premium','premium'",
					 "Total expected: $1519.96");

			price = Checkout("Nike", new List<Guid>() { Premium, Premium, Premium, Premium });
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}

		private static void CalculateScenarios5()
		{
			double price;
			Console.WriteLine("{0} \n{1} \n{2}, {3}", "Customer: Ford",
					 "SKUs Scanned: 12 'classic', 3 'standout', 2 'premium'",
					 "Total expected:", @"
									(1079.96) 5 classic for price of 4 +
									(1079.96) 5 classic for price of 4 + 
									(539.98)  2 classic normal price + 
									(929.97)  3 standout with discounted price +
									(789.98)  2 permium normal price 
									= $4419.85");

			price = Checkout("Ford", new List<Guid>() {	Classic, Classic, Standout, Classic,
															Classic, Premium, Classic, Classic,
															Standout, Classic, Classic, Classic,
															Standout, Premium, Classic, Classic, Classic});
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}
		#endregion

		#region API Mod
		//http://localhost:8080/api/checkout?CutomerId=1&Products=2,10
		static void APIMod()
		{
			var config = new HttpSelfHostConfiguration("http://localhost:8080");
			WebApiConfig.Register(config);

			using (HttpSelfHostServer server = new HttpSelfHostServer(config))
			{
				server.OpenAsync().Wait();
				Console.WriteLine("Press Enter to quit.");
				Console.ReadLine();
			}
		}
		#endregion

		private static double Checkout(string customerName, List<Guid> productsId)
		{
			if (JsonDBMod)
			{
				var customerId = new CustomerService(new JsonCustomerRepository()).GeCustomer(customerName).Id;
				var checkOutData = new CheckoutData(customerId, productsId);
				return new JobAdsCheckoutService(	new PricingRulesService(new JsonPricingRulesRepository()),
													new ProductService(new JsonProductRepository()))
																					.Checkout(checkOutData);
			}
			else
			{
				var customerId = new CustomerService(new SQLCustomerRepository()).GeCustomer(customerName).Id;
				var checkOutData = new CheckoutData(customerId, productsId);
				return new JobAdsCheckoutService(	new PricingRulesService(new SQLPricingRulesRepository()),
													new ProductService(new SQLProductRepository()))
																						.Checkout(checkOutData);
			}
		}
	}
}
