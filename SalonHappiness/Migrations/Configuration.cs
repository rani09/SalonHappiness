namespace SalonHappiness.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SalonHappiness.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SalonHappiness.Models.SalonDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SalonHappiness.Models.SalonDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.



            //if (!context.Roles.Any(r => r.Name == "Administrator"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "Administrator" };

            //    manager.Create(role);
            //}
            //if (!context.Users.Any(r => r.UserName == "Admin"))
            //{
            //    var store = new UserStore<User>(context);
            //    var manager = new UserManager<User>(store);
            //    var user = new User { UserName = "salon@happiness.dk", Email = "salon@happiness.dk", Fname = "Salon Happiness", EmailConfirmed = true, LockoutEnabled = true };

            //    manager.Create(user, "salonHappiness");
            //    manager.AddToRole(user.Id, "Administrator");
            //}
        }


    }
}
