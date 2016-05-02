using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATA;

namespace Manager.Controllers
{
    public class BaseController : Controller
    {
        private softtehnicaEntities _Repository;
        protected softtehnicaEntities Repository
        {
            get {
                if(_Repository == null)
                {
                    _Repository = new softtehnicaEntities();
                }
                return _Repository;
            }
        }
    }
}