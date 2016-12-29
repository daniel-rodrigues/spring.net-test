using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;
using SpringTest.Domain.Services;

namespace SpringTest.Core.Services {
	public class CategoryService : ICategoryService {
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository) {
			_categoryRepository = categoryRepository;
		}

		public void Add(Category category) {
			_categoryRepository.Add(category);
		}

		public void AddOrUpdate(Category category) {
			_categoryRepository.AddOrUpdate(category);
		}

		public void Delete(Expression<Func<Category, bool>> where) {
			_categoryRepository.Delete(where);
		}

		public void Delete(int id) {
			_categoryRepository.Delete(id);
		}

		public Category Get(Expression<Func<Category, bool>> where, string includes = "") {
			return _categoryRepository.Get(where, includes);
		}

		public IEnumerable<Category> GetAll(string includes = "") {
			return _categoryRepository.GetAll(includes);
		}

		public IEnumerable<Category> GetMany(Expression<Func<Category, bool>> where, string includes = "") {
			return _categoryRepository.GetMany(where, includes);
		}

		public void Update(Category category) {
			_categoryRepository.Update(category);
		}

		public void Commit() {
			_categoryRepository.Commit();
		}
	}
}
