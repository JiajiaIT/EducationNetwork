using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Areas.Manage.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Manage/Admin
        public ActionResult Index()
        {
            ViewData["name"] = User.Identity.Name;//当前登录用户名称
            return View();
        }
        public ActionResult Main()
        {
            //获取留言Count
            var messagedata = HttpHelper.HttpGet(Tools.ServerPath + "api/Message/List", "get");
            var messageresult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(messagedata);
            ViewData["Message"] = messageresult.Data;

            //获取资讯Count
            var infodata = HttpHelper.HttpGet(Tools.ServerPath + "api/Info/List", "get");
            var inforesult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(infodata);
            ViewData["Info"] = inforesult.Data;

            //获取管理员Count
            var admincount = HttpHelper.HttpGet(Tools.ServerPath + "api/Admins/List", "get");
            var adminresult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(admincount);
            ViewData["Admin"] = adminresult.Data;
            return View();
        }
        public ActionResult List()
        {
            ViewData["name"] = User.Identity.Name;//当前登录用户名称
            //获取管理员Count
            var admincount = HttpHelper.HttpGet(Tools.ServerPath + "api/Admins/List", "get");
            var adminresult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(admincount);
            ViewData["Admin"] = adminresult.Data;
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string username, string nickName, string password, string phone, string e_mail)
        {
            var admin = new
            {
                UserName = username,
                NickName = nickName,
                Password = password,
                Phone = phone,
                E_mail = e_mail
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/Admins/Add", "post", admin);
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
        public ActionResult Delete(int id)
        {
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/Admins/Delete/" + id, "post", null);
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
        [HttpGet]
        public ActionResult EditPassword()
        {
            var username = User.Identity.Name;//当前登录用户名称
            var admin = new
            {
                UserName = username
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/Admins/ViewPassword/", "post",admin);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(result);
            if (data.Code == 200 && data.Message == "成功")
            {
                ViewData["oldPassword"] = data.Data;
            }
            return View();
        }
        [HttpPost]
        public ActionResult EditPassword(string password)
        {
            var username = User.Identity.Name;//当前登录用户名称
            var admin = new
            {
                UserName = username,
                Password = password
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/Admins/EditPassword/", "post", admin);
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