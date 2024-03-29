﻿using JobAdsCheckoutSystem;
using JobAdsCheckoutSystem.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace JobAdsCheckoutSystemTest
{
	[TestClass]
	public class QuantityDiscountTest
	{
		[TestMethod]
		public void ApplyQuantityDiscount_NoProducts_DoNothing()
		{
			// Arrange
			var quantityDiscount = new SPRQuantityDiscount(){
												Id = Guid.NewGuid(),
												IsActive = true,
												ProductId = Guid.NewGuid(),
												NewPrice = 1,
												MinimumQuantity = 1 };

			var products = new List<Product>();

			// Act
			quantityDiscount.Apply(products);

			// Assert
			Assert.AreEqual(0, products.Count());
		}

		[TestMethod]
		public void ApplyQuantityDiscount_NoMatchProductsID_DoNothing()
		{
			// Arrange
			var price = 100;
			var privilegedPrice = price / 2;
			var quantityDiscount = new SPRQuantityDiscount()
			{
				Id = Guid.NewGuid(),
				IsActive = true,
				ProductId = Guid.NewGuid(),
				NewPrice = privilegedPrice,
				MinimumQuantity = 1
			};

			var products = new List<Product>() {
								new Product(){ Id=Guid.NewGuid(), Price=price },
								new Product(){ Id=Guid.NewGuid(), Price=price }
									};
			var totalBefore = JobAdsCheckoutService.CalculateTotal(products);

			// Act
			quantityDiscount.Apply(products);

			// Assert
			Assert.AreEqual(totalBefore, JobAdsCheckoutService.CalculateTotal(products));
			Assert.AreEqual(0, products.Count(X => X.SpecialPricingRuleID != null));
			Assert.AreEqual(0, products.Count(X => X.privilegedPrice != 0));
		}

		[TestMethod]
		public void ApplyQuantityDiscount_NoMatchProductsMinimumQuantity_DoNothing()
		{
			// Arrange
			var price = 100;
			var privilegedPrice = price / 2;
			var quantityDiscount = new SPRQuantityDiscount()
			{
				Id = Guid.NewGuid(),
				IsActive = true,
				ProductId = Guid.NewGuid(),
				NewPrice = privilegedPrice,
				MinimumQuantity = 3
			};

			var products = new List<Product>() {
								new Product(){ Id=quantityDiscount.ProductId, Price=price },
								new Product(){ Id=quantityDiscount.ProductId, Price=price }
									};
			var totalBefore = JobAdsCheckoutService.CalculateTotal(products);

			// Act
			quantityDiscount.Apply(products);

			// Assert
			Assert.AreEqual(totalBefore, JobAdsCheckoutService.CalculateTotal(products));
			Assert.AreEqual(0, products.Count(X => X.SpecialPricingRuleID != null));
			Assert.AreEqual(0, products.Count(X => X.privilegedPrice != 0));
		}

		[TestMethod]
		public void ApplyQuantityDiscount_Matched_ApplyDiscountOverAllMatchedProducts()
		{
			// Arrange
			var price = 100;
			var privilegedPrice = price / 2;

			var quantityDiscount = new SPRQuantityDiscount()
			{
				Id = Guid.NewGuid(),
				IsActive = true,
				ProductId = Guid.NewGuid(),
				NewPrice = privilegedPrice,
				MinimumQuantity = 3
			};
			var products = new List<Product>() {
							new Product(){ Id=quantityDiscount.ProductId, Price=price},
							new Product(){ Id=Guid.NewGuid(), Price=0 },
							new Product(){ Id=quantityDiscount.ProductId, Price=price },
							new Product(){ Id=Guid.NewGuid(), Price=0 },
							new Product(){ Id=quantityDiscount.ProductId, Price=price },
							new Product(){ Id=quantityDiscount.ProductId, Price=price },
								};

			var totalBefore = JobAdsCheckoutService.CalculateTotal(products);
			var matchedProductsCount = products.Count(X => X.Id == quantityDiscount.ProductId);

			// Act
			quantityDiscount.Apply(products);

			// Assert
			Assert.AreEqual(totalBefore, JobAdsCheckoutService.CalculateTotal(products) * 2);
			Assert.AreEqual(matchedProductsCount, products.Count(X => X.SpecialPricingRuleID != null));
			Assert.AreEqual(matchedProductsCount, products.Count(X => X.privilegedPrice != 0));
		}
	}
}
