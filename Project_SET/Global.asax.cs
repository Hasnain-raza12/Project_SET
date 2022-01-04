using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace Project_SET
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitializedAuthenticatedProcess();
        }

        private void InitializedAuthenticatedProcess()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("Karachi_Complaint_System", "Admin", "SNo", "AdminName", true);
               
            }
        }
    }

 
}
