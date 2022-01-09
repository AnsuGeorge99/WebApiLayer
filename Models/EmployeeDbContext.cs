using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiLayer.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext() : base("EmployeeCon") { }
        public DbSet<Employee> EmployeeT { get; set; }
    }
}