using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;//安全授权

namespace UI.Areas.Manage.Controllers
{
    /// <summary>
    /// 父控制器：身份授权验证
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {

        }
    }
}