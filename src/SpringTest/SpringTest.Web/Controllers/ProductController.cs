using System.Linq;
using System.Net;
using System.Web.Mvc;
using SpringTest.Core.EfContext;
using SpringTest.Core.Repositories;
using SpringTest.Core.Services;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;
using SpringTest.Domain.Services;

namespace SpringTest.Web.Controllers {
	public class ProductController : Controller {

		private IProductRepository _productRepository;
		private IProductService _productService;
		private ICategoryRepository _categoryRepository;
		private ICategoryService _categoryService;
		private EfDbContext _context;

		public ProductController() {
			_context = new EfDbContext();
			_productRepository = new ProductRepository(_context);
			_productService = new ProductService(_productRepository);
			_categoryRepository = new CategoryRepository(_context);
			_categoryService = new CategoryService(_categoryRepository);
		}
		public ActionResult Index() {
			var model = _productService.GetAll(includes: "Category");
			return View(model);
		}

		public ActionResult Details(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = _productService.Get(c => c.Id == id);
			return View(model);
		}

		public ActionResult Create() {
			ViewBag.CategoryId = _categoryService.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });			
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Product model) {
			try {
				if (ModelState.IsValid) {
					_productService.Add(model);
					_productService.Commit();
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}
			
			ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name");
			return View(model);
		}

		public ActionResult Edit(int id) {
			if (id == 0)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var model = _productService.Get(c => c.Id == id);
			ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name", model.CategoryId);

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Product model) {
			try {
				if (ModelState.IsValid) {
					_productService.Update(model);
					_productService.Commit();
					return RedirectToAction("Index");
				}
			} catch {
				return View();
			}

			ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name", model.CategoryId);
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
				_productService.Delete(id);
				_productService.Commit();
				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}
	}
}
