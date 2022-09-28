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
    /// 学生作品
    /// </summary>
    public class StudentWorksController : ApiController
    {
        B_StudentWorks b_StudentWorks = new B_StudentWorks();
        B_StudentWorksCategory b_StudentWorksCategory = new B_StudentWorksCategory();

        /// <summary>
        /// 学生作品列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/StudentWorks/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = from studentwork in b_StudentWorks.List()
                           join studentworkcategory in b_StudentWorksCategory.List() on studentwork.CategoryID equals studentworkcategory.ID
                           select new
                           {
                               ID = studentwork.ID,
                               Img = studentwork.Img,
                               Category = studentworkcategory.CategoryName
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
        /// 学生作品详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/StudentWorks/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = new
                {
                    ID = b_StudentWorks.FindByID(id).ID,
                    Img = b_StudentWorks.FindByID(id).Img,
                    Category = b_StudentWorksCategory.FindByID(b_StudentWorks.FindByID(id).CategoryID).CategoryName
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
        /// 添加学生作品
        /// </summary>
        /// <param name="studentWorks"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/StudentWorks/Add")]
        public IHttpActionResult Add([FromBody]StudentWorks studentWorks)
        {
            try
            {
                b_StudentWorks.Add(studentWorks);
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
        /// 修改学生作品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentWorks"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/StudentWorks/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody]StudentWorks studentWorks)
        {
            try
            {
                b_StudentWorks.Update(id, studentWorks);
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
        /// 删除学生作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/StudentWorks/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_StudentWorks.Delete(id);
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
