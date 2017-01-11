using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringTest.Core.EfContext;
using SpringTest.Core.Repositories;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;

namespace SpringTest.Core.Tests {
	[TestClass]
	public class CategoryRespositoryTests {
		private readonly ICategoryRepository categoryRepository;
		//private readonly RepositoryList<Usuario> _repository;

		public CategoryRespositoryTests() {
			//efDbContext = new EfDbContext();
			//categoryRepository = new CategoryRepository(efDbContext);
		}

		[TestMethod]
		public void CategoryRepository_Add_New_Category() {
			//var category = new Category { Name = "Normal",Description = "New category for products" };
			//var categoryCountBeforeAdd = categoryRepository.GetAll().Count();
			//categoryRepository.Add(category);
			//categoryRepository.Commit();
			//var categoryCountAfterAdd = categoryRepository.GetAll().Count();
			//Assert.AreEqual(categoryCountBeforeAdd + 1, categoryCountAfterAdd);
		}
	}
}
