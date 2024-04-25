
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ReactApp1.Server.Model
{
    public class ContextFile : DbContext
    {
        public ContextFile(DbContextOptions<ContextFile> options) : base(options)
        {
        }
        public DbSet<TenantDetails> TenantDetails { get; set; }
       
    }

}
