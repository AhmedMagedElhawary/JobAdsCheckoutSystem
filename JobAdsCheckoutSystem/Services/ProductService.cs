using JobAdsCheckoutSystem.Models;
using JobAdsCheckoutSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdsCheckoutSystem.Services
{
	public class ProductService : IProductService
	{
		private IProductRepository productRepository;

		public ProductService()
		{
			productRepository = new JsonProductRepository();
		}
		public ProductService(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		#nullable enable
		public Product? GetProduct(string code)
		{
			return productRepository.GetProduct(code);
		}

		#nullable enable
		public Product? GetProduct(Guid Id)
		{
			return productRepository.GetProduct(Id);
		}
	}
}