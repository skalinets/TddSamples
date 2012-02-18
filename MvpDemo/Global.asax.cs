using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using WebFormsMvp.Binder;
using WebFormsMvp.Unity;

namespace MvpDemo
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ICalculator, Calculator>();

            PresenterBinder.Factory = new UnityPresenterFactory(unityContainer);
        }
    }
}
