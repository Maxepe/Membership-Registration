using System.Web;
using System.Web.Mvc;

namespace Parcial2_PROGIII_110925
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
