using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringTest.Core.EfContext {
	public class EfContext : DbContext {
		public EfContext() : base("SpringTestConnection") {
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = true;
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties<string>()
					.Configure(p => p.HasColumnType("varchar"));

			modelBuilder.Properties<string>()
					.Configure(p => p.HasMaxLength(50));

			
		}
	}
}
