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
    DbSet<Student> Students { get; set; } = null!;
    DbSet<Course> Courses { get; set; } = null!;
    DbSet<StudentCard> StudentCards { get; set; } = null!;
    DbSet<Teacher> Teachers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "SERVER=localhost;DataBase=OnlineStoreDB;Trusted_Connection=True;TRUSTSERVERCERTIFICATE=true"
            );

        base.OnConfiguring(optionsBuilder);
    }
}
