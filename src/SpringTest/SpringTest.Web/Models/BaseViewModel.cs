using System;
using System.ComponentModel;

namespace SpringTest.Web.Models {
	public abstract class BaseViewModel {
		public int Id { get; set; }

		[DisplayName("Data de Cadastro")]
		public DateTime CreatedAt { get; set; }

		[DisplayName("Data de Alteração")]
		public DateTime? UpdatedAt { get; set; }
	}
}