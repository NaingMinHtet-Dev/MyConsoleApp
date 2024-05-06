namespace MyConsoleApp.DapperExamples
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dapper;
    using MyConsoleApp.Models;
    using System.Reflection.Metadata;

    /// <summary>
    /// Summary description for Dapper(CRUD).
    /// </summary>
    /// 
    public class DapperExample : MarshalByRefObject
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".\\SQL2019E",
            InitialCatalog = "Blog",
            UserID = "sa",
            Password = "p@ssw0rd"
        };

        public void Create(string Title, string Author, string Content)
        {
            string query = "INSERT INTO Blog(BlogTitle, BlogAuthor, BlogContent) VALUES (@BlogTitle, @BlogAuthor, @BlogContent)";

            BlogModel blog = new BlogModel()
            {
                BlogTitle = Title,
                BlogAuthor = Author,
                BlogContent = Content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Record created." : "No Rows affected.";
            Console.WriteLine(message);
        }

        public void Read()
        {
            string query = "SELECT * FROM Blog";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> list = db.Query<BlogModel>(query).ToList();
            
            foreach(BlogModel item in list)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Update(int id, string Title, string Author, string Content)
        {
            string query = @"UPDATE Blog SET BlogTitle = @BlogTitle," +
                                            "BlogAuthor = @BlogAuthor," +
                                            "BlogContent = @BlogContent " +
                                            "WHERE id = @Id";

            BlogModel blog = new BlogModel()
            {
                Id = id,
                BlogTitle = Title,
                BlogAuthor = Author,
                BlogContent = Content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Update successfully." : "Fail to update.";
            Console.WriteLine(message);
        } 

        public void Delete(int id)
        {
            string query = "DELETE FROM Blog WHERE id = @Id";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, new {id});

            string message = result > 0 ? "Delete successfully." : "This data does not exit.";
            Console.WriteLine(message);
        }
    }
}
