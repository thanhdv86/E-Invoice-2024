using System;
using System.Web.Routing;

namespace cskh.huewaco.vn
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            Application["OnlineVisitors"] = 0;
            RegisterRoutes(RouteTable.Routes);
        }
        static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapPageRoute("TinTuc", "TinTuc/{ID}/{TitleUrl}", "~/TinTuc.aspx");

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            Application.Lock();
            Application["OnlineVisitors"] = (int)Application["OnlineVisitors"] + 1;
            Application.UnLock();

            try
            {
                using (var co = new CounterObject())
                {
                    co.Value = co.GetCounter() + 1;
                    co.Update();
                }
            }
            catch
            {
                
            }
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            //OnlineActiveUsers.OnlineUsersInstance.OnlineUsers.UpdateForUserLeave();
            Application.Lock();
            Application["OnlineVisitors"] = (int)Application["OnlineVisitors"] - 1;
            Application.UnLock();
        }
    }
}