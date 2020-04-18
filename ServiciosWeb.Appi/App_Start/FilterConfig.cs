using System.Web;
using System.Web.Mvc;

namespace ServiciosWeb.Appi
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
