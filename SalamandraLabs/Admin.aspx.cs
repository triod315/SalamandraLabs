using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SalamandraLabs
{

    public class ArticleRow
    {
        public static int NameWidth = 200;
        public static int ButtonsWidth = 75;
        public Article article { get; set; }
        public Label IDLabel { get; set; }
        public Label DateField { get; set; }
        public Label NameLabel { get; set; }
        public Button View { get; set; }
        public Button Delete { get; set; }
        public ArticleRow(Article art)
        {
            article = art;
            IDLabel = new Label();
            IDLabel.Text = article.ID.ToString();
            IDLabel.Font.Bold = true;
            IDLabel.Font.Size = 14;
            IDLabel.Width = 25;

            DateField = new Label();
            DateField.Text = article.creationDate.ToString();
            DateField.Font.Bold = true;
            DateField.Font.Size = 14;
            DateField.Width = NameWidth;

            NameLabel = new Label();
            NameLabel.Text = article.title;
            NameLabel.Font.Bold = true;
            NameLabel.Font.Size = 14;
            NameLabel.Width = NameWidth;

            View = initButton("View");
            Delete = initButton("Delete");
        }

        Button initButton(string name)
        {
            Button b4 = new Button();

            b4.Text = name; b4.Font.Bold = true; b4.Font.Size = 14;
            b4.Width = ButtonsWidth;
            b4.CommandArgument = article.ID.ToString() + "|" + article.creationDate.ToString() + "|" + article.title;
            return b4;
        }

        public static List<ArticleRow> convertToRowsList(List<Article> articles)
        {
            List<ArticleRow> result = new List<ArticleRow>();
            foreach (Article art in articles)
                result.Add(new ArticleRow(art));
            return result;
        }

    }

    public partial class Admin : System.Web.UI.Page
    {
        System.Web.UI.HtmlControls.HtmlGenericControl conDiv;


        string DB = "Data Source=workstation id=salamandraDB.mssql.somee.com;packet size=4096;user id=triod315_SQLLogin_1;pwd=43locw7wll;data source=salamandraDB.mssql.somee.com;persist security info=False;initial catalog=salamandraDB";

        string name;
        string email;
        Dictionary<string, string> tags;

        private void loadTags()
        {
            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();
                string query = "select * from chapters";
                tags = new Dictionary<string, string>();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader= command.ExecuteReader();
                while (reader.Read())
                {
                    tags.Add(reader[1].ToString(), reader[0].ToString());
                    DropDownList1.Items.Add(reader[1].ToString());
                }
            }
        }

        private void loadInfo()
        {
            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();
                string query = "select * from users";
                
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Label2.Text = "Login:\t" + reader[0].ToString();
                    Label3.Text = "Name:\t" + reader[1].ToString();
                    Label4.Text = "Email:\t" + reader[2].ToString();
                }

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.username == null) Response.Redirect("~/Login.aspx");
            Label1.Text = Login.username;
            loadTags();
            loadInfo();
            loadPostedArticles();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();
                string query = $"insert into articles (tag,title,task,author,creationDate,solutionlink,codelink,fileslink) values ('{tags[DropDownList1.SelectedValue]}','{TextBox1.Text}','{TextBox2.Text}','{Login.username}','{DateTime.Now}','{TextBox3.Text}','{TextBox4.Text}','{TextBox5.Text}')";
                
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();  
            }
        }


        private void loadPostedArticles()
        {
            //conDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            //conDiv.Attributes["class"] = "postedadminpagecontent";
            //string authLogin = Login.username;
            //List<Article> articles = Article.getAllArticles();
            //foreach (Article article in articles)
            //{
            //    addPostedArticle(article);
            //}
            //this.Controls.Add(conDiv);

            int TableWidth = 450;


            Table1.Width = TableWidth /*+ 3 * GalTableField.ButtonsWidth*/;
            Table1.Font.Size = 14;

            Table1.Rows.Clear();
            TableRow tr1 = new TableRow();
            TableCell td11 = new TableCell();
            TableCell td12 = new TableCell();
            TableCell td13 = new TableCell();

            Label l11 = new Label();
            Label l12 = new Label();
            Label l13 = new Label();

            l11.Text = "ID"; td11.Controls.Add(l11); tr1.Cells.Add(td11);
            l12.Text = "Date"; td12.Controls.Add(l12); tr1.Cells.Add(td12);
            l13.Text = "Name"; td13.Controls.Add(l13); tr1.Cells.Add(td13);



            tr1.HorizontalAlign = HorizontalAlign.Center;
            tr1.Width = TableWidth/* + 3 * GalTableField.ButtonsWidth*/;
            Table1.Rows.Add(tr1);

            List<ArticleRow> articles = ArticleRow.convertToRowsList(Article.getAllArticles());

            for (int i = 0; i < articles.Count; i++)
            {
                TableRow tr2 = new TableRow();

                TableCell td02 = new TableCell();
                td02.Controls.Add(articles[i].IDLabel);
                tr2.Cells.Add(td02);

                TableCell td01 = new TableCell();
                td01.Controls.Add(articles[i].DateField);
                tr2.Cells.Add(td01);

                TableCell td00 = new TableCell();
                td00.Controls.Add(articles[i].NameLabel);
                tr2.Cells.Add(td00);

                TableCell td2 = new TableCell();
                articles[i].View.Command += new CommandEventHandler(viewRecord);
                articles[i].View.CssClass = "DynamicButtons";
                
                td2.Controls.Add(articles[i].View);
                tr2.Cells.Add(td2);

                TableCell td3 = new TableCell();
                articles[i].Delete.Command += new CommandEventHandler(viewRecord);
                articles[i].Delete.CssClass = "DynamicButtons";

                td3.Controls.Add(articles[i].Delete);
                tr2.Cells.Add(td3);

                Table1.Rows.Add(tr2);
            }
        }

        void viewRecord(object sender, CommandEventArgs e)
        {

        }

        void deleteRecord(object sender, CommandEventArgs e)
        {

        }
        private void addPostedArticle(Article article)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl artDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            artDiv.ID = article.ID.ToString();
            artDiv.Attributes["class"] = "artdiv";

            System.Web.UI.HtmlControls.HtmlGenericControl title = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
            //title.ID = "titleId";
            title.Attributes["class"] = "arttitle";
            title.InnerHtml = article.title;

            artDiv.Controls.Add(title);

            System.Web.UI.HtmlControls.HtmlGenericControl date = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
            //date.ID = "datteId";
            date.Attributes["class"] = "artdate";
            date.InnerHtml = "Date: " + article.creationDate;

            artDiv.Controls.Add(date);

            System.Web.UI.HtmlControls.HtmlGenericControl hr = new System.Web.UI.HtmlControls.HtmlGenericControl("hr");

            artDiv.Controls.Add(hr);




            

            System.Web.UI.HtmlControls.HtmlGenericControl link = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
            link.Attributes["href"] = $"Articles.aspx?id={article.ID}";


            
                
            //link.Controls.Add(artDiv);

            conDiv.Controls.Add(artDiv);

            //this.Controls.Add(link);

        }
    }
}