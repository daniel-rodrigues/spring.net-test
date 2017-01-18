using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpringTest.Web.Models {
	public class CategoryViewModel : BaseViewModel {

		[DisplayName("Nome")]
		[Required]
		[MaxLength(150)]
		public string Name { get; set; }

		[DisplayName("Descrição")]
		[MaxLength(500)]
		public string Description { get; set; }
		public IEnumerable<ProductViewModel> Products { get; set; }
	}
}