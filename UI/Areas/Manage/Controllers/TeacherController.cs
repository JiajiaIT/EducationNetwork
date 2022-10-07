using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Areas.Manage.Controllers
{
    public class TeacherController : BaseController
    {
        // GET: Manage/Teacher
        public ActionResult List()
        {
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/Teacher/List", "get");
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(result);
            ViewData["Data"] = data.Data;

            var res = HttpHelper.HttpGet(Tools.ServerPath + "api/Subject/List", "get");
            var category = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(res);
            ViewData["Category"] = category.Data;
            return View();
        }
        public ActionResult Delete(int id)
        {
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/Teacher/Delete/" + id, "post", null);
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
                if (file.ContentLength <= 1024 * 1024 * 20)
                {
                    ///后缀
                    if (exname == ".jpg" || exname == ".jpeg" || exname == ".png" || exname == ".bmp" || exname == ".gif")
                    {
                        //1、起名字
                        img = Tools.GetNewName(exname);
                        //2、保存在本地
                        file.SaveAs(Server.MapPath(Tools.TeacherImg + img));
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
        public ActionResult Add(string name,string img, string describe, int subjectID)
        {
            var teacher = new
            {
                Name=name,
                Img = img,
                Describe= describe,
                SubjectID = subjectID
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/Teacher/Add", "post", teacher);
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
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/Teacher/FindByID/" + id, "get");
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Update(int id,string name, string img, string describe, int subjectID)
        {
            var teacher = new
            {
                Name = name,
                Img = img,
                Describe = describe,
                SubjectID = subjectID
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/Teacher/Update/" + id, "post", teacher);
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