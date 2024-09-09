using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WFANOTIFIACIONES
{
    class Conexion
    {
        private SqlConnection cn = new SqlConnection();
        private SqlConnection cnNe = new SqlConnection();
        public SqlConnection Conectarse()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnotificacion"].ConnectionString);
            if (cn.State == ConnectionState.Open)
                cn.Close();
            else
                cn.Open();
            return cn;

        }

        public SqlConnection Cerrar()
        {
            cn.Close();
            return cn;
        }




        public SqlConnection ConectarseHR()
        {
            SqlConnection cnNe = new SqlConnection(ConfigurationManager.ConnectionStrings["cnNEX"].ConnectionString);
            if (cnNe.State == ConnectionState.Open)
                cnNe.Close();
            else
                cnNe.Open();
            return cnNe;

        }

        public SqlConnection CerrarHR()
        {
            cnNe.Close();
            return cnNe;
        }


    }
}
