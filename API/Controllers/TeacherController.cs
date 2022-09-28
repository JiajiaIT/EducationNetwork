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
    /// 教师
    /// </summary>
    public class TeacherController : ApiController
    {
        B_Teacher b_Teacher = new B_Teacher();
        B_Subject b_Subject = new B_Subject();

        /// <summary>
        /// 教师列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Teacher/List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = from teacher in b_Teacher.List()
                           join subject in b_Subject.List() on teacher.SubjectID equals subject.ID
                           select new
                           {
                               ID = teacher.ID,
                               Name = teacher.Name,
                               Img = teacher.Img,
                               Describe = teacher.Describe,
                               Subject = subject.SubjectName
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
        /// 教师详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Teacher/FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = new
                {
                    ID = b_Teacher.FindByID(id).ID,
                    Name = b_Teacher.FindByID(id).Name,
                    Img = b_Teacher.FindByID(id).Img,
                    Describe = b_Teacher.FindByID(id).Describe,
                    Subject = b_Subject.FindByID(b_Teacher.FindByID(id).SubjectID).SubjectName
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
        /// 添加教师
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Teacher/Add")]
        public IHttpActionResult Add([FromBody]Teacher teacher)
        {
            try
            {
                b_Teacher.Add(teacher);
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
        /// 修改教师
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Teacher/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody]Teacher teacher)
        {
            try
            {
                b_Teacher.Update(id, teacher);
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
        /// 删除教师
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Teacher/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                b_Teacher.Delete(id);
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
