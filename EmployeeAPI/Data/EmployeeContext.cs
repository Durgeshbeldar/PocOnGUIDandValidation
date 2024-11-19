﻿using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Authors { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
    }
}