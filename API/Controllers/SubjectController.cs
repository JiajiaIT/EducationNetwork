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
    /// 教师科目
    /// </summary>
    public class SubjectController : ApiController
    {
        B_Subject b_Subject = new B_Subject();

        /// <summary>
        /// 教师科目列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Subject/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = from subject in b_Subject.List()
                           select new
                           {
                               ID = subject.ID,
                               SubjectName = subject.SubjectName
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
        /// 教师科目详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Subject/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = new
                {
                    ID = b_Subject.FindByID(id).ID,
                    SubjectName = b_Subject.FindByID(id).SubjectName
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
        /// 添加教师科目
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Subject/Add")]
        public IHttpActionResult Add([FromBody]Subject subject)
        {
            try
            {
                b_Subject.Add(subject);
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
        /// 修改教师科目
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Subject/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody]Subject subject)
        {
            try
            {
                b_Subject.Update(id, subject);
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
        /// 删除教师科目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Subject/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_Subject.Delete(id);
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