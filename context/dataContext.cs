using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.model;

namespace WebApi2.context
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext>options):base (options)
        {

        }
        public DbSet<studentModel> Students { get; set; }
    }
}
