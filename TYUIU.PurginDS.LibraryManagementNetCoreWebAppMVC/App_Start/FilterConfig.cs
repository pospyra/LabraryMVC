using System.Web;
using System.Web.Mvc;

namespace TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
