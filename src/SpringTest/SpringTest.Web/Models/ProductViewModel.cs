using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpringTest.Web.Models {
	public class ProductViewModel : BaseViewModel {

		[DisplayName("Nome")]
		[Required]
		[MaxLength(150)]
		public string Name { get; set; }

		[DisplayName("Descrição")]
		[MaxLength(500)]
		public string Description { get; set; }

		[Required]
		[DisplayName("Preço")]
		public double Price { get; set; }

		[Required]
		[DisplayName("Categoria")]
		public int CategoryId { get; set; }
				
		[DisplayName("Categoria")]
		public CategoryViewModel Category { get; set; }
	}
}