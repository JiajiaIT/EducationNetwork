using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Areas.Manage.Controllers
{
    public class MessageController : BaseController
    {
        // GET: Manage/Message
        public ActionResult List()
        {
            //获取留言列表
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/Message/List", "get");
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(result);
            ViewData["Message"] = data.Data;
            return View();
        }
        public ActionResult Delete(int id)
        {
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/Message/Delete/" + id, "post", null);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(result);
            if (data.Code == 200 && data.Message == "删除成功")
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult FindByID(int id)
        {
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/Message/FindByID/" + id, "get");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}