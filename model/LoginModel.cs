using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.model
{
    public class LoginModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        
    }
}
