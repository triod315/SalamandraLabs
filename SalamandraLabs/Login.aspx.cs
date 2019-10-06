using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SalamandraLabs
{
    public partial class Login : System.Web.UI.Page
    {
        string DB = "Data Source=workstation id=salamandraDB.mssql.somee.com;packet size=4096;user id=triod315_SQLLogin_1;pwd=43locw7wll;data source=salamandraDB.mssql.somee.com;persist security info=False;initial catalog=salamandraDB";

        public static string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl footerDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            footerDiv.Attributes["class"] = "footer";
            footerDiv.InnerHtml = @"<hr />
        <p>triod315 &copy; 2019 <a href=" + "\"http:\\\\salamandra.somee.com\">salamandra.somee.com</a></p>";
            this.Controls.Add(footerDiv);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = TextBox1.Text;
            string password = TextBox2.Text;
            using (SqlConnection conn = new SqlConnection(DB))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"select password from users where nikname='{login}'", conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader[0].ToString() == password)
                    {
                        username = login;
                        Response.Redirect("~/Admin.aspx");
                    }
                }
            }
        }
    }
}