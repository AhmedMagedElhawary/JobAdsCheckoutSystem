//using JobAdsCheckoutSystemWeb.Data;
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
			//var key = bindingContext.ModelName;
			//http://localhost:8080/api/checkout?CutomerId=1&Products=2,10
			try
			{
				var CutomerId = bindingContext.ValueProvider.GetValue("CutomerId").AttemptedValue;
				var Products = bindingContext.ValueProvider.GetValue("Products").AttemptedValue;

				bindingContext.Model = new ResourceQuery { CutomerId = CutomerId,
															Products = Products
																			.Split(',')
																			.Select(X => X.Trim())
																			.Where(X => !string.IsNullOrEmpty(X))
																			.ToList()};
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	public class ResourceQuery
	{
		public string CutomerId { get; set; }
		public List<string> Products { get; set; }
	}

	[EnableCors("*","*","*")]
    public class CheckoutController : ApiController
    {
		[HttpGet]
		//public IHttpActionResult Checkout([FromUri] ResourceQuery query)
		public IHttpActionResult Checkout([ModelBinder(typeof(CommaDelimitedArrayModelBinder))]ResourceQuery ResourceQuery)
		{
			try
			{
				//using (var context = new AppDbContext())
				{
					//var total = query.CutomerId + query.Products.Sum();
					var total = 0;
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
