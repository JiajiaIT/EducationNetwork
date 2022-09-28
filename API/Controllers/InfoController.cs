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
    /// 资讯
    /// </summary>
    public class InfoController : ApiController
    {
        B_Info b_Info = new B_Info();
        B_InfoCategory B_InfoCategory = new B_InfoCategory();

        /// <summary>
        /// 资讯列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Info/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = from info in b_Info.List()
                           join infocategory in B_InfoCategory.List() on info.CategoryID equals infocategory.ID
                           select new
                           {
                               ID = info.ID,
                               Title = info.Title,
                               Img = info.Img,
                               Content = info.Content,
                               CreateTime = info.CreateTime,
                               Category = infocategory.CategoryName
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
        /// 资讯详情
        /// </summary>
        /// <param name="id">资讯ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Info/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = b_Info.FindByID(id);
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "成功",
                    Data = new
                    {
                        ID = data.ID,
                        Title = data.Title,
                        Img = data.Img,
                        Content = data.Content,
                        CreateTime = data.CreateTime,
                        Category = B_InfoCategory.FindByID(data.CategoryID).CategoryName
                    }
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
        /// 添加资讯
        /// </summary>
        /// <param name="info">资讯</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Info/Add")]
        public IHttpActionResult Add([FromBody] Info info)
        {
            try
            {
                b_Info.Add(info);
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
        /// 资讯修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Info/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody] Info info)
        {
            try
            {
                b_Info.Update(id, info);
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
        /// 删除资讯
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Info/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_Info.Delete(id);
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
                    Message = "删除删除"
                });
            }
        }
    }
}
