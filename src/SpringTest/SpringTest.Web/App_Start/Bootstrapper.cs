using SpringTest.Web.Mappers;

namespace SpringTest.Web.App_Start {
	public static class Bootstrapper {
		public static void Run() {
			AutoMapperConfiguration.Configure();
		}
	}
}