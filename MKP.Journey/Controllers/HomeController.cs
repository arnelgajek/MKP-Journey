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
        // readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult Index()
        {
            //// Something that will throw an error for test:
            //try
            //{
            //    object m = null;
            //    string s = m.ToString();
            //}
            //catch (Exception ex)
            //{
            //    _log.Error("AJJABAJJA, HÄR GICK NÅGOT FEL!!", ex);
            //}

            return View();
        }
    }
}
