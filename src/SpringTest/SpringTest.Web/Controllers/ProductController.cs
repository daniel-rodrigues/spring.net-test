using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Services;

namespace SpringTest.Web.Controllers {
	public class ProductController : Controller {
		
		private readonly IProductService productService;		
		private readonly ICategoryService categoryService;		

		public ProductController(IProductService productService, ICategoryService categoryService) {
			this.productService = productService;
			this.categoryService = categoryService;
		}
		public ActionResult Index() {
			var model = productService.GetAll(includes: "Category");
			return View(model);
		}

		public ActionResult Details(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = productService.Get(c => c.Id == id);
			return View(model);
		}

		public ActionResult Create() {
			ViewBag.CategoryId = categoryService.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });			
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Product model) {
			try {
				if (ModelState.IsValid) {
					productService.Add(model);
					productService.Commit();
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}
			
			ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name");
			return View(model);
		}

		public ActionResult Edit(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = productService.Get(c => c.Id == id);
			ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", model.CategoryId);

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Product model) {
			try {
				if (ModelState.IsValid) {
					productService.Update(model);
					productService.Commit();
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}

			ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Name", model.CategoryId);
			return View(model);
		}

		public ActionResult Delete(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Product model) {
			try {
				productService.Delete(id);
				productService.Commit();
				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}
	}
}
