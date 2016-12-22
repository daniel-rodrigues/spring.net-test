using System;

namespace SpringTest.Domain.Entities {
	public abstract class EntityBase {
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdateAt { get; set; }
	}
}
