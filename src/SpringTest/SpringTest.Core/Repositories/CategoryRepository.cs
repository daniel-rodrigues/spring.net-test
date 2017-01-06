using SpringTest.Core.EfContext;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;

namespace SpringTest.Core.Repositories {
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository {
		public CategoryRepository(EfDbContext efContext)
            : base(efContext)
        { }
		public CategoryRepository() {

		}
	}
}
