using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.model
{
    public class RegisterModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password {get;set;}
        public string conformPassword { get; set; }
    }
}
