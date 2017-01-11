using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Services;
using SpringTest.Web.Models;

namespace SpringTest.Web.Controllers {
	public class CategoryController : BaseController {
				
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService) {			
			this.categoryService = categoryService;
		}
		public ActionResult Index() {
			var model = Mapper.Map<IEnumerable<CategoryViewModel>>(categoryService.GetAll());
			return View(model);
		}

		public ActionResult Details(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = Mapper.Map<CategoryViewModel>(categoryService.Get(c => c.Id == id));
			return View(model);
		}

		public ActionResult Create() {
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CategoryViewModel viewModel) {
			try {
				if (ModelState.IsValid) {
					categoryService.Add(Mapper.Map<Category>(viewModel));					
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}

			return View(viewModel);
		}

		public ActionResult Edit(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var viewModel = Mapper.Map<CategoryViewModel>(categoryService.Get(c => c.Id == id));
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, CategoryViewModel viewModel) {
			try {
				if (ModelState.IsValid) {					
					categoryService.Update(Mapper.Map<Category>(viewModel));					
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}
			return View(viewModel);
		}

		public ActionResult Delete(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var viewModel = Mapper.Map<CategoryViewModel>(categoryService.Get(c => c.Id == id));
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, CategoryViewModel viewModel) {
			try {
				categoryService.Delete(viewModel.Id);				
				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}
	}	
}
