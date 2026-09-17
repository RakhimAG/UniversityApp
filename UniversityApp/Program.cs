using UniversityApp.Entities;
using UniversityApp.Contexts;
using Microsoft.EntityFrameworkCore;

// 1 and 2

#region Adding rows to tables
//var newStudents = new List<Student>
//{
//    new Student
//    {
//        Name = "Ali Mammadov",
//        Age = 20,
//        Email = "ali.mammadov@example.com"
//    },
//    new Student
//    {
//        Name = "Leyla Hasanli",
//        Age = 21,
//        Email = "leyla.hasanli@example.com"
//    },
//    new Student
//    {
//        Name = "Murad Aliyev",
//        Age = 19,
//        Email = "murad.aliyev@example.com"
//    },
//    new Student
//    {
//        Name = "Aysel Karimova",
//        Age = 22,
//        Email = "aysel.karimova@example.com"
//    },
//    new Student
//    {
//        Name = "Tural Huseynov",
//        Age = 20,
//        Email = "tural.huseynov@example.com"
//    }
//};

//var teachers = new List<Teacher>
//{
//    new Teacher
//    {
//        Name = "Kamran Aliyev",
//        Email = "kamran.aliyev@example.com"
//    },
//    new Teacher
//    {
//        Name = "Nigar Mammadova",
//        Email = "nigar.mammadova@example.com"
//    },
//    new Teacher
//    {
//        Name = "Rashad Hasanov",
//        Email = "rashad.hasanov@example.com"
//    }
//};

//var courses = new List<Course>
//{
//    new Course
//    {
//        Name = "C# Programming",
//        Description = "Introduction to C# and object-oriented programming.",
//        TeacherId = 1
//    },
//    new Course
//    {
//        Name = "Database Fundamentals",
//        Description = "Learn SQL, relational databases, and database design.",
//        TeacherId = 2
//    },
//    new Course
//    {
//        Name = "Web Development",
//        Description = "Learn the fundamentals of building web applications.",
//        TeacherId = 3
//    },
//    new Course
//    {
//        Name = "Object-Oriented Programming",
//        Description = "Study classes, inheritance, interfaces, and polymorphism.",
//        TeacherId = 1
//    },
//    new Course
//    {
//        Name = "Entity Framework Core",
//        Description = "Learn how to work with databases using EF Core.",
//        TeacherId = 2
//    }
//};

//using var dbcontext = new AppDbContext();

//dbcontext.Teachers.AddRange(teachers);
//dbcontext.Courses.AddRange(courses);
//dbcontext.Students.AddRange(newStudents);
//await dbcontext.SaveChangesAsync();
#endregion

#region Applying students to courses
//using var dbcontext = new AppDbContext();

//var student1 = await dbcontext.Students
//                            .FindAsync(1);
//student1!.Courses.Add(await dbcontext.Courses.FindAsync(1));
//student1.Courses.Add(await dbcontext.Courses.FindAsync(3));

//var student2 = await dbcontext.Students
//                            .FindAsync(2);
//student2!.Courses.Add(await dbcontext.Courses.FindAsync(4));
//student2.Courses.Add(await dbcontext.Courses.FindAsync(2));

//var student3 = await dbcontext.Students
//                            .FindAsync(3);
//student3!.Courses.Add(await dbcontext.Courses.FindAsync(1));
//student3.Courses.Add(await dbcontext.Courses.FindAsync(5));

//var student4 = await dbcontext.Students
//                            .FindAsync(4);
//student4!.Courses.Add(await dbcontext.Courses.FindAsync(3));
//student4.Courses.Add(await dbcontext.Courses.FindAsync(4));

//var student5 = await dbcontext.Students
//                            .FindAsync(5);
//student5!.Courses.Add(await dbcontext.Courses.FindAsync(2));
//student5.Courses.Add(await dbcontext.Courses.FindAsync(3));
//student5.Courses.Add(await dbcontext.Courses.FindAsync(4));

//await dbcontext.SaveChangesAsync();
#endregion

#region Giving students their cards
//using var context = new AppDbContext();

//var studentCards = new List<StudentCard>
//{
//    new StudentCard
//    {
//        IssueDate = DateTime.Now,
//        CardNumber= "00133124",
//        StudentId = 1
//    },
//    new StudentCard
//    {
//        IssueDate = DateTime.Now,
//        CardNumber= "00133999",
//        StudentId = 2
//    },
//        new StudentCard
//    {
//        IssueDate = DateTime.Now,
//        CardNumber= "00525405",
//        StudentId = 3
//    },
//    new StudentCard
//    {
//        IssueDate = DateTime.Now,
//        CardNumber= "00423566",
//        StudentId = 4
//    },
//        new StudentCard
//    {
//        IssueDate = DateTime.Now,
//        CardNumber= "00133441",
//        StudentId = 5
//    },
//};

