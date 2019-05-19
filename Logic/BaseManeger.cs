using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BaseManeger
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Arturs\source\repos\BizonaRegistrs\BizonaRegistrs.mdf;Integrated Security=True;Connect Timeout=30");
        protected SqlCommand cmd;
        protected SqlDataAdapter adatper;
        protected DataSet data;

        public BaseManeger()
        {
            conn.Open();
        }
    }
}
