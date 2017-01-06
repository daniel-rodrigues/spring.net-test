using System.Net;
using System.Web.Mvc;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Services;

namespace SpringTest.Web.Controllers {
	public class CategoryController : Controller {
				
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService) {			
			this.categoryService = categoryService;
		}
		public ActionResult Index() {
			var model = categoryService.GetAll();
			return View(model);
		}

		public ActionResult Details(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = categoryService.Get(c => c.Id == id);
			return View(model);
		}

		public ActionResult Create() {
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Category model) {
			try {
				if (ModelState.IsValid) {
					categoryService.Add(model);
					categoryService.Commit();
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}

			return View(model);
		}

		public ActionResult Edit(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = categoryService.Get(c => c.Id == id);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Category model) {
			try {
				if (ModelState.IsValid) {
					categoryService.Update(model);
					categoryService.Commit();
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}
			return View(model);
		}

		public ActionResult Delete(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Category model) {
			try {
				categoryService.Delete(id);
				categoryService.Commit();
				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}
	}
}
