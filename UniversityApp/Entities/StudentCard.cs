using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Entities;

class StudentCard
{
    public int Id { get; set; }

    public string CardNumber { get; set; }

    public DateTime IssueDate { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}
