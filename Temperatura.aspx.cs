using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace WebApplication1
{
    public partial class Temperatura : System.Web.UI.Page
    {
        [WebMethod]
        public static double TemperaturaAtual()
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:projeto321.database.windows.net,1433;Initial Catalog=dbprojeto;Persist Security Info=False;User ID=projeto321;Password=Faculdadebandtec2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT valor FROM leitura WHERE id_leitura = (SELECT MAX(id_leitura) FROM leitura)", conn))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() == true)
                        {
                            return double.Parse(dr["valor"].ToString());
                        }
                        else
                        {
                            return 0;
                        }
                    }

                }

            }
        }
    }
}