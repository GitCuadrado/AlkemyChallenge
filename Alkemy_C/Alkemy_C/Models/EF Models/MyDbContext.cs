using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Alkemy_C.Models.EF_Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("AlkemyDB")
        {

        }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Alumn> Alumn { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
    }
}