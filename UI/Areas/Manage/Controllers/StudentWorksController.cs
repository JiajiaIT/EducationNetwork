using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Areas.Manage.Controllers
{
    public class StudentWorksController : BaseController
    {
        // GET: Manage/StudentWorks
        public ActionResult List()
        {
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/StudentWorks/List", "get");
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(result);
            ViewData["Data"] = data.Data;

            var res = HttpHelper.HttpGet(Tools.ServerPath + "api/StudentWorksCategory/List", "get");
            var category = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(res);
            ViewData["Category"] = category.Data;
            return View();
        }
        public ActionResult Delete(int id)
        {
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/StudentWorks/Delete/" + id, "post", null);
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
        public ActionResult SaveImg()
        {
            string img;
            //传统获取前端提交过来的数据分三种获取方式
            //Request.QueryString[0]  //获取从地址栏提交的数据
            //Request.Form[0]         //获取从表单提交的数据
            //Request.Files[0]        //获取从表单提交的文件

            //如果有图片，就处理图片
            if (Request.Files[0].ContentLength == 0)
            {
                img = "default.jpg";
                return Json(img, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //获取上传文件
                var file = Request.Files[0];
                //获取上传文件的扩展名
                var exname = Path.GetExtension(file.FileName).ToLower();

                //0、验证一下上传文件（大小）
                if (file.ContentLength <= 1024 * 1024 * 2)
                {
                    ///后缀
                    if (exname == ".jpg" || exname == ".jpeg" || exname == ".png" || exname == ".bmp" || exname == ".gif")
                    {
                        //1、起名字
                        img = Tools.GetNewName(exname);
                        //2、保存在本地
                        file.SaveAs(Server.MapPath(Tools.StudentWorksImg + img));
                        return Json(img, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        img = "default.jpg";
                        return Json(img, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    img = "default.jpg";
                    return Json(img, JsonRequestBehavior.AllowGet);
                }
            }

        }
        [HttpPost]
        public ActionResult Add(string img, int categoryid)
        {
            var studentworks = new
            {
                Img = img,
                CategoryID = categoryid
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/StudentWorks/Add", "post", studentworks);
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
            //获取学生作品详情
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/StudentWorks/FindByID/" + id, "get");
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Update(int id, string img, int categoryid)
        {
            var studentworks = new
            {
                Img = img,
                CategoryID = categoryid
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/StudentWorks/Update/" + id, "post", studentworks);
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