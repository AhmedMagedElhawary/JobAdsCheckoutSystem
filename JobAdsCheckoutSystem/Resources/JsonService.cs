﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace JobAdsCheckoutSystem.Resources
{
	class JsonService
	{
		public static IEnumerable<dynamic> JsonResourceDeserializer(byte[] JsonResourceFile)
		{
			return JsonConvert.DeserializeObject<List<ExpandoObject>>(
				 Encoding.UTF8.GetString(JsonResourceFile),
				new ExpandoObjectConverter());
		}
	}
}
