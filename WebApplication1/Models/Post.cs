using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Post
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }
    }

    public static class Load
    {

        static string lorem = @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
";
        public static List<Post> LoadData()
        {
            List<Post> posts = new List<Post>();
            Random rnd = new Random();

            string[] titles = lorem.Split(' ');
            string statemen = getStatenment(titles);
            int id = 1;

            for (int n = 1; n <= 50; n++)
            {
                if ((n % 10) == 0)
                    id = id + 1;

                posts.Add(new Post
                {
                    Completed = rnd.Next(0, 2) == 1,
                    Id = n,
                    Title = getStatenment(titles),
                    UserId = id
                });

            }

            return posts;
        }

        static string getStatenment(string[] titles)
        {
            System.Threading.Thread.Sleep(100);
            Random rnd = new Random();
            int countTitles = titles.Length - 5;
            int index = rnd.Next(0, countTitles);
            int countStatements = rnd.Next(3, 6);

            return string.Join(" ", titles.Skip(index).Take(countStatements));
        }
    }
}