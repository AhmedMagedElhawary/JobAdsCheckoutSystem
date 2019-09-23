//using JobAdsCheckoutSystemWeb.Data;
using JobAdsCheckoutSystem;
using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using JobAdsCheckoutSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;

namespace JobAdsCheckoutSystemWebAPI.Controllers
{
	public class CommaDelimitedArrayModelBinder : IModelBinder
	{
		public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
		{			
			try
			{
				var CutomerId = bindingContext.ValueProvider.GetValue("CutomerId").AttemptedValue;
				var Products = bindingContext.ValueProvider.GetValue("Products").AttemptedValue;

				bindingContext.Model = new CheckoutData {	cutomerId = new Guid(CutomerId),
															productsId = Products
															.Split(',')
															.Select(X=> new Guid(X))
															.Where(X => X != null)
															.ToList()
														};

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	//public class CheckoutData
	//{
	//	public Guid CutomerId { get; set; }
	//	public List<Guid> ProductsId { get; set; }
	//}

	[EnableCors("*","*","*")]
    public class CheckoutController : ApiController
    {
		[HttpGet]
		//http://localhost:8080/api/checkout?CutomerId=1&Products=2,10


		//http://localhost:8080/api/checkout?CutomerId=9ef6ac0b-9f36-4db4-a498-0070a00b7af8&Products=018a5e88-0f30-4409-b78c-2d8a824d70b7,018a5e88-0f30-4409-b78c-2d8a824d70b7,018a5e88-0f30-4409-b78c-2d8a824d70b7,c5b2084c-9bd7-400f-bf9a-9be14453c7c0
		//Console.WriteLine("{0} \n{1} \n{2}", "Customer: Unilever",
		//						 "SKUs Scanned: 'classic', 'classic', 'classic', 'premium'",
		//						 "Total expected: $934.97");

		public IHttpActionResult Checkout([ModelBinder(typeof(CommaDelimitedArrayModelBinder))]CheckoutData ResourceQuery)
		{
			try
			{
				//using (var context = new AppDbContext())
				{
					var total = new JobAdsCheckoutService(new PricingRulesService(new JsonPricingRulesRepository()),
															new ProductService(new JsonProductRepository()))
																.Checkout(ResourceQuery.cutomerId, ResourceQuery.productsId);
					return Ok(total);
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
    }
}
