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
    /// 资讯分类
    /// </summary>
    public class InfoCategoryController : ApiController
    {
        B_InfoCategory b_InfoCategory = new B_InfoCategory();

        /// <summary>
        /// 资讯分类列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/InfoCategory/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = from infoCategory in b_InfoCategory.List()
                           select new CourseClassification
                           {
                               ID = infoCategory.ID,
                               CategoryName = infoCategory.CategoryName
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
        /// 资讯分类详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/InfoCategory/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = new
                {
                    ID = b_InfoCategory.FindByID(id).ID,
                    CategoryName = b_InfoCategory.FindByID(id).CategoryName
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
        /// 添加资讯分类
        /// </summary>
        /// <param name="infoCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/InfoCategory/Add")]
        public IHttpActionResult Add([FromBody]InfoCategory infoCategory)
        {
            try
            {
                b_InfoCategory.Add(infoCategory);
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
        /// 修改资讯分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="infoCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/InfoCategory/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody]InfoCategory infoCategory)
        {
            try
            {
                b_InfoCategory.Update(id, infoCategory);
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
        /// 删除资讯分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/InfoCategory/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_InfoCategory.Delete(id);
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
