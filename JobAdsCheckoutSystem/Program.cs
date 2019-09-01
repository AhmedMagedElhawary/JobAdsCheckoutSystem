using JobAdsCheckoutSystem.Products;
using System;
using System.Collections.Generic;

namespace JobAdsCheckoutSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Example scenarios \n");
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
			Console.WriteLine("{0} \n{1} \n{2}", "Customer: default ID",
								 "Added: 'classic', 'standout', 'premium'",
								 "Total expected: $987.97");

			price = JobAdsCheckoutService.Checkout("UnderprivilegedCustomerID",
												new List<Product>() {
													new Classic(),
													new Standout(),
													new Premium() }
												);
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
													new Classic(),
													new Classic(),
													new Classic(),
													new Premium() }
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
													new Standout(),
													new Standout(),
													new Standout(),
													new Premium()}
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
													new Premium(),
													new Premium(),
													new Premium(),
													new Premium()}
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
													new Classic(),
													new Classic(),
													new Standout(),
													new Classic(),
													new Classic(),
													new Premium(),
													new Classic(),
													new Classic(),
													new Standout(),
													new Classic(),
													new Classic(),
													new Standout(),
													new Classic(),
													new Premium(),
													new Classic(),
													new Classic(),
													new Classic(),
}
							);
			Console.WriteLine("Total calcualted: ${0}\n", price);
		}
	}
}
