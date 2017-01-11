using AutoMapper;
using SpringTest.Domain.Entities;
using SpringTest.Web.Models;

namespace SpringTest.Web.Mappers {
	public class DomainToViewModelMapping : Profile {
		
		protected override void Configure() {
			CreateMap<Category, CategoryViewModel>().PreserveReferences();
			CreateMap<Product, ProductViewModel>().PreserveReferences();
		}
	}
}