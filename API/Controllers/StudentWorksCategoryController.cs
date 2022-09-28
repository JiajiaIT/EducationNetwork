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
    /// 学生作品分类
    /// </summary>
    public class StudentWorksCategoryController : ApiController
    {
        B_StudentWorksCategory b_StudentWorksCategory = new B_StudentWorksCategory();

        /// <summary>
        /// 学生作品分类列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/StudentWorksCategory/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = from studentworkCategory in b_StudentWorksCategory.List()
                           select new StudentWorksCategory
                           {
                               ID = studentworkCategory.ID,
                               CategoryName = studentworkCategory.CategoryName
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
        /// 学生作品分类详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/StudentWorksCategory/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = new
                {
                    ID = b_StudentWorksCategory.FindByID(id).ID,
                    CategoryName = b_StudentWorksCategory.FindByID(id).CategoryName
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
        /// 添加学生作品分类
        /// </summary>
        /// <param name="studentWorksCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/StudentWorksCategory/Add")]
        public IHttpActionResult Add([FromBody]StudentWorksCategory studentWorksCategory)
        {
            try
            {
                b_StudentWorksCategory.Add(studentWorksCategory);
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
        /// 修改学生作品分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/StudentWorksCategory/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody]StudentWorksCategory category)
        {
            try
            {
                b_StudentWorksCategory.Update(id, category);
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
        /// 删除学生作品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/StudentWorksCategory/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_StudentWorksCategory.Delete(id);
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
