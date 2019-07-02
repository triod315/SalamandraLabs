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
            }

            //Label1.Text = Request.QueryString["Tag"];
        }
    }
}