using System;
using System.Linq;
using System.Collections.Generic;

namespace _3_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> list = new List<Article>();
            int n = int.Parse(Console.ReadLine());
            string input;




            while (n > 0)
            {
                n--;
                input = Console.ReadLine();
                string[] inputInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = inputInfo[0];
                string lastName = inputInfo[1];
                double grade = double.Parse(inputInfo[2]);
                Article article = new Article(firstName, lastName, grade);
                list.Add(article);

            }
            list = list.OrderByDescending(x => x.Grade).ToList();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}: {item.Grade:f2}");
            }

        }


    }
    internal class Article
    {
        public Article(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal double Grade { get; set; }

        //internal void ChangeAuthor(string newContents)
        //{
        //    Author = newContents;
        //}

        //internal void EditNewContent(string newContents)
        //{
        //    Content = newContents;
        //}

        //internal void Rename(string newContents)
        //{
        //    Title = newContents;
        //}
        //public override string ToString()
        //{
        //    return $"{this.Title} - {this.Content}: {this.Author}";
        //}
    }
}
