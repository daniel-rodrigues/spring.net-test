using System.Collections.Generic;

namespace SpringTest.Domain.Entities {
	public class Category : EntityBase {
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
}
