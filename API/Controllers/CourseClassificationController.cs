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
    /// 课程分类
    /// </summary>
    public class CourseClassificationController : ApiController
    {
        B_CourseClassification b_CourseClassification = new B_CourseClassification();
        /// <summary>
        /// 课程列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CourseClassification/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = from courseClassification in b_CourseClassification.List()
                           select new CourseClassification
                           {
                               ID = courseClassification.ID,
                               CategoryName = courseClassification.CategoryName
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
        /// 分类详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CourseClassification/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = new CourseClassification
                {
                    ID = b_CourseClassification.FindByID(id).ID,
                    CategoryName = b_CourseClassification.FindByID(id).CategoryName
                };
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "成功",
                    Data = data
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
        /// 添加课程分类
        /// </summary>
        /// <param name="courseClassification"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/CourseClassification/Add")]
        public IHttpActionResult Add([FromBody]CourseClassification courseClassification)
        {
            try
            {
                b_CourseClassification.Add(courseClassification);
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
        /// 删除课程分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/CourseClassification/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_CourseClassification.Delete(id);
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
        /// <summary>
        /// 修改课程分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseClassification"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/CourseClassification/Update/{id}")]
        public IHttpActionResult Update(int id, CourseClassification courseClassification)
        {
            try
            {
                b_CourseClassification.Update(id, courseClassification);
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
    }
}
