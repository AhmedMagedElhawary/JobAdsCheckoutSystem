using JobAdsCheckoutSystem;
using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using JobAdsCheckoutSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace JobAdsCheckoutSystemTest
{
	[TestClass]
	public class JobAdsCheckoutServiceTest
	{
		[TestMethod]
		public void Checkout_NoSpecialPricingRuleCustomerNoProducts_ReturnsZero()
		{
			// Arrange
			var noSpecialPricingRuleCustomerId = Guid.NewGuid();
			var noSpecialPricingRule = new List<SPR>();
			var noProducts = new List<Product>();

			var ipricingRulesRepositoryMock = new Mock<IPricingRulesRepository>();
			ipricingRulesRepositoryMock
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(noSpecialPricingRule);

			var iProductRepositoryMock = new Mock<IProductRepository>();
			iProductRepositoryMock
				.Setup(m => m.GetAllProducts())
				.Returns(noProducts);

			// Act
			var result = new JobAdsCheckoutService(new PricingRulesService(ipricingRulesRepositoryMock.Object), new ProductService(iProductRepositoryMock.Object)).Checkout(noSpecialPricingRuleCustomerId, noProducts.Select(x=> x.Id).ToList());

			// Assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Checkout_SpecialPricingRuleCustomerNoProducts_ReturnsZero()
		{
			// Arrange
			var specialPricingRuleCustomerId = Guid.NewGuid();
			var specialPricingRule = new List<SPR>() { new SPRQuantityDiscount() };
			var noProducts = new List<Product>();

			var ipricingRulesRepositoryMock = new Mock<IPricingRulesRepository>();
			ipricingRulesRepositoryMock
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(specialPricingRule);

			var iProductRepositoryMock = new Mock<IProductRepository>();
			iProductRepositoryMock
				.Setup(m => m.GetAllProducts())
				.Returns(noProducts);

			// Act
			var result = new JobAdsCheckoutService(new PricingRulesService(ipricingRulesRepositoryMock.Object), new ProductService(iProductRepositoryMock.Object)).Checkout(specialPricingRuleCustomerId, noProducts.Select(X=> X.Id).ToList());

			// Assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Checkout_NoSpecialPricingRuleCustomerWithProducts_ReturnsProductsTotalPrice()
		{
			// Arrange
			var noSpecialPricingRuleCustomerId = Guid.NewGuid();
			var noSpecialPricingRule = new List<SPR>();
			var products = new List<Product>() {    new Product(),
													new Product(),
													new Product()
												};

			var ipricingRulesRepositoryMock = new Mock<IPricingRulesRepository>();
			ipricingRulesRepositoryMock
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(noSpecialPricingRule);

			var iProductRepositoryMock = new Mock<IProductRepository>();
			iProductRepositoryMock
				.Setup(m => m.GetAllProducts())
				.Returns(products);

			// Act
			var result = new JobAdsCheckoutService(new PricingRulesService(ipricingRulesRepositoryMock.Object), new ProductService(iProductRepositoryMock.Object)).Checkout(noSpecialPricingRuleCustomerId, products.Select(X=> X.Id).ToList());

			// Assert
			Assert.AreEqual(products.Sum(X => X.Price), result);
		}

		[TestMethod]
		public void Checkout_SpecialPricingRuleCustomerWithProductsWithNoRuleMatch_ReturnsProductsTotalPrice()
		{
			// Arrange
			var specialPricingRuleCustomerId = Guid.NewGuid();
			var specialPricingRule = new List<SPR>() { new SPRBuyXGetYFree() { Id = Guid.NewGuid(), IsActive = true, CustomerId = specialPricingRuleCustomerId, ProductId = Guid.NewGuid() } };
			var products = new List<Product>() {    new Product(),
													new Product(),
													new Product()
												};

			var ipricingRulesRepositoryMock = new Mock<IPricingRulesRepository>();
			ipricingRulesRepositoryMock
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(specialPricingRule);

			var iProductRepositoryMock = new Mock<IProductRepository>();
			iProductRepositoryMock
				.Setup(m => m.GetAllProducts())
				.Returns(products);

			// Act
			var result = new JobAdsCheckoutService(new PricingRulesService(ipricingRulesRepositoryMock.Object), new ProductService(iProductRepositoryMock.Object)).Checkout(specialPricingRuleCustomerId, products.Select(X=> X.Id).ToList());

			// Assert
			Assert.AreEqual(products.Sum(X => X.Price), result);
		}
	}
}