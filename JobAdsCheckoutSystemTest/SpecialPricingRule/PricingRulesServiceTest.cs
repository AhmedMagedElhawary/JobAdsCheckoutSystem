using JobAdsCheckoutSystem;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;

namespace JobAdsCheckoutSystemTest
{
	[TestClass]
	public class PricingRulesServiceTest
	{
		[TestMethod]
		public void GetActiveSpecialPricingRules_EmptySpecialPricingRules_ReturnsEmptyList()
		{
			// Arrange
			var noSpecialPricingRule = new List<ISpecialPricingRule>();

			var ipricingRulesServiceMock = new Mock<IPricingRulesRepository>();
			ipricingRulesServiceMock
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(noSpecialPricingRule);

			// Act
			var result = new PricingRulesService(ipricingRulesServiceMock.Object).GetActiveSpecialPricingRules("Customer");

			// Assert
			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		public void GetActiveSpecialPricingRules_NoActiveSpecialPricingRules_ReturnsEmptyList()
		{
			// Arrange
			var customerID = "ID";
			var noActiveSpecialPricingRule = new List<ISpecialPricingRule>() { new SpecialPricingRule() { CustomerID = customerID, IsActive = false} };

			var ipricingRulesServiceMock = new Mock<IPricingRulesRepository>();
			ipricingRulesServiceMock
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(noActiveSpecialPricingRule);

			// Act
			var result = new PricingRulesService(ipricingRulesServiceMock.Object).GetActiveSpecialPricingRules(customerID);

			// Assert
			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		public void GetActiveSpecialPricingRules_MixedActiveInActiveSpecialPricingRules_ReturnsActiveOnlyList()
		{
			// Arrange
			var customerID = "ID";
			var mixedActiveInActiveSpecialPricingRules = 
				new List<ISpecialPricingRule>() {
					new SpecialPricingRule() { CustomerID = customerID, IsActive = true },
					new SpecialPricingRule() { CustomerID = customerID, IsActive = false },
					new SpecialPricingRule() { CustomerID = customerID, IsActive = true }
				};

			var ipricingRulesServiceMock = new Mock<IPricingRulesRepository>();
			ipricingRulesServiceMock
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(mixedActiveInActiveSpecialPricingRules);

			// Act
			var result = new PricingRulesService(ipricingRulesServiceMock.Object).GetActiveSpecialPricingRules(customerID);

			// Assert
			Assert.AreEqual(2, result.Count());
		}
	}
}