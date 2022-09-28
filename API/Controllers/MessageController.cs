using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using IDAL;
using BLL;
using Factory;
using API.Models;

namespace API.Controllers
{
    /// <summary>
    /// 留言
    /// </summary>
    public class MessageController : ApiController
    {
        B_Message b_Message = new B_Message();

        /// <summary>
        /// 留言列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Message/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = b_Message.List();
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
        /// 留言详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Message/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = b_Message.FindByID(id);
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
        /// 添加留言
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Message/Add")]
        public IHttpActionResult Add([FromBody]Message message)
        {
            try
            {
                b_Message.Add(message);
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
        /// 修改留言
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Message/Update/{id}")]
        public IHttpActionResult Update(int id,[FromBody]Message message)
        {
            try
            {
                b_Message.Update(id, message);
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
        /// 删除留言
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Message/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_Message.Delete(id);
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
