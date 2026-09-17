using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;


namespace UniversityApp.Contexts;

class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<StudentCard> StudentCards { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "SERVER=localhost;DataBase=UniversityDbPrac;Trusted_Connection=True;TRUSTSERVERCERTIFICATE=true"
            );

        base.OnConfiguring(optionsBuilder);
    }
}
