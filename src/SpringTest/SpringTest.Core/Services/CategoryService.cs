using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;
using SpringTest.Domain.Services;

namespace SpringTest.Core.Services {
	public class CategoryService : ICategoryService {
		private readonly ICategoryRepository categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository) {
			this.categoryRepository = categoryRepository;
		}

		public void Add(Category category) {
			categoryRepository.Add(category);
			categoryRepository.Commit();
		}

		public void AddOrUpdate(Category category) {
			categoryRepository.AddOrUpdate(category);
			categoryRepository.Commit();
		}

		public void Delete(Expression<Func<Category, bool>> where) {
			categoryRepository.Delete(where);
			categoryRepository.Commit();
		}

		public void Delete(int id) {
			categoryRepository.Delete(id);
			categoryRepository.Commit();
		}

		public Category Get(Expression<Func<Category, bool>> where, string includes = "") {
			return categoryRepository.Get(where, includes);
		}

		public IEnumerable<Category> GetAll(string includes = "") {
			return categoryRepository.GetAll(includes);
		}

		public IEnumerable<Category> GetMany(Expression<Func<Category, bool>> where, string includes = "") {
			return categoryRepository.GetMany(where, includes);
		}

		public void Update(Category category) {
			categoryRepository.Update(category);
			categoryRepository.Commit();
		}		
	}
}
