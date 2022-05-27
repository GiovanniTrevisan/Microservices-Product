using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebFront.Models;

namespace WebFront.Data
{
    public class WebFrontContext : DbContext
    {
        public WebFrontContext (DbContextOptions<WebFrontContext> options)
            : base(options)
        {
        }

        public DbSet<WebFront.Models.CategoryViewModel>? CategoryViewModel { get; set; }
    }
}
