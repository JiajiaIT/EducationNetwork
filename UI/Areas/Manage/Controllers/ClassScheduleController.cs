using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Areas.Manage.Controllers
{
    public class ClassScheduleController : BaseController
    {
        // GET: Manage/ClassSchedule
        public ActionResult List()
        {
            //获取课程列表
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/ClassSchedule/List", "get");
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(result);
            ViewData["ClassSchedule"] = data.Data;

            //获取课程分类列表
            var categoryresult = HttpHelper.HttpGet(Tools.ServerPath + "api/CourseClassification/List", "get");
            var categorydata = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<object>>(categoryresult);
            ViewData["Category"] = categorydata.Data;
            return View();
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
                        file.SaveAs(Server.MapPath(Tools.ClassScheduleImg + img));
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
        public ActionResult Add(string name, string img, string describe, int categoryid)
        {
            var classSchedule = new
            {
                Name = name,
                Img = img,
                Describe = describe,
                CategoryID = categoryid
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/ClassSchedule/Add", "post", classSchedule);
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
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/ClassSchedule/Delete/" + id, "post", null);
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
        public ActionResult Update(int id)
        {
            //获取课程详情
            var result = HttpHelper.HttpGet(Tools.ServerPath + "api/ClassSchedule/FindByID/" + id, "get");
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Update(int id, string name, string img, string describe, int categoryid)
        {
            var classSchedule = new
            {
                Name = name,
                Img = img,
                Describe = describe,
                CategoryID = categoryid
            };
            var result = HttpHelper.HttpPost(Tools.ServerPath + "api/ClassSchedule/Update/"+id, "post", classSchedule);
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