using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Entities;

class Course
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

}
