namespace MyConsoleApp.AdoDotNetExamples
{
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Summary description for AdoDotNet(CRUD).
    /// </summary>
    /// 
    public class AdoDotNetExample : MarshalByRefObject
    {
        #region CRUD
        public void Create(string Title, string Author, string Content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".\\SQL2019E";
            sqlConnectionStringBuilder.InitialCatalog = "Blog";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "p@ssw0rd";

            string query = "INSERT INTO Blog(BlogTitle, BlogAuthor, BlogContent) VALUES (@Title, @Author, @Content)";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Title", Title);
            sqlCommand.Parameters.AddWithValue("@Author", Author);
            sqlCommand.Parameters.AddWithValue("@Content", Content);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".\\SQL2019E";
            sqlConnectionStringBuilder.InitialCatalog = "Blog";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "p@ssw0rd";

            string query = "SELECT * FROM Blog";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();

            foreach(DataRow dr in dt.Rows ) 
            {
                Console.WriteLine(dr["id"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            } 
        }

        public void Update(int id, string Title, string Author, string Content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".\\SQL2019E";
            sqlConnectionStringBuilder.InitialCatalog = "Blog";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "p@ssw0rd";

            string query = "UPDATE Blog SET BlogTitle = @Title, BlogAuthor = @Author, BlogContent = @Content WHERE id = @Id";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.Parameters.AddWithValue("@Title", Title);
            sqlCommand.Parameters.AddWithValue("@Author", Author);
            sqlCommand.Parameters.AddWithValue("@Content", Content);
            
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            sqlConnection.Close();
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".\\SQL2019E";
            sqlConnectionStringBuilder.InitialCatalog = "Blog";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "p@ssw0rd";

            string query = "DELETE FROM Blog WHERE id = @Id";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        #endregion
    }
}
