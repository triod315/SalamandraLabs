using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalamandraLabs
{
    public partial class Default : System.Web.UI.Page
    {

        private void addArticle(Article article)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl artDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            artDiv.ID = article.ID.ToString();
            artDiv.Attributes["class"] = "artdiv";

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
            author.InnerHtml = "Author: " + article.author;

            artDiv.Controls.Add(author);

            System.Web.UI.HtmlControls.HtmlGenericControl date = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
            //date.ID = "datteId";
            date.Attributes["class"] = "artdate";
            date.InnerHtml = "Date: " + article.creationDate;


            System.Web.UI.HtmlControls.HtmlGenericControl link = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
            link.Attributes["href"] = $"Articles.aspx?id={article.ID}";


            artDiv.Controls.Add(date);

            link.Controls.Add(artDiv);

            this.Controls.Add(link);

        }

        private void addArticles()
        {
            List<Article> articles = Article.getAllArticles();
            foreach (Article article in articles)
            {
                addArticle(article);
            }


            System.Web.UI.HtmlControls.HtmlGenericControl footerDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            footerDiv.Attributes["class"] = "footer";
            footerDiv.InnerHtml = @"<hr />
        <p>triod315 &copy; 2019 <a href="+"\"http:\\\\salamandra.somee.com\">salamandra.somee.com</a></p>";
            this.Controls.Add(footerDiv);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            addArticles();
        }
    }
}