using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class TableContext:DbContext
    {
        public TableContext():base("CourseWorkConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Lesson> Lessons { get; set; }
        //public DbSet<Group> Groups { get; set; }
       // public DbSet<Department> Departments { get; set; }
       // public DbSet<Auditory> Auditories { get; set; }
        //public DbSet<Subject> Subjects { get; set; }
        public DbSet<Shedule> Shedules { get; set; }
    }
}
