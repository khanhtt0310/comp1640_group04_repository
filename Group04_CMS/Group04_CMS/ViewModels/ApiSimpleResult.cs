using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Group04_CMS.ViewModels
{
    public class ApiSimpleResult<T> where T: class 
    {
        public string StatusString { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}