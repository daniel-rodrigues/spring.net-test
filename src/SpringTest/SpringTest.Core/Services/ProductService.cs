using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;
using SpringTest.Domain.Services;

namespace SpringTest.Core.Services {
	public class ProductService : IProductService{
		private readonly IProductRepository productRepository;

		public ProductService(IProductRepository productRepository) {
			this.productRepository = productRepository;
		}

		public void Add(Product product) {
			productRepository.Add(product);
		}

		public void AddOrUpdate(Product product) {
			productRepository.AddOrUpdate(product);
		}

		public void Commit() {
			productRepository.Commit();
		}

		public void Delete(Expression<Func<Product, bool>> where) {
			productRepository.Delete(where);
		}

		public void Delete(int id) {
			productRepository.Delete(id);
		}

		public Product Get(Expression<Func<Product, bool>> where, string includes = "") {
			return productRepository.Get(where, includes);
		}

		public IEnumerable<Product> GetAll(string includes = "") {
			return productRepository.GetAll(includes);
		}

		public IEnumerable<Product> GetMany(Expression<Func<Product, bool>> where, string includes = "") {
			return productRepository.GetMany(where, includes);
		}

		public void Update(Product product) {
			productRepository.Update(product);
		}
	}
}
