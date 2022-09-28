using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using IDAL;
using Factory;
using BLL;
using API.Models;


namespace API.Controllers
{
    /// <summary>
    /// 课程
    /// </summary>
    public class ClassScheduleController : ApiController
    {
        B_ClassSchedule b_ClassSchedule = new B_ClassSchedule();
        B_CourseClassification b_CourseClassification = new B_CourseClassification();

        /// <summary>
        /// 课程列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ClassSchedule/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = from classSchedule in b_ClassSchedule.List()
                           join courseClassification in b_CourseClassification.List() on classSchedule.CategoryID equals courseClassification.ID
                           select new
                           {
                               ID = classSchedule.ID,
                               Name = classSchedule.Name,
                               Img = classSchedule.Img,
                               Describe = classSchedule.Describe,
                               Category = courseClassification.CategoryName
                           };
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "成功",
                    Data = data.ToList()
                });
            }
            catch (Exception)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "失败"
                });
            }
        }
        /// <summary>
        /// 课程详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ClassSchedule/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = b_ClassSchedule.FindByID(id);
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "成功",
                    Data = new
                    {
                        ID = data.ID,
                        Name = data.Name,
                        Img = data.Img,
                        Describe = data.Describe,
                        Category = b_CourseClassification.FindByID(data.CategoryID).CategoryName
                    }
                });
            }
            catch (Exception)
            {
                return Json(new Result<object>
                {
                    Data = 404,
                    Message = "失败"
                });
            }
        }
        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="classSchedule">课程</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ClassSchedule/Add")]
        public IHttpActionResult Add([FromBody]ClassSchedule classSchedule)
        {
            try
            {
                b_ClassSchedule.Add(classSchedule);
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "添加成功"
                });
            }
            catch (Exception)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "添加失败"
                });
            }
        }
        /// <summary>
        /// 修改课程
        /// </summary>
        /// <param name="id">课程ID</param>
        /// <param name="classSchedule">课程</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ClassSchedule/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody]ClassSchedule classSchedule)
        {
            try
            {
                b_ClassSchedule.Update(id, classSchedule);
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "修改成功"
                });
            }
            catch (Exception)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "修改失败"
                });
            }
        }
        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="id">课程ID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ClassSchedule/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_ClassSchedule.Delete(id);
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "删除成功"
                });
            }
            catch (Exception)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "删除失败"
                });
            }
        }
    }
}
