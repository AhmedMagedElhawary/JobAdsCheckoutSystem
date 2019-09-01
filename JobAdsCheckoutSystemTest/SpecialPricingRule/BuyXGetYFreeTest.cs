using JobAdsCheckoutSystem;
using JobAdsCheckoutSystem.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace JobAdsCheckoutSystemTest
{
	[TestClass]
	public class BuyXGetYFreeTest
	{
		[TestMethod]
		public void ApplyBuyXGetYFree_NoProducts_DoNothing()
		{
			// Arrange
			var buyXGetYFree = new BuyXGetYFree()
			{
				ID = "XYD",
				IsActive = true,
				ProductID = "P1",
				Buy = 3,
				Charge =1
			};

			var products = new List<Product>();

			// Act
			buyXGetYFree.Apply(products);

			// Assert
			Assert.AreEqual(0, products.Count());
		}

		[TestMethod]
		public void ApplyBuyXGetYFree_NoMatchProductsID_DoNothing()
		{
			// Arrange
			var price = 100;
			var privilegedPrice = price / 2;
			var buyXGetYFree = new BuyXGetYFree()
			{
				ID = "XYD",
				IsActive = true,
				ProductID = "P1",
				Buy = 3,
				Charge = 1
			};

			var products = new List<Product>() {
								new Product(){ ID="NotP1", Price=price },
								new Product(){ ID="NotP1", Price=price }
									};
			var totalBefore = JobAdsCheckoutService.CalculateTotal(products);

			// Act
			buyXGetYFree.Apply(products);

			// Assert
			Assert.AreEqual(totalBefore, JobAdsCheckoutService.CalculateTotal(products));
			Assert.AreEqual(0, products.Count(X => X.SpecialPricingRuleID != null));
			Assert.AreEqual(0, products.Count(X => X.privilegedPrice != 0));
		}

		[TestMethod]
		public void ApplyBuyXGetYFree_NoMatchProductsBuyQuantity_DoNothing()
		{
			// Arrange
			var price = 100;
			var privilegedPrice = price / 2;
			var buyXGetYFree = new BuyXGetYFree()
			{
				ID = "XYD",
				IsActive = true,
				ProductID = "P1",
				Buy = 3,
				Charge = 1
			};

			var products = new List<Product>() {
								new Product(){ ID="P1", Price=price },
								new Product(){ ID="P1", Price=price }
									};
			var totalBefore = JobAdsCheckoutService.CalculateTotal(products);

			// Act
			buyXGetYFree.Apply(products);

			// Assert
			Assert.AreEqual(totalBefore, JobAdsCheckoutService.CalculateTotal(products));
			Assert.AreEqual(0, products.Count(X => X.SpecialPricingRuleID != null));
			Assert.AreEqual(0, products.Count(X => X.privilegedPrice != 0));
		}

		[TestMethod]
		public void ApplyBuyXGetYFree_Matched_ApplyDiscountOverAllMatchedProducts()
		{
			// Arrange
			var price = 100;
			var buyXGetYFree = new BuyXGetYFree()
			{
				ID = "XYD",
				IsActive = true,
				ProductID = "P1",
				Buy = 3,
				Charge = 1
			};

			
			var products = new List<Product>() {
							new Product(){ ID="P1", Price=price },
							new Product(){ ID="P2", Price=0 },
							new Product(){ ID="P1", Price=price },
							new Product(){ ID="P3", Price=0 },
							new Product(){ ID="P1", Price=price },
							new Product(){ ID="P1", Price=price },
							new Product(){ ID="P3", Price=0 },
							new Product(){ ID="P1", Price=price },
							new Product(){ ID="P3", Price=0 },
							new Product(){ ID="P4", Price=0 },
							new Product(){ ID="P1", Price=price },
							new Product(){ ID="P1", Price=price },
								};

			// 7P1 = 7 * 100 = 700
			var totalBefore = JobAdsCheckoutService.CalculateTotal(products);
			var matchedProductsCount = products.Count(X => string.Compare(X.ID, buyXGetYFree.ProductID, StringComparison.OrdinalIgnoreCase) == 0);

			// Act
			buyXGetYFree.Apply(products);
			// 7P1 = 3P1(100) + 3P1(100) + 100 = 300

			// Assert
			Assert.AreEqual(totalBefore, JobAdsCheckoutService.CalculateTotal(products) * matchedProductsCount / buyXGetYFree.Buy);
			Assert.AreEqual(matchedProductsCount - (matchedProductsCount % buyXGetYFree.Buy), products.Count(X => X.SpecialPricingRuleID != null));
			Assert.AreEqual((matchedProductsCount - (matchedProductsCount % buyXGetYFree.Buy)) / buyXGetYFree.Buy, products.Count(X => X.privilegedPrice != 0));
		}
	}
}
