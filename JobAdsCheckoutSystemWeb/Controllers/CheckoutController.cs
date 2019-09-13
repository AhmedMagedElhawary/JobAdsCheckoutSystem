using JobAdsCheckoutSystemWeb.Data;
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

namespace JobAdsCheckoutSystemWeb.Controllers
{

	//	price = JobAdsCheckoutService.Checkout("UnderprivilegedCustomerId",
	//									new List<Product>() {
	//										new Classic(),
	//										new Standout(),
	//										new Premium() }
	//									);
	//Console.WriteLine("Total calcualted: ${0}\n", price);

	//public IEnumerable<Category> GetCategories
	//([ModelBinder(typeof(CommaDelimitedArrayModelBinder))]long[] categoryIds)
	//{
	//	// do your thing
	//}

	public class CommaDelimitedArrayModelBinder : IModelBinder
	{
		public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
		{
			//var key = bindingContext.ModelName;
			//https://localhost:44347/api/checkout?CutomerId=1&Products=2,10

			try
			{
				var CutomerId = bindingContext.ValueProvIder.GetValue("CutomerId").AttemptedValue;
				var Products = bindingContext.ValueProvIder.GetValue("Products").AttemptedValue;

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
				using (var context = new AppDbContext())
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
