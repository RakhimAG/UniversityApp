using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Entities;

class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public List<Course> Courses { get; set; } = new();

    public override string ToString() =>
        $"Id : {Id}\nName : {Name}\nAge : {Age}\nEmail : {Email}\n";
}
