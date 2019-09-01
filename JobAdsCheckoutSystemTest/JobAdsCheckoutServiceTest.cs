using JobAdsCheckoutSystem;
using JobAdsCheckoutSystem.Products;
using Moq;
using NUnit.Framework;
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
			var noSpecialPricingRuleCustomer = "NoSpecialPricingRuleCustomer";
			var noSpecialPricingRule = new List<ISpecialPricingRule>();
			var noProducts = new List<Product>();

			var ipricingRulesServiceMock = new Mock<IpricingRulesService>();
			ipricingRulesServiceMock
				.Setup(m => m.GetActiveSpecialPricingRules(noSpecialPricingRuleCustomer))
				.Returns(noSpecialPricingRule);
																		
			// Act
			var result = JobAdsCheckoutService.Checkout(noSpecialPricingRuleCustomer, noProducts, ipricingRulesServiceMock.Object);

			// Assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Checkout_SpecialPricingRuleCustomerNoProducts_ReturnsZero()
		{
			// Arrange
			var specialPricingRuleCustomer = "SpecialPricingRuleCustomer";
			var specialPricingRule = new List<ISpecialPricingRule>() { new SpecialPricingRule() };
			var noProducts = new List<Product>();

			var ipricingRulesServiceMock = new Mock<IpricingRulesService>();
			ipricingRulesServiceMock
				.Setup(m => m.GetActiveSpecialPricingRules(specialPricingRuleCustomer))
				.Returns(specialPricingRule);

			// Act
			var result = JobAdsCheckoutService.Checkout(specialPricingRuleCustomer, noProducts, ipricingRulesServiceMock.Object);

			// Assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Checkout_NoSpecialPricingRuleCustomerWithProducts_ReturnsProductsTotalPrice()
		{
			// Arrange
			var noSpecialPricingRuleCustomer = "NoSpecialPricingRuleCustomer";
			var noSpecialPricingRule = new List<ISpecialPricingRule>();
			var products = new List<Product>() {    new Classic(),
													new Standout(),
													new Premium()
												};

			var ipricingRulesServiceMock = new Mock<IpricingRulesService>();
			ipricingRulesServiceMock
				.Setup(m => m.GetActiveSpecialPricingRules(noSpecialPricingRuleCustomer))
				.Returns(noSpecialPricingRule);

			// Act
			var result = JobAdsCheckoutService.Checkout(noSpecialPricingRuleCustomer, products, ipricingRulesServiceMock.Object);

			// Assert
			Assert.AreEqual(products.Sum(X => X.Price), result);
		}

		[TestMethod]
		public void Checkout_SpecialPricingRuleCustomerWithProductsWithNoRuleMatch_ReturnsProductsTotalPrice()
		{
			// Arrange
			var specialPricingRuleCustomer = "SpecialPricingRuleCustomer";
			var specialPricingRule = new List<ISpecialPricingRule>() { new SpecialPricingRule() };
			var products = new List<Product>() {    new Classic(),
													new Standout(),
													new Premium()
												};

			var ipricingRulesServiceMock = new Mock<IpricingRulesService>();
			ipricingRulesServiceMock
				.Setup(m => m.GetActiveSpecialPricingRules(specialPricingRuleCustomer))
				.Returns(specialPricingRule);

			// Act
			var result = JobAdsCheckoutService.Checkout(specialPricingRuleCustomer, products, ipricingRulesServiceMock.Object);

			// Assert
			Assert.AreEqual(products.Sum(X => X.Price), result);
		}
	}
}