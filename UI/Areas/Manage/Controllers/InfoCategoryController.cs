using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Areas.Manage.Controllers
{
    public class InfoCategoryController : Controller
    {
        // GET: Manage/InfoCategory
        public ActionResult List()
        {
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/InfoCategory/List", "get");
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(result);
            ViewData["InfoCategory"] = data.Data;
            return View();
        }
        public ActionResult Delete(int id)
        {
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/InfoCategory/Delete/" + id, "post", null);
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
        [HttpPost]
        public ActionResult Add(string categoryname)
        {
            var infoCategory = new
            {
                CategoryName = categoryname
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/InfoCategory/Add", "post", infoCategory);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(result);
            if (data.Code == 200 && data.Message == "添加成功")
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            //获取课程分类详情
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/InfoCategory/FindByID/" + id, "get");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(int id, string categoryName)
        {
            var infoCategory = new
            {
                ID = id,
                CategoryName = categoryName
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/InfoCategory/Update/" + id, "post", infoCategory);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(result);
            if (data.Code == 200 && data.Message == "修改成功")
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
    }
}