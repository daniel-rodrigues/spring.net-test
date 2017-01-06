using SpringTest.Core.EfContext;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;

namespace SpringTest.Core.Repositories {
	public class ProductRepository : RepositoryBase<Product>, IProductRepository{
		
		public ProductRepository(EfDbContext efContext)
            : base(efContext)
        { }
		public ProductRepository() {

		}
	}
}
