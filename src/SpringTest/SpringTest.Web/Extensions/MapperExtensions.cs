using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SpringTest.Domain.Entities;
using SpringTest.Web.Models;

namespace SpringTest.Web.Extensions {
	public static class MapperExtensions {
		#region Category

		public static CategoryViewModel ToModel(this Category entity) {
			return Mapper.Map<Category, CategoryViewModel>(entity);
		}

		public static Category ToEntity(this CategoryViewModel model) {
			return Mapper.Map<CategoryViewModel, Category>(model);
		}

		public static Category ToEntity(this CategoryViewModel model, Category destination) {
			return Mapper.Map(model, destination);
		}

		public static IList<CategoryViewModel> ToModelList(this IEnumerable<Category> entities) {
			return entities.Select(entity => entity.ToModel()).ToList();
		}

		#endregion

		#region Product

		public static ProductViewModel ToModel(this Product entity) {
			return Mapper.Map<Product, ProductViewModel>(entity);
		}

		public static Product ToEntity(this ProductViewModel model) {
			return Mapper.Map<ProductViewModel, Product>(model);
		}

		public static Product ToEntity(this ProductViewModel model, Product destination) {
			return Mapper.Map(model, destination);
		}

		public static IList<ProductViewModel> ToModelList(this IEnumerable<Product> entities) {
			return entities.Select(entity => entity.ToModel()).ToList();
		}

		#endregion

	}
}