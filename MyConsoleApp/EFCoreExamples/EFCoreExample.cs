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
    }
}
