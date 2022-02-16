using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.context;
using WebApi2.model;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly dataContext _context;
        public LoginController(dataContext context)
        {
            _context = context;
        }
       // [HttpGet]
        //public async Task<ActionResult<IEnumerable<LoginModel>>> GetLogin()
        //{
         //   return await _context.Login.ToListAsync();
        //}
        [HttpPost]
        public async Task<ActionResult<RegisterModel>> PostLogin(LoginModel login)
        {
            // _context.Login.Add(login);
             if(!UserExist( login.email, login.password))
            {
                return new JsonResult("User Does Not Exist");
                
            }
            //await _context.SaveChangesAsync();
            // return CreatedAtAction("GetLogin", new { id = login.id }, "Login Successfully");
               return new JsonResult("Login Successfully");
        }
        private bool UserExist(string email, string password)
        {
            return _context.Register.Any(e => e.email == email && e.password == password);
        }
    }
}
