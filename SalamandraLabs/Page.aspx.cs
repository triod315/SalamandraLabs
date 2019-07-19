using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SalamandraLabs
{
    public partial class Page : System.Web.UI.Page
    {
        string DB= "Data Source=workstation id=salamandraDB.mssql.somee.com;packet size=4096;user id=triod315_SQLLogin_1;pwd=43locw7wll;data source=salamandraDB.mssql.somee.com;persist security info=False;initial catalog=salamandraDB";

        System.Web.UI.HtmlControls.HtmlGenericControl conDiv ;


        private void addArticle(Article article)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl artDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            artDiv.ID = article.ID.ToString() ;
            artDiv.Attributes["class"]="artdiv";

            System.Web.UI.HtmlControls.HtmlGenericControl title = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
            //title.ID = "titleId";
            title.Attributes["class"] = "arttitle";
            title.InnerHtml = article.title;

            artDiv.Controls.Add(title);

            System.Web.UI.HtmlControls.HtmlGenericControl hr = new System.Web.UI.HtmlControls.HtmlGenericControl("hr");

            artDiv.Controls.Add(hr);

            System.Web.UI.HtmlControls.HtmlGenericControl author = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
            //author.ID = "authorId";
            author.Attributes["class"] = "artauth";
            author.InnerHtml ="Author: "+ article.author;

            artDiv.Controls.Add(author);

            System.Web.UI.HtmlControls.HtmlGenericControl date = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
            //date.ID = "datteId";
            date.Attributes["class"] = "artdate";
            date.InnerHtml = "Date: "+article.creationDate;


            System.Web.UI.HtmlControls.HtmlGenericControl link = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
            link.Attributes["href"] = $"Articles.aspx?id={article.ID}";


            artDiv.Controls.Add(date);

            link.Controls.Add(artDiv);

            conDiv.Controls.Add(link);

            //this.Controls.Add(link);

        }

        private void addArticles()
        {
            conDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            conDiv.Attributes["class"] = ".pagecontent";
            string tag = Request.QueryString["Tag"];
            List<Article> articles = Article.getArticlesByTag(tag);
            foreach (Article article in articles)
            {
                addArticle(article);
            }
            this.Controls.Add(conDiv);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();
                string query = $"select name from chapters where tag='{Request.QueryString["Tag"]}'";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Label1.Text = reader[0].ToString();
                }
                else
                {
                    Label1.Text = "Not found";

                    return;
                }
                addArticles();
            }

            System.Web.UI.HtmlControls.HtmlGenericControl footerDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            footerDiv.Attributes["class"] = "footer";
            footerDiv.InnerHtml = @"<hr />
        <p>triod315 &copy; 2019 <a href=" + "\"http:\\\\salamandra.somee.com\">salamandra.somee.com</a></p>";
            this.Controls.Add(footerDiv);

            //Label1.Text = Request.QueryString["Tag"];
        }
    }
}