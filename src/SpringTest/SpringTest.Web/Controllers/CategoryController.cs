using System.Net;
using System.Web.Mvc;
using SpringTest.Domain.Services;
using SpringTest.Web.Extensions;
using SpringTest.Web.Models;

namespace SpringTest.Web.Controllers {
	public class CategoryController : BaseController {
				
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService) {			
			this.categoryService = categoryService;
		}
		public ActionResult Index() {			
			var model = categoryService.GetAll().ToModelList();
			return View(model);
		}

		public ActionResult Details(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
						
			var viewModel = categoryService.Get(p => p.Id == id).ToModel();
			return View(viewModel);
		}

		public ActionResult Create() {
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CategoryViewModel viewModel) {
			try {
				if (ModelState.IsValid) {
					categoryService.Add(viewModel.ToEntity());					
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

			var viewModel = categoryService.Get(p => p.Id == id).ToModel();
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, CategoryViewModel viewModel) {
			try {
				if (ModelState.IsValid) {					
					categoryService.Update(viewModel.ToEntity());					
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

			var viewModel = categoryService.Get(p => p.Id == id).ToModel();
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
