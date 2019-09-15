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
	public class PricingRulesServiceTest
	{
		[TestMethod]
		public void GetActiveSpecialPricingRules_EmptySpecialPricingRules_ReturnsEmptyList()
		{
			// Arrange
			var noSpecialPricingRule = new List<SPR>();

			var PricingRulesRepository = new Mock<IPricingRulesRepository>();
			PricingRulesRepository
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(noSpecialPricingRule);

			// Act
			var result = new PricingRulesService(PricingRulesRepository.Object).GetActiveSpecialPricingRules(Guid.NewGuid());

			// Assert
			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		public void GetActiveSpecialPricingRules_NoActiveSpecialPricingRules_ReturnsEmptyList()
		{
			// Arrange
			var customerId = Guid.NewGuid();
			var noActiveSpecialPricingRule = new List<SPR>() { new SPRQuantityDiscount() { CustomerId = customerId, IsActive = false} };

			var ipricingRulesServiceMock = new Mock<IPricingRulesRepository>();
			ipricingRulesServiceMock
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(noActiveSpecialPricingRule);

			// Act
			var result = new PricingRulesService(ipricingRulesServiceMock.Object).GetActiveSpecialPricingRules(customerId);

			// Assert
			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		public void GetActiveSpecialPricingRules_MixedActiveInActiveSpecialPricingRules_ReturnsActiveOnlyList()
		{
			// Arrange
			var customerId = Guid.NewGuid();
			var mixedActiveInActiveSpecialPricingRules = 
				new List<SPR>() {
					new SPRQuantityDiscount() { CustomerId = customerId, IsActive = true },
					new SPRQuantityDiscount() { CustomerId = customerId, IsActive = false },
					new SPRQuantityDiscount() { CustomerId = customerId, IsActive = true }
				};

			var ipricingRulesServiceMock = new Mock<IPricingRulesRepository>();
			ipricingRulesServiceMock
				.Setup(m => m.GetSpecialPricingRules())
				.Returns(mixedActiveInActiveSpecialPricingRules);

			// Act
			var result = new PricingRulesService(ipricingRulesServiceMock.Object).GetActiveSpecialPricingRules(customerId);

			// Assert
			Assert.AreEqual(2, result.Count());
		}
	}
}