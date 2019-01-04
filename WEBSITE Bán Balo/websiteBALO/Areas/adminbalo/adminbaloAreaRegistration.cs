using System.Web.Mvc;

namespace websiteBALO.Areas.adminbalo
{
    public class adminbaloAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "adminbalo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "adminbalo_default",
                "adminbalo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] {"websiteBALO.Areas.adminbalo.Controllers"}
            );
        }
    }
}