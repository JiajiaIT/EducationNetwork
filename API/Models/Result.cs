using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Result<T>
    {
        public int Code { get; set; } = 200;
        public string Message { get; set; } = "成功";
        public T Data { get; set; }
    }
}