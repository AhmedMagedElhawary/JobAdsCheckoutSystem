using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using JobAdsCheckoutSystem.Services;
using System;
using System.Collections.Generic;
using System.Web.Http.SelfHost;

namespace JobAdsCheckoutSystem
{
	class Program
	{
		public static bool JsonDBMod { get; private set; }

		static void Main(string[] args)
		{
			ConsoleMod();
			//APIMod();
		}

		#region Console Mod
		static void ConsoleMod()
		{
			JsonDBMod = true;
			Console.WriteLine("Console Demo with Json data layer\n");
			CalculateScenarios1();
			CalculateScenarios2();
			CalculateScenarios3();
			CalculateScenarios4();

			Console.WriteLine("Extreme scenario \n");
			CalculateScenarios5();

			Console.ReadKey();
		}

		private static void CalculateScenarios1()
		{
			double price;
			Console.WriteLine("{0} \n{1} \n{2}", "Customer: default Id",
								 "Added: 'classic', 'standout', 'premium'",
								 "Total expected: $987.97");

			price = JobAdsCheckoutService.Checkout("UnderprivilegedCustomerId",
												new List<Product>() {
													GetProduct("Classic"),
													GetProduct("Standout"),
													GetProduct("Premium")
																	});
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}

		private static void CalculateScenarios2()
		{
			double price;
			Console.WriteLine("{0} \n{1} \n{2}", "Customer: Unilever",
								 "SKUs Scanned: 'classic', 'classic', 'classic', 'premium'",
								 "Total expected: $934.97");
			price = JobAdsCheckoutService.Checkout("Unilever",
									new List<Product>() {
															GetProduct("Classic"),
															GetProduct("Classic"),
															GetProduct("Classic"),
															GetProduct("Premium") }
									);
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}

		private static void CalculateScenarios3()
		{
			double price;
			Console.WriteLine("{0} \n{1} \n{2}", "Customer: Apple",
					 "SKUs Scanned: 'standout', 'standout', 'standout', 'premium'",
					 "Total expected: $1294.96");
			price = JobAdsCheckoutService.Checkout("Apple",
				new List<Product>() {
															GetProduct("Standout"),
															GetProduct("Standout"),
															GetProduct("Standout"),
															GetProduct("Premium")}
										);
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}

		private static void CalculateScenarios4()
		{
			double price;
			Console.WriteLine("{0} \n{1} \n{2}", "Customer: Nike",
					 "SKUs Scanned: 'premium', 'premium','premium','premium'",
					 "Total expected: $1519.96");
			price = JobAdsCheckoutService.Checkout("Nike",
				new List<Product>() {
															GetProduct("Premium"),
															GetProduct("Premium"),
															GetProduct("Premium"),
															GetProduct("Premium")}
							);
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
			price = JobAdsCheckoutService.Checkout("Ford",
				new List<Product>() {
															GetProduct("Classic"),
															GetProduct("Classic"),
															GetProduct("Standout"),
															GetProduct("Classic"),
															GetProduct("Classic"),
															GetProduct("Premium"),
															GetProduct("Classic"),
															GetProduct("Classic"),
															GetProduct("Standout"),
															GetProduct("Classic"),
															GetProduct("Classic"),
															GetProduct("Standout"),
															GetProduct("Classic"),
															GetProduct("Premium"),
															GetProduct("Classic"),
															GetProduct("Classic"),
															GetProduct("Classic"),
}
							);
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}
		#endregion

		#region API Mod
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

		private static Product GetProduct(string productCode)
		{
			if (JsonDBMod)
			{
				return new ProductService(new JsonProductRepository()).GetProduct(productCode);
			}

			return new ProductService(new SQLProductRepository()).GetProduct(productCode);
		}
	}
}
