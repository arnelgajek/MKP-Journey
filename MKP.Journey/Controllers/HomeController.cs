using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MKP.Journey.Controllers
{
    public class HomeController : Controller
    {
        //ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            //// Log4Net:
            //try
            //{
            //    object m = null;
            //    string s = m.ToString();
            //}

            //catch (Exception ex)
            //{
            //    // Här ställer du vilken typ av fel ska loggas, tex Error, Information, Warning m.m. 

            //    // Log4Net:
            //    _log.Error("An exception has occured while trying to convert object m to string.", ex);
            //}
            return View();
        }
    }
}
