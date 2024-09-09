using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WFANOTIFIACIONES
{
    public partial class Form1 : Form
    {
        List<string> miLista = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetNotificaciones("A");
            //DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            //textColumn.DataPropertyName = "column1";
            //textColumn.Name = "column1";
            //textColumn.ReadOnly = true;
            //DGVNotificaciones.Columns.Add(textColumn);
        }
        public void GetNotificaciones(string flag)
        {
            Conexion connstring = new Conexion();
            try
            {


                SqlDataAdapter dadapter;
                DataSet dset;


                // Create the command strings for querying the Contact table.
                String query = "";
                query += "SELECT NOMBRE,APELLIDO,LEGAJO,REMOLCADOR";
                query += ", CONVERT(NVARCHAR, FECHA_DESDE, 23) AS FECHA_DESDE,INICIO_VIAJE,FIN_VIAJE";
                query += ",FECHA_HASTA,CATEGORIA,OBSERVACIONES";
                query += ",NOTIFICADO FROM dbo.NOTIFICACION_TRIPULACION ";

                if (flag == "A")
                {
                    query += "";
                }
                else if (flag == "N")
                {
                    query += " WHERE NOMBRE LIKE '%" + txt_nombre.Text.ToUpper() + "%'";
                }
                else if (flag == "L")
                {

                    query += "WHERE LEGAJO =" + txt_legajo.Text;
                }

                dadapter = new SqlDataAdapter(query, connstring.Conectarse());
                dset = new DataSet();
                dadapter.Fill(dset);
                DGVNotificaciones.DataSource = dset.Tables[0].DefaultView;

                connstring.Cerrar();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                connstring.Cerrar();
            }
        }

        private void DGVNotificaciones_ReadOnlyChanged(object sender, EventArgs e)
        {
            DGVNotificaciones.ReadOnly = false;
            DGVNotificaciones.Columns[11].ReadOnly = true;

        }




        private void btnNotifica_Click(object sender, EventArgs e)
        {
            string strsql = "";
            string cadena = "";
            foreach (DataGridViewRow row in DGVNotificaciones.Rows)
            {
                string obs = row.Cells["OBSERVACIONES"].Value.ToString();
                string flg = row.Cells["NOTIFICADO"].Value.ToString();

                if ((obs != ".") && (flg == "False"))
                {
                    strsql = "SET OBSERVACIONES ='" + obs + "'";
                    strsql += ",NOTIFICADO= " + 1 + " Where LEGAJO = " + row.Cells["LEGAJO"].Value + "AND FECHA_DESDE ='" + row.Cells["FECHA_DESDE"].Value + "'";
                    string mensaje = row.Cells["OBSERVACIONES"].Value.ToString();
                    cadena = row.Cells["LEGAJO"].Value.ToString() + "," + row.Cells["FECHA_DESDE"].Value.ToString() + "," + obs;
                    miLista.Add(cadena);
                    ActualizaNotificacion(strsql, mensaje);
                }
                else if ((obs == ".") && (flg == "False"))
                {
                    break;
                }
            }
            traerobservaciones();
            MessageBox.Show("Novedades enviadas");
        }
        public void ActualizaNotificacion(string instruccion, string mensaje)
        {
            try
            {
                Conexion cns = new Conexion();
                String sql = "UPDATE  NOTIFICACION_TRIPULACION " + instruccion;
                SqlCommand command = new SqlCommand(sql, cns.Conectarse());
                command.ExecuteNonQuery();
                cns.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el registro en la base de datos: " + ex.Message);
            }
        }
        private void traerobservaciones()
        {

            string[] enviarmensaje = miLista.ToArray();
            string numeroMov = "";
            string nuevoNumero = "";


            for (int i = 0; i < enviarmensaje.Length; i++)
            {

                //se busca el nro de telefono para enviar el whatsapp
                string[] valores = enviarmensaje[i].Split(',');
                Conexion connstring = new Conexion();

                SqlDataAdapter dadapter;
                DataSet dset;
                String query = "";
                query += "select tel_movil from basi_personal ";
                query += "where nro_leg =" + valores[0];

                dadapter = new SqlDataAdapter(query, connstring.ConectarseHR());
                dset = new DataSet();
                dadapter.Fill(dset);
                DataTable telefono = dset.Tables[0];
                numeroMov = telefono.Rows[0]["tel_movil"].ToString();

                if (numeroMov.Contains("/"))
                {
                    nuevoNumero = numeroMov.Substring(0, numeroMov.IndexOf("/"));
                }
                if (numeroMov.Contains(".") || numeroMov.Contains(" "))
                {
                    nuevoNumero = numeroMov.Replace(".", "").Replace(" ", "");
                }
               //MessageBox.Show(nuevoNumero);

                EnviaralertaWS(enviarmensaje[i].ToString(), nuevoNumero);

            }
            GetNotificaciones("A");
        }



        private void EnviaralertaWS(string mensaje, string telefonoMov)
        {
            //MessageBox.Show(mensaje);
            // Construir el texto para el HTTP POST
            string texto = $"Le informamos que no cobrara su bono por el viaje..  Por el siguiente motivo:" + mensaje;

            // Realizar el HTTP POST
            //string url = $"http://api.textmebot.com/send.php?text={HttpUtility.UrlEncode(texto)}&apikey=F47QFpfmhS3r&recipient=120363157185389247@g.us";
            //string url = $"http://api.textmebot.com/send.php?text={HttpUtility.UrlEncode(texto)}&apikey=F47QFpfmhS3r&recipient=5491162043235";
            string url = $"http://api.textmebot.com/send.php?text={HttpUtility.UrlEncode(texto)}&apikey=F47QFpfmhS3r&recipient={HttpUtility.UrlEncode(telefonoMov)}";


            HttpClient httpClient = new HttpClient();
            httpClient.PostAsync(url, new StringContent(""));
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            if (txt_nombre.Text.Length != 0)
            {
                GetNotificaciones("N");
            }
            else
            {
                GetNotificaciones("A");
            }

        }
        private void txt_legajo_TextChanged(object sender, EventArgs e)
        {
            if (txt_legajo.Text.Length != 0)
            {
                GetNotificaciones("L");
            }
            else
            {
                GetNotificaciones("A");
            }


        }
    }
}
