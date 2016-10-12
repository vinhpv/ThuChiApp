using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ThuChi.API.Models
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string firstName { get; set; }

        public virtual List<todoItem> todoItems { get; set; }

        public virtual List<Thuchi> Thuchis { get; set; }
    }

    public class todoItem
    {
        [Key]
        public int id { get; set; }
        public string task { get; set; }
        public bool completed { get; set; }
    }

    public class Lydo
    {
        [Key]
        public int Lydo_id { get; set; }
        public string lydo { get; set; }
        public string Ghichu { get; set; }
    }

    public class Nguoithuchi
    {
        [Key]
        public int nguoithuchi_id { get; set; }
        public string hovaten { get; set; }
        public string ghichu { get; set; }
    }

    public class Thuchi
    {
        [Key]
        public int thuchi_id { get; set; }
        public int nguoithuchi_id { get; set; }

        [ForeignKey("nguoithuchi_id")]
        public Nguoithuchi Nguoithuchi { get; set; }
        public DateTime? ngaythuchi { get; set; }
        public bool? kieuthu { get; set; }
        public double? tien { get; set; }
        public int? lydo_id { get; set; }
        [ForeignKey("lydo_id")]
        public Lydo Lydo { get; set; }
        public string ghichu { get; set; }

        public string user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
    }

    public class DBContext : IdentityDbContext<User>
    {
        public DBContext() : base("ThuChiDB")
        {

        }
        //Override default table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static DBContext Create()
        {
            return new DBContext();
        }

        public DbSet<todoItem> todos { get; set; }
        public DbSet<Lydo> Lydoes { get; set; }
        public DbSet<Nguoithuchi> Nguoithuchis { get; set; }
        public DbSet<Thuchi> Thuchis { get; set; }


    }

    //This function will ensure the database is created and seeded with any default data.
    public class DBInitializer : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            //Create an seed data you wish in the database.
        }
    }
}

