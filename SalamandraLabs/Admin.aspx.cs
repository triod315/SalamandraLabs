using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SalamandraLabs
{
    public partial class Admin : System.Web.UI.Page
    {
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
    }
}