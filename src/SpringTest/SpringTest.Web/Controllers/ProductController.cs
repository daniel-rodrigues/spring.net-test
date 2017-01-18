using System.Linq;
using System.Net;
using System.Web.Mvc;
using SpringTest.Domain.Services;
using SpringTest.Web.Extensions;
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
			var viewModelList = productService.GetAll(includes: "Category").ToModelList();

			return View(viewModelList);
		}

		public ActionResult Details(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var viewModel = productService.Get(p => p.Id == id, includes: "Category").ToModel();
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
					productService.Add(viewModel.ToEntity());
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

			var viewModel = productService.Get(p => p.Id == id).ToModel();
			ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", viewModel.CategoryId);

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,CategoryId")] ProductViewModel viewModel) {
			try {
				if (ModelState.IsValid) {
					productService.Update(viewModel.ToEntity());
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}

			ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", viewModel.CategoryId);
			return View(viewModel);
		}

		public ActionResult Delete(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var viewModel = productService.Get(p => p.Id == id, includes: "Category").ToModel();

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
