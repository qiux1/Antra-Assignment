using System;
using System.Collections.Generic;

// Interface for basic person services
interface IPersonService
{
    int CalculateAge(DateTime birthDate);
    decimal CalculateSalary();
    List<Address> GetAddresses();
}

// Interface for student-specific services, extends IPersonService
interface IStudentService : IPersonService
{
    List<Course> GetCourses();
    double CalculateGPA();
}

// Interface for instructor-specific services, extends IPersonService
interface IInstructorService : IPersonService
{
    bool IsHeadOfDepartment();
    decimal CalculateBonusSalary(decimal baseSalary, DateTime joinDate);
}

// Interface for course-specific services
interface ICourseService
{
    List<Student> GetEnrolledStudents();
}

// Address class to store information about a person's address
class Address
{
    private string street;
    private string city;
    private string state;
    private string zip;

    public Address(string street, string city, string state, string zip)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zip = zip;
    }

    public string GetAddress()
    {
        return $"{street}, {city}, {state} {zip}";
    }
}

// Person class to store information about a person
class Person : IPersonService
{
    private string name;
    private DateTime birthDate;
    private decimal salary;
    private List<Address> addresses;

    public Person(string name, DateTime birthDate, decimal salary)
    {
        this.name = name;
        this.birthDate = birthDate;
        this.salary = salary;
        addresses = new List<Address>();
    }

    // Calculate the age of the person
    public int CalculateAge(DateTime birthDate)
    {
        int age = DateTime.Now.Year - birthDate.Year;
        if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
        {
            age--;
        }
        return age;
    }

    // Calculate the salary of the person, given a base salary
    public virtual decimal CalculateSalary()
    {
        return salary;
    }

    // Get the addresses associated with the person
    public List<Address> GetAddresses()
    {
        return addresses;
    }

    // Add an address for the person
    public void AddAddress(Address address)
    {
        addresses.Add(address);
    }

    // Get the name of the person
    public string GetName()
    {
        return name;
    }
}

// Instructor class, extends Person, adds functionality specific to instructors
class Instructor : Person, IInstructorService
{
    private bool isHeadOfDepartment;
    private DateTime joinDate;
    private string subject;

    public Instructor(string name, DateTime birthDate, decimal salary, bool isHeadOfDepartment, string subject, DateTime joinDate) : base(name, birthDate, salary)
    {
        this.isHeadOfDepartment = isHeadOfDepartment;
        this.joinDate = joinDate;
        this.subject= subject;
    }

    // Check if the instructor is the head of their department
    public bool IsHeadOfDepartment()
    {
        return isHeadOfDepartment;
    }

    public DateTime GetJoinDate()
    {
        return joinDate;
    }

    // Calculate the bonus salary for the instructor, given a base salary and join date
    public decimal CalculateBonusSalary(decimal baseSalary, DateTime joinDate)
    {
        int yearsExperience = DateTime.Now.Year - joinDate.Year;
        if (DateTime.Now.DayOfYear < joinDate.DayOfYear)
        {
            yearsExperience--;
        }
        return baseSalary + (yearsExperience * 2000);
    }
}

// Course class
class Course
{
    public string Name { get; set; }
    public int Credits { get; set; }
    public string Instructor { get; set; }
    public char Grade { get; set; }

    // Get the grade points for the course based on the letter grade received by the student
    public decimal GradePoints
    {
        get
        {
            switch (Grade)
            {
                case 'A':
                    return 4.0m;
                case 'B':
                    return 3.0m;
                case 'C':
                    return 2.0m;
                case 'D':
                    return 1.0m;
                case 'F':
                    return 0m;
                default:
                    return 0m;
            }
        }
    }

    public Course(string name, int credits, string instructor, char grade)
    {
        Name = name;
        Credits = credits;
        Instructor = instructor;
        Grade = grade;
    }
}

// Student class, extends Person, adds functionality specific to students
class Student : Person, IStudentService
{
    private List<Course> courses;

    public Student(string name, DateTime birthDate, decimal salary) : base(name, birthDate, salary)
    {
        courses = new List<Course>();
    }

    // Get the courses the student is enrolled in
    public List<Course> GetCourses()
    {
        return courses;
    }

    // Add a course for the student
    public void AddCourse(Course course)
    {
        courses.Add(course);
    }

    // Calculate the GPA for the student, based on the grades for their courses
    public double CalculateGPA()
    {
        double totalPoints = 0.0;
        double totalCredits = 0.0;

        foreach (Course course in courses)
        {
            double coursePoints = 0.0;
            double courseCredits = course.Credits;

            switch (course.Grade)
            {
                case 'A':
                    coursePoints = 4.0;
                    break;
                case 'B':
                    coursePoints = 3.0;
                    break;
                case 'C':
                    coursePoints = 2.0;
                    break;
                case 'D':
                    coursePoints = 1.0;
                    break;
                case 'F':
                    coursePoints = 0.0;
                    break;
                default:
                    throw new ArgumentException($"Invalid grade {course.Grade} for course {course.Name}");
            }

            totalPoints += coursePoints * courseCredits;
            totalCredits += courseCredits;
        }

        return totalPoints / totalCredits;
    }


}



class Program
{
    static void Main(string[] args)
    {
        // Create a student
        Student s = new Student("Xinyu", new DateTime(1995, 7, 28), 0);
        s.AddCourse(new Course("CS101", 4, "Boaz Barak", 'A'));
        s.AddCourse(new Course("MATH101", 5, "Auroux, Denis", 'B'));
        s.AddCourse(new Course("PHYS101", 5, "Michael P. Brenner", 'A'));

        // Calculate and print the student's GPA
        double gpa = s.CalculateGPA();
        Console.WriteLine($"{s.GetName()}'s GPA is {gpa}");

        // Create an instructor
        Instructor i = new Instructor("Lebron James", new DateTime(1985, 12, 28), 1000000, true, "Computer Science", new DateTime(2003, 5, 13));
        

        // Calculate and print the instructor's salary
        decimal salary = i.CalculateSalary();
        Console.WriteLine($"{i.GetName()}'s salary is {salary}");
        decimal bonusSalary = i.CalculateBonusSalary(salary, i.GetJoinDate());
        Console.WriteLine($"{i.GetName()}'s bonus salary is {bonusSalary}");
    }
}