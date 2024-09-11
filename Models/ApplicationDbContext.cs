using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//Define tables for my project - jobs/cetgories/js/CV status etc
//Seed data into DB - roles for each user (admin/JS) - user auth

namespace CrystalClearRecruitment_FinalProject.Models
{
    //With ref to the diff type of users 
    public class ApplicationDbContext : IdentityDbContext<AppUsers>
    {
        internal object cvStatus;
        internal IEnumerable<object> jobJobSeekersCVStatus;

        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        //Properites of my DB to create tables 
        public DbSet<Job> job { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<JobSeekers> jobSeekers { get; set; }
        public DbSet<CVStatus> cVStatuscs { get; set; }
        public DbSet<JobJobSeekersCVStatus> jobJobSeekersCVStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //this.SeedUsers(builder);

            //Admin =1 / JS = 2
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "admin",
                Id = "1",
                ConcurrencyStamp = "1"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "user",
                Id = "2",
                ConcurrencyStamp = "2"
            });



            //Create a seeded Admin
            var appUser = new AppUsers
            {
                Id = "1",
                Email = "admin@abc.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                UserName = "admin@abc.com",


                NormalizedUserName = "admin@abc.com"
            };

            //set admin password
            PasswordHasher<AppUsers> ph = new PasswordHasher<AppUsers>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Abc.123456");

            //seed admin
            builder.Entity<AppUsers>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            });

//Removed for live
//builder.Entity<Category>().HasData(new Category
// {
//    CategoryId = 1,
//     Name = "IT",
//},

//   new Category
//   {
//     CategoryId = 2,
//     Name = "testcat",
// }
// );


            builder.Entity<CVStatus>().HasData(
                new CVStatus
                {
                    Id = 1,
                    Name = "Pending"
                },
                new CVStatus
                {
                    Id = 2,
                    Name = "Approved"
                },
                new CVStatus
                {
                    Id = 3,
                    Name = "Decline"
                }

                );

        }

    }
}