//context.StudentCards.AddRange(studentCards);
//await context.SaveChangesAsync();
#endregion

// 3.1
void PrintAllStudents()
{
    using var context = new AppDbContext();

    var students = context.Students.ToList();

    if (students.Any())
        foreach (var student in students)
            Console.WriteLine(student);
    else
        Console.WriteLine("There is no students in current Database!");
}


// 3.2
void PrintStudentsWithCard()
{
    using var context = new AppDbContext();

    var studentsWithCards = context.StudentCards
                                    .Include(sc => sc.Student)
                                    .ToList();

    foreach (var studentCard in studentsWithCards)
         Console.WriteLine($"{studentCard.Student.Name} -- Card: {studentCard.CardNumber ?? "No student card"}");
}

// 3.3
void PrintCursesWithTeacher()
{
    using var context = new AppDbContext();

    var courses = context.Courses
                        .Include(c => c.Teacher)
                        .ToList();

    foreach (var course in courses)
        Console.WriteLine($"{course.Name} -- Teacher: {course.Teacher.Name}");
}

// 3.4
void PrintAllStudentCourses()
{
    using var context = new AppDbContext();

    var students = context.Students
                            .Include(s => s.Courses)
                            .ToList();

    foreach (var student in students)
    {
        Console.WriteLine($"{student.Name}:");

        foreach (var course in student.Courses)
            Console.WriteLine($"\t{course.Name}");
    }
}

// 4

#region Adding new course
{
    //var newCourse = new Course
    //{
    //    TeacherId = 3,
    //    Name = "ASP.NET Core",
    //    Description = "Web development with ASP.NET Core",
    //};

    //using var context = new AppDbContext();
    //context.Courses.Add(newCourse);
    //await context.SaveChangesAsync();
}
#endregion

// 5

#region Checking Entity state in Change Tracker
{
    //using var context = new AppDbContext();

    //var student = new Student
    //{
    //    Name = "Test Student",
    //    Age = 20,
    //    Email = "test@test.com"
    //};
    //Console.WriteLine(context.Entry(student));

    //context.Students.Add(student);
    //Console.WriteLine(context.Entry(student));

    //await context.SaveChangesAsync();
    //Console.WriteLine(context.Entry(student));
}
#endregion

// 6

// Sequence of State : Unchanged -> Modified -> Unchanged
#region Checking Modified state
{
    //using var context = new AppDbContext();

    //var studentModify = await context.Students.FindAsync(1);
    //Console.WriteLine(context.Entry(studentModify));

    //studentModify.Name = "new name";
    //Console.WriteLine(context.Entry(studentModify));

    //await context.SaveChangesAsync();
    //Console.WriteLine(context.Entry(studentModify));
}
#endregion

// 7

#region Deleting student
{
    //using var context = new AppDbContext();

    //var studentToDelete = context.Students
    //                            .Where(s => s.Name == "Test Student")
    //                            .FirstOrDefault();
    //Console.WriteLine(context.Entry(studentToDelete));

    //context.Students.Remove(studentToDelete);
    //Console.WriteLine(context.Entry(studentToDelete));

    //await context.SaveChangesAsync();
    //Console.WriteLine(context.Entry(studentToDelete));
}
#endregion

// 8

#region ChangeTracker.Entries()
{
    using var context = new AppDbContext();

    var modifiedStudent = context.Students
                                .Where(s => s.Name.Contains("New"))
                                .FirstOrDefault();
    modifiedStudent.Name = "Patrick";

    var modifiedTeacher = await context.Teachers.FindAsync(1);
    modifiedTeacher.Name = "Bean";

    var newCourse = new Course
    {
        Name = "Test",
        Description = "Test",
        TeacherId = 1
    };
    context.Courses.Add(newCourse);

    foreach (var entry in context.ChangeTracker.Entries())
    {
        Console.WriteLine(
            $"{entry.Entity.GetType().Name} - {entry.State}");
    }
}
#endregion

// 10

#region Including everything
{
    using var context = new AppDbContext();

    var teachers = await context.Teachers
                            .Include(t => t.Courses)
                            .ThenInclude(c => c.Students)
                            .ToListAsync();

    foreach (var teacher in teachers)
    {
        Console.WriteLine(new string('-', 32));
        Console.WriteLine($"\nTeacher: {teacher.Name}\n");

        foreach (var course in teacher.Courses)
        {
            Console.WriteLine($"\nCourse: {course.Name}\n");

            Console.WriteLine($"Students:");
            foreach(var student in course.Students)
                Console.WriteLine($"{student.Name}");
        }
        Console.WriteLine(new string('-', 32));
    }
}

#endregion