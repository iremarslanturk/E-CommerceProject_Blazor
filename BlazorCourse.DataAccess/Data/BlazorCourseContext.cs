using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCourse.DataAccess.Data
{
    public class BlazorCourseContext : IdentityDbContext
    {
        public BlazorCourseContext(DbContextOptions<BlazorCourseContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseOrderInfo> CourseOrderInfos {get; set;}
    }
}
