using AutoMapper;
using SpringTest.Domain.Entities;
using SpringTest.Web.Models;

namespace SpringTest.Web.Mappers                                                                                                                                                                                                                                             {
	public class ViewModelToDomainMapping : Profile {
		
		protected override void Configure() {
			CreateMap<CategoryViewModel, Category>();
			CreateMap<ProductViewModel, Product>();		 
		}
	}
}