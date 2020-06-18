using Beam.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Data.Models
{
    public class EmployeeContext : DbContext
    {
        public virtual DbSet<Employee> tblEmployee { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
    }
}
