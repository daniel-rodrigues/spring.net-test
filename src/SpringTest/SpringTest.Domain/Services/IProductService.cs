using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SpringTest.Domain.Entities;

namespace SpringTest.Domain.Services {
	public interface IProductService {
		void Add(Product product);
		void AddOrUpdate(Product product);
		void Update(Product product);
		void Delete(int id);
		void Delete(Expression<Func<Product, bool>> where);
		Product Get(Expression<Func<Product, bool>> where, string includes = "");
		IEnumerable<Product> GetAll(string includes = "");
		IEnumerable<Product> GetMany(Expression<Func<Product, bool>> where, string includes = "");		
	}
}
