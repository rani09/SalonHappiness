using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace SalonHappiness.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public virtual ICollection<Booking> Bookings { get; set; }

        [Required(ErrorMessage = "Indsat dit fulde navn")]
        [Display(Name = "Brugernavn")]
        public string Fname { get; set; }

        [Display(Name = "Jeg accepterer betingelser")]
        public bool Accepted { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }

    public class SalonDbContext : IdentityDbContext<User>
    {
        public SalonDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SalonDbContext Create()
        {
            return new SalonDbContext();
        }

        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<AboutUsFile> AboutUsFiles { get; set; }
        public virtual DbSet<Advance> Advances { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<FrontPage> FrontPages { get; set; }
        public virtual DbSet<FrontPageFile> FrontPageFiles { get; set; }
        public virtual DbSet<Hairstyle> Hairstyles { get; set; }
        public virtual DbSet<HairstyleFile> HairstyleFiles { get; set; }
        public virtual DbSet<Opentime> Opentimes { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamFile> TeamFiles { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<OpenOrClosse> OpenOrClosses { get; set; }
        public virtual DbSet<ServiceBooking> ServiceBookings { get; set; }
        public virtual DbSet<Samtykke> Samtykkes { get; set; }
    }
}