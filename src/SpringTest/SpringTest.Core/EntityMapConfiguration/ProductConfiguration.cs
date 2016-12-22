using System.Data.Entity.ModelConfiguration;
using SpringTest.Domain.Entities;

namespace SpringTest.Core.EntityMapConfiguration {
	public class ProductConfiguration : EntityTypeConfiguration<Product> {
		public ProductConfiguration() {
			Property(x => x.Name)
				.HasColumnName("Name")
				.HasMaxLength(150);

			Property(x => x.Description)
				.HasColumnName("Description")
				.HasMaxLength(500);

			Property(x => x.Price)
				.HasColumnName("Price");
		}
	}
}
