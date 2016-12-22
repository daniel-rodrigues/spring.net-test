namespace SpringTest.Domain.Entities {
	public class Product : EntityBase {
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}