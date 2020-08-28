using System.Web.Mvc;

namespace MyHangman.App_Start
{
    public static class FiltersConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
        }
    }
}