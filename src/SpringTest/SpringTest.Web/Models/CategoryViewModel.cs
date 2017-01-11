using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringTest.Web.Models {
	public class CategoryViewModel : BaseViewModel {
		public string Name { get; set; }
		public string Description { get; set; }
		public IEnumerable<ProductViewModel> Products { get; set; }
	}
}