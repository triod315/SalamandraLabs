using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalamandraLabs
{
    public partial class Articles : System.Web.UI.Page
    {
        string DB = "Data Source=workstation id=salamandraDB.mssql.somee.com;packet size=4096;user id=triod315_SQLLogin_1;pwd=43locw7wll;data source=salamandraDB.mssql.somee.com;persist security info=False;initial catalog=salamandraDB";

        System.Web.UI.HtmlControls.HtmlGenericControl conDiv;


        private void addArticle(Article article)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl artDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            artDiv.ID = article.ID.ToString();
            artDiv.Attributes["class"] = "artpagediv";

            System.Web.UI.HtmlControls.HtmlGenericControl title = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
            //title.ID = "titleId";
            title.Attributes["class"] = "arttitle";
            title.InnerHtml = article.title;

            artDiv.Controls.Add(title);

            System.Web.UI.HtmlControls.HtmlGenericControl hr = new System.Web.UI.HtmlControls.HtmlGenericControl("hr");

            artDiv.Controls.Add(hr);

            //add solution link

            System.Web.UI.HtmlControls.HtmlGenericControl solllabel = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            solllabel.Attributes["class"] = "sollink";
            solllabel.InnerHtml = "Solution: " + article.solutionlink;

            System.Web.UI.HtmlControls.HtmlGenericControl solla = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
            solla.Attributes["href"] = article.solutionlink;
            solla.Controls.Add(solllabel);
            artDiv.Controls.Add(solla);

            //add colde source link

            System.Web.UI.HtmlControls.HtmlGenericControl sourlabel = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            sourlabel.Attributes["class"] = "sollink";
            sourlabel.InnerHtml = "Source code: " + article.codelink;

            System.Web.UI.HtmlControls.HtmlGenericControl soura = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
            soura.Attributes["href"] = article.codelink;
            soura.Controls.Add(sourlabel);
            artDiv.Controls.Add(soura);

            //add files button

            System.Web.UI.HtmlControls.HtmlGenericControl filesButton = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            filesButton.Attributes["class"] = "filesbutt";
            filesButton.InnerHtml = "Download solution";

            System.Web.UI.HtmlControls.HtmlGenericControl filesa = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
            filesa.Attributes["href"] = article.fileslink;
            filesa.Controls.Add(filesButton);
            artDiv.Controls.Add(filesa);

            System.Web.UI.HtmlControls.HtmlGenericControl hr1 = new System.Web.UI.HtmlControls.HtmlGenericControl("hr");

            artDiv.Controls.Add(hr1);

            System.Web.UI.HtmlControls.HtmlGenericControl author = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
            //author.ID = "authorId";
            author.Attributes["class"] = "artauth";
            author.InnerHtml = "Author: " + article.author;

            artDiv.Controls.Add(author);

            System.Web.UI.HtmlControls.HtmlGenericControl date = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
            //date.ID = "datteId";
            date.Attributes["class"] = "artdate";
            date.InnerHtml = "Date: " + article.creationDate;


            //System.Web.UI.HtmlControls.HtmlGenericControl link = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
            //link.Attributes["href"] = $"Articles.aspx?id={article.ID}";


            artDiv.Controls.Add(date);
            
            //link.Controls.Add(artDiv);

            conDiv.Controls.Add(artDiv);

            //this.Controls.Add(link);


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            conDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            conDiv.Attributes["class"] = ".pagecontent";
            string id = Request.QueryString["id"];
            Article article = Article.getArticleByID(id);
            addArticle(article);
            this.Controls.Add(conDiv);

            System.Web.UI.HtmlControls.HtmlGenericControl footerDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            footerDiv.Attributes["class"] = "footer";
            footerDiv.InnerHtml = @"<hr />
        <p>triod315 &copy; 2019 <a href=" + "\"http:\\\\salamandra.somee.com\">salamandra.somee.com</a></p>";
            this.Controls.Add(footerDiv);
        }
    }
}