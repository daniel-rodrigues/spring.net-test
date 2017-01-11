using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringTest.Web.Models {
	public class ProductViewModel : BaseViewModel {		
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public int CategoryId { get; set; }
		public CategoryViewModel Category { get; set; }
	}
}