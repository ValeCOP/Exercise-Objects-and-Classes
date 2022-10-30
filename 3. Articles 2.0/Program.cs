using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._Articles_2
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
                string[] inputInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string title = inputInfo[0];
                string content = inputInfo[1];
                string author = inputInfo[2];
                Article article = new Article(title, content, author);
                list.Add(article);

            }
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Title} - {item.Content}: {item.Author}");
            }

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
        internal string Content { get; set; }
        internal string Author { get; set; }

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
