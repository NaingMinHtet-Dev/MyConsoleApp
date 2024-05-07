using MyConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext appDbContext = new AppDbContext();
            List<BlogModel> list = appDbContext.Blogs.ToList();

            foreach (BlogModel item in list)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(int id)
        {
            AppDbContext appDbContext = new AppDbContext();    
            BlogModel item = appDbContext.Blogs.FirstOrDefault(item => item.Id == id);

            if(item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.Id);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            AppDbContext appDbContext = new AppDbContext();
            appDbContext.Blogs.Add(blogModel);
            appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            AppDbContext appDbContext = new AppDbContext();
            BlogModel item = appDbContext.Blogs.FirstOrDefault(item => item.Id == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            appDbContext.Blogs.Remove(item);
            int result = appDbContext.SaveChanges();

            string message = result > 0 ? "Delete successfully." : "Fail to delete.";
            Console.WriteLine(message);
        }
    }
}
