using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpringTest.Core.EfContext;
using SpringTest.Core.Repositories;
using SpringTest.Core.Services;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;
using SpringTest.Domain.Services;

namespace SpringTest.Web.Controllers {
	public class CategoryController : Controller {

		private ICategoryRepository _categoryRepository;
		private ICategoryService _categoryService;
		public CategoryController() {
			_categoryRepository = new CategoryRepository(new EfDbContext());
			_categoryService = new CategoryService(_categoryRepository);
		}
		public ActionResult Index() {
			var model = _categoryService.GetAll();
			return View(model);
		}

		public ActionResult Details(int id) {
			return View();
		}

		public ActionResult Create() {
			return View();
		}

		[HttpPost]
		public ActionResult Create(Category model) {
			try {

				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}

		public ActionResult Edit(int id) {
			return View();
		}

		[HttpPost]
		public ActionResult Edit(int id, Category model) {
			try {

				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}

		public ActionResult Delete(int id) {
			return View();
		}

		[HttpPost]
		public ActionResult Delete(int id, Category model) {
			try {

				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}
	}
}
