using Backend.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL
{
    public class UdemyDbContext: IdentityDbContext<CustomUser>
    {
        public UdemyDbContext(DbContextOptions<UdemyDbContext> options):base(options) 
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseCategory> CategoriesCategories { get; set; }
        public DbSet<Supporter> Supporters { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
    }
}
