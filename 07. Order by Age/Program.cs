using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commArr = command.Split(' ');
                string name = commArr[0];
                string id = commArr[1];
                int age = int.Parse(commArr[2]);
                Student student = new Student(name, id, age);
                if (studentList.Any(x => x.Id.Contains(id)))
                {
                    Student obj = studentList.Find(x => x.Id == id);
                    if (obj != null)
                    {
                        obj.Name = name;
                        obj.Age = age;
                    }
                }
                else
                {
                    studentList.Add(student);

                }
            }
            studentList = studentList.OrderBy(x => x.Age).ToList();
            foreach (var item in studentList)
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }
        }
    }
    internal class Student
    {
        public Student(string name, string id, int age)
        {
            Name = name;
            this.Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

       
    }
}
