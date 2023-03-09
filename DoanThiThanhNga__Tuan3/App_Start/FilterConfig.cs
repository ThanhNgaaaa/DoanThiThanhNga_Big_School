using System.Web;
using System.Web.Mvc;

namespace DoanThiThanhNga__Tuan3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
