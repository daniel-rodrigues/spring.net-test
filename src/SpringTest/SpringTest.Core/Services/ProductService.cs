using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;
using SpringTest.Domain.Services;

namespace SpringTest.Core.Services {
	public class ProductService : IProductService{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository) {
			_productRepository = productRepository;
		}

		public void Add(Product product) {
			_productRepository.Add(product);
		}

		public void AddOrUpdate(Product product) {
			_productRepository.AddOrUpdate(product);
		}

		public void Commit() {
			_productRepository.Commit();
		}

		public void Delete(Expression<Func<Product, bool>> where) {
			_productRepository.Delete(where);
		}

		public void Delete(int id) {
			_productRepository.Delete(id);
		}

		public Product Get(Expression<Func<Product, bool>> where, string includes = "") {
			return _productRepository.Get(where, includes);
		}

		public IEnumerable<Product> GetAll(string includes = "") {
			return _productRepository.GetAll(includes);
		}

		public IEnumerable<Product> GetMany(Expression<Func<Product, bool>> where, string includes = "") {
			return _productRepository.GetMany(where, includes);
		}

		public void Update(Product product) {
			_productRepository.Update(product);
		}
	}
}
