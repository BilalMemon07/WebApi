using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi2.context;
using WebApi2.model;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly dataContext _context;
        public RegisterController(dataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterModel>>> GetRegister()
        {
        return await _context.Register.ToListAsync();
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterModel>> GetRegister(int id)
        {
            var reg = await _context.Register.FindAsync(id);

            if (reg == null)
            {

                return NotFound();
            }

            return reg;
        }
        [HttpPost]

        public async Task<ActionResult<RegisterModel>> PostRegister(RegisterModel register)
        {
             _context.Register.Add(register);
            string password = register.password;
            string conformPassword = register.conformPassword;
            if (CheckingEmail(register.email))
            {
                //throw new Exception("This Email is Already Exist");
                //return new JsonResult("This Email is Already Exist");
               return StatusCode((int)HttpStatusCode.OK, Json("Sucess !!!"));
            }
            if (password != conformPassword)
            {
                // throw new Exception("Please Writre same password");
                return new JsonResult("Please Write same password");
            }
            await _context.SaveChangesAsync();
            return new JsonResult("Save Successfully");
            //CreatedAtAction("GetRegister", new { id = register.id }, "Save Successfully");
        }
        private bool CheckingEmail(string email)
        {
            return _context.Register.Any(e => e.email == email);
        }
    }
}
