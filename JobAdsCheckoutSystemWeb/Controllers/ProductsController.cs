using JobAdsCheckoutSystemWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobAdsCheckoutSystemWeb.Controllers
{
    public class ProductsController : ApiController
    {
		public IHttpActionResult GetPRoducts()
		{
			try
			{
				using (var context = new AppDbContext())
				{
					var products = context.Products.ToList();
					return Ok(products);
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
    }
}
