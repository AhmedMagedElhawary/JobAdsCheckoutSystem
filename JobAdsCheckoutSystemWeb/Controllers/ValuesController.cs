using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobAdsCheckoutSystemWeb.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public string Get(int Id)
		{
			return "value";
		}

		// POST api/values
		public voId Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public voId Put(int Id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public voId Delete(int Id)
		{
		}
	}
}
