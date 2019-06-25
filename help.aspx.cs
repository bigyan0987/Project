using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newBillingProject
{
    public partial class help : System.Web.UI.Page
    {
        private SqlConnection con;
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                con = new SqlConnection("data source=.; database=Neplease; integrated security=SSPI");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM [neplease]";
                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();

                table.Append("<a href='../Nepali/AddNepali'>Headed to entry form</a><br>");
                table.Append("<table border='1'>");
                table.Append("<tr><th>Total Nepali</th><th>Children</th><th>Female</th><th>Male</th><th>Adult</th>");
                table.Append("</tr>");
                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        table.Append("<tr>");
                        table.Append("<td>" + rd[0] + "</td>");
                        table.Append("<td>" + rd[1] + "</td>");
                        table.Append("<td>" + rd[2] + "</td>");
                        table.Append("<td>" + rd[3] + "</td>");
                        table.Append("<td>" + rd[4] + "</td>");
                        table.Append("</tr>");
                    }
                }
                table.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                rd.Close();
            }
        }
    }
}