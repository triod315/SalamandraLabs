using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace SalamandraLabs
{
    public class Article
    {
        public int ID { get; set; }
        public string tag { get; set; }

        public string title { get; set; }
        public string task { get; set; }
        public string author { get; set; }
        public string creationDate { get; set; }
        public string solutionlink { get; set; }
        public string codelink { get; set; }
        public string fileslink { get; set; }

        public Article(string ID,string tag,string title,string task,string author,string creationDate, string solutionlink, string codelink,string fileslink)
        {
            this.tag = tag;
            this.ID = int.Parse(ID);
            this.title = title;
            this.task = task;
            this.author = author;
            this.creationDate = creationDate;
            this.codelink = codelink;
            this.fileslink = fileslink;
            this.solutionlink = solutionlink;
        }

        public static string DB= "Data Source=workstation id=salamandraDB.mssql.somee.com;packet size=4096;user id=triod315_SQLLogin_1;pwd=43locw7wll;data source=salamandraDB.mssql.somee.com;persist security info=False;initial catalog=salamandraDB";
        public static List<Article> getArticlesByTag(string tag)
        {
            List<Article> articles = new List<Article>();

            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();
                string qurey = $"select * from articles where tag='{tag}'";
                SqlCommand command = new SqlCommand(qurey,conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    articles.Add(new Article(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(),reader[8].ToString()));
                }
            }


            return articles; 
        }

        public static List<Article> getAllArticles()
        {
            List<Article> articles = new List<Article>();

            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();
                string qurey = $"select * from articles order by creationDate desc";
                SqlCommand command = new SqlCommand(qurey, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    articles.Add(new Article(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString()));
                }
            }


            return articles;
        }

        public static Article getArticleByID(string id)
        {
            List<Article> articles = new List<Article>();

            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();
                string qurey = $"select * from articles where id='{id}'";
                SqlCommand command = new SqlCommand(qurey, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    articles.Add(new Article(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString()));
                }
            }

            try
            {
                return articles[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}