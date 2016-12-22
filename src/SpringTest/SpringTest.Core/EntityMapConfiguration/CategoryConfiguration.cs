using System.Data.Entity.ModelConfiguration;
using SpringTest.Domain.Entities;

namespace SpringTest.Core.EntityMapConfiguration {
	public class CategoryConfiguration : EntityTypeConfiguration<Category>{
		public CategoryConfiguration() {
			Property(x => x.Name)
				.HasColumnName("Name")
				.HasMaxLength(150);

			Property(x=>x.Description)
				.HasColumnName("Description")
				.HasMaxLength(500);			
		}
	}
}
