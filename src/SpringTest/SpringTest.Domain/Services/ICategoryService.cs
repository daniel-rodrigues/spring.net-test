using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SpringTest.Domain.Entities;

namespace SpringTest.Domain.Services {
	public interface ICategoryService {
		void Add(Category category);
		void AddOrUpdate(Category category);
		void Update(Category category);
		void Delete(int id);
		void Delete(Expression<Func<Category, bool>> where);
		Category Get(Expression<Func<Category, bool>> where, string includes = "");
		IEnumerable<Category> GetAll(string includes = "");
		IEnumerable<Category> GetMany(Expression<Func<Category, bool>> where, string includes = "");
		void Commit();
	}
}
