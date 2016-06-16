using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Globalization;
using System.Threading;


namespace multilanguag3
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {

        }

        private void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
            {
                try
                {
                    HttpContext context = HttpContext.Current;

                    if (null != context.Session["myapplication.language"])
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(context.Session["myapplication.language"].ToString().Trim());
                        Thread.CurrentThread.CurrentCulture = new CultureInfo(context.Session["myapplication.language"].ToString().Trim());
                    }
                }
                catch (System.Exception)
                {
                    //null reference exception
                }
            }
        }
    }
}