using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using System.Web.Security;

namespace UI.Areas.Manage.Controllers
{
    public class AccountController : Controller
    {
        // GET: Manage/Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var admin = new
            {
                UserName = username,
                Password = password
            };
            var data = HttpHelper.HttpPost(Tools.ServerPath + "api/Admins/Login", "Post", admin);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(data);
            if (result.Code == 200 && result.Message == "登录成功")
            {
                //登录成功后，将当前用户信息写入Cookie
                FormsAuthentication.SetAuthCookie(username, false);
                //跳转到Admin控制器的Index，即后台首页
                return Json(new Result<Object>
                {
                    Code = 200,
                    Message = "登录成功"
                });
            }
            else
            {
                //登录失败
                return Json(new Result<Object>
                {
                    Code = 404,
                    Message = "登录失败"
                });
            }
        }
        //登出
        public ActionResult Logout()
        {
            //删除身份验证票证
            FormsAuthentication.SignOut();
            //返回/Account/Longin Action
            return RedirectToAction("Login");
        }
    }
}