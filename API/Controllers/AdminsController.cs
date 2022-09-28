using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using IDAL;
using BLL;
using API.Models;

namespace API.Controllers
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class AdminsController : ApiController
    {
        B_Admins b_Admins = new B_Admins();

        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Admins/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = from admin in b_Admins.List()
                           select new Admins
                           {
                               ID = admin.ID,
                               UserName = admin.UserName,
                               PassWord = "******",
                               NickName = admin.NickName,
                               Phone = admin.Phone,
                               E_mail = admin.E_mail
                           };
                return Json(new Result<List<Admins>>
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
        /// 添加管理员
        /// </summary>
        /// <param name="admin">管理员</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Admins/Add")]
        public IHttpActionResult Add([FromBody]Admins admin)
        {
            try
            {
                b_Admins.Add(admin);
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
        /// 删除管理员
        /// </summary>
        /// <param name="id">管理员ID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Admins/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_Admins.Delete(id);
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
        /// 管理员详情
        /// </summary>
        /// <param name="id">管理员ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Admins/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = b_Admins.FindByID(id);
                return Json(new Result<Admins>
                {
                    Code = 200,
                    Message = "成功",
                    Data = new Admins
                    {
                        ID = data.ID,
                        UserName = data.UserName,
                        PassWord = "******",
                        NickName = data.NickName,
                        Phone = data.Phone,
                        E_mail = data.E_mail
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
        /// 管理员修改
        /// </summary>
        /// <param name="id">管理员ID</param>
        /// <param name="admin">管理员</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Admins/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody]Admins admin)
        {
            try
            {
                b_Admins.Update(id, admin);
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
        /// 管理员登录
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Admins/Login")]
        public IHttpActionResult Login([FromBody]Admins admins)
        {
            try
            {
                var count = b_Admins.Login(admins.UserName, admins.PassWord);
                if (count > 0)
                {
                    return Json(new Result<object>
                    {
                        Code = 200,
                        Message = "登录成功"
                    });
                }
                else
                {
                    return Json(new Result<object>
                    {
                        Code = 404,
                        Message = "登录失败"
                    });
                }
            }
            catch (Exception)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "登录失败"
                });
            }
        }
        /// <summary>
        /// 根据Cookie修改管理员密码
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Admins/EditPassword")]
        public IHttpActionResult EditPassword([FromBody]Admins admins)
        {
            try
            {
                b_Admins.EditPassword(admins.UserName, admins.PassWord);
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
        /// 根据Cookie查看管理员密码
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Admins/ViewPassword")]
        public IHttpActionResult ViewPassword([FromBody]Admins admins)
        {
            try
            {
                var data = b_Admins.ViewPassword(admins.UserName);
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
    }
}
