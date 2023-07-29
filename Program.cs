using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public string Class { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        string filePath = @"C:\Users\KIIT\Desktop\Git Exercise\Practice_Projects\Student_Data_Sort_Search\Student_Data_Sort_Search\Student_Info.txt";



        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2)
            {
                Student student = new Student
                {
                    Name = parts[0].Trim(),
                    Class = parts[1].Trim()
                };
                students.Add(student);
            }
        }

        
        students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));

        
        Console.WriteLine("Sorted Student List:\n");
        foreach (Student student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
        }

        
        Console.WriteLine("\nEnter the name of the student to search:");
        string searchName = Console.ReadLine().Trim();
        Student searchResult = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        if (searchResult != null)
        {
            Console.WriteLine($"Student Found - Name: {searchResult.Name}, Class: {searchResult.Class}");
        }
        else
        {
            Console.WriteLine("Student Not Found.");
        }
    }
}
