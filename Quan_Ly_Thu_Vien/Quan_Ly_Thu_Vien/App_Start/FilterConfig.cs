using System.Web;
using System.Web.Mvc;

namespace Quan_Ly_Thu_Vien
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
