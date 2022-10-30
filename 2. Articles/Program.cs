using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

namespace _2._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string[] inputInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string title = inputInfo[0];
            string content = inputInfo[1];
            string author = inputInfo[2];
            Article article = new Article(title, content, author);
            

            while (n > 0)
            {
                n--;
                input = Console.ReadLine();
                string[] commArr = input.Split(": ");
                string newContents = commArr[1];


                if (commArr[0] == "Edit")
                {

                    article.EditNewContent(newContents);
                }
                else if (commArr[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(newContents);
                }
                else if (commArr[0] == "Rename")
                {
                    article.Rename(newContents);
                }
            }
            Console.WriteLine(article.ToString());

        }


    }
    internal class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        internal string Title { get; set; }
        internal string Content  { get; set; }
        internal string Author  { get; set; }

        internal void ChangeAuthor(string newContents)
        {
            Author = newContents;
        }

        internal void EditNewContent(string newContents)
        {
            Content = newContents;
        }

        internal void Rename(string newContents)
        {
            Title = newContents;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
