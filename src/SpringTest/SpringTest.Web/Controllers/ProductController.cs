using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Services;
using SpringTest.Web.Models;

namespace SpringTest.Web.Controllers {
	public class ProductController : BaseController {

		private readonly IProductService productService;
		private readonly ICategoryService categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService) {
			this.productService = productService;
			this.categoryService = categoryService;
		}
		public ActionResult Index() {
			var viewModelList = Mapper.Map<IEnumerable<ProductViewModel>>(productService.GetAll(includes: "Category"));

			return View(viewModelList);
		}

		public ActionResult Details(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var viewModel = Mapper.Map<ProductViewModel>(productService.Get(c => c.Id == id, includes: "Category"));
			return View(viewModel);
		}

		public ActionResult Create() {
			ViewBag.Categories = categoryService.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,Description,Price,CategoryId")] ProductViewModel viewModel) {
			try {
				if (ModelState.IsValid) {
					productService.Add(Mapper.Map<Product>(viewModel));					
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}

			ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name");
			return View(viewModel);
		}

		public ActionResult Edit(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var viewModel = Mapper.Map<ProductViewModel>(productService.Get(c => c.Id == id));
			ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", viewModel.CategoryId);

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,CategoryId")] ProductViewModel viewModel) {
			try {
				if (ModelState.IsValid) {
					productService.Update(Mapper.Map<Product>(viewModel));				
					return RedirectToAction("Index");
				}
			} catch (Exception ex) {
				return View();
			}

			ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", viewModel.CategoryId);
			return View(viewModel);
		}

		public ActionResult Delete(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var viewModel = Mapper.Map<ProductViewModel>(productService.Get(p => p.Id == id, includes: "Category"));

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, ProductViewModel viewModel) {
			try {
				productService.Delete(viewModel.Id);				
				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}
	}
}
