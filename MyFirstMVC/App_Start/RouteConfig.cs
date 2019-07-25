using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyFirstMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //burada /hakkimda uzantısı yazdığımızda /Home/About uzantısına eşdeğer olduğunu belirtmiş oluyoruz.
            routes.MapRoute("hakkimdaRoute", "hakkimda", new { controller = "Home", action = "About" },
                namespaces: new string[] { "MyFirstMVC.Controllers" });
            routes.MapRoute("iletisimRoute", "iletisim", new { controller = "Home", action = "Contact" },
                namespaces: new string[] { "MyFirstMVC.Controllers" });
            routes.MapRoute("projelerRoute", "projeler", new { controller = "Home", action = "Project" },
                namespaces: new string[] { "MyFirstMVC.Controllers" });
            routes.MapRoute("kvkkRoute", "kvkk", new { controller = "Home", action = "Kvkk" },
                namespaces: new string[] { "MyFirstMVC.Controllers" });
            routes.MapRoute("cookieRoute", "cookie", new { controller = "Home", action = "Cookie" },
                namespaces: new string[] { "MyFirstMVC.Controllers" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[]{ "MyFirstMVC.Controllers"}
            );
            //yukarda namespaces eklememizin sebebi iki tane aynı adlı controller kullandığımızda karışmaması için bir çözüm yöntemi
            //diğer sayfalarda da problem olmaması için hepsine ekleme yaptık.
        }
    }
}
