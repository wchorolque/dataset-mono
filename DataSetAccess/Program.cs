using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UI;

namespace DataSetAccess
{
    class MainClass
    {
        public static void DescribirColumnasDeTabla (string connectionString)
        {
            // Tener habilitado el SQL Server Browser
            // Standart Security
            //String connection = @"Data Source=127.0.0.1\SQLExpress2005; Initial Catalog=Northwind; User ID=sa; Password=admin";
            DataSet MiDataSet = new DataSet ("ds");
            SqlConnection conn = new SqlConnection ();
            conn.ConnectionString = connectionString;
            
            conn.Open ();
            SqlDataAdapter adp = new SqlDataAdapter ("select * from Employees", conn);
            adp.Fill (MiDataSet, "Employees");
            
            foreach (DataTable tabla in MiDataSet.Tables) {
                Console.WriteLine ("***** Tabla: {0} *****", tabla.TableName);
                foreach (DataColumn columna in tabla.Columns) {
                    Console.WriteLine ("Columna {0} Tipo: {1}", 
                                       columna.ColumnName.ToString (),
                                       columna.DataType.ToString ()
                    );
                }
            }
            conn.Close ();
        }

        public static void VerContenidoDeLaTabla (string connectionString)
        {
            SqlConnection conn = new SqlConnection ();
            conn.ConnectionString = connectionString;
            SqlCommand miComando = new SqlCommand ("SELECT * FROM Employees", conn);
            SqlDataReader miDataReader;
            conn.Open ();
            miDataReader = miComando.ExecuteReader (CommandBehavior.CloseConnection);
            
            String sep = "+";
            String line1 = String.Format ("+{0}{1}{2}{3}", sep.PadLeft (4, '-'), sep.PadLeft (17, '-'), sep.PadLeft (17, '-'), sep.PadLeft (27, '-'));
            sep = "|";
            String line2 = String.Format ("|{0}{1}{2}{3}", sep.PadLeft (4, ' '), sep.PadLeft (17, ' '), sep.PadLeft (17, ' '), sep.PadLeft (27, ' '));
            Console.WriteLine (line1);
            Console.WriteLine (line2);
            Console.WriteLine (line1);
            while (miDataReader.Read()) {
                string row = String.Format ("|{0, 3}| {1, -15}| {2, -15}| {3, -25}|", 
                                            miDataReader [0].ToString (), 
                                            miDataReader [1].ToString (),
                                            miDataReader [2].ToString (),
                                            miDataReader [3].ToString ()
                );
                Console.WriteLine (row);
            }
            Console.WriteLine (line1);
            miComando = null;
        }

        [STAThread]
        public static void Main (string[] args)
        {
            /*
            String connectionString = @"Data Source=localhost\SQLExpress2005; Initial Catalog=Northwind; User ID=sa; Password=admin";
            DescribirColumnasDeTabla (connectionString);
            Console.WriteLine ("\n".PadRight (100, '=') + "\n");
            VerContenidoDeLaTabla (connectionString);
            Console.ReadLine ();
            */
            Application.EnableVisualStyles ();
            Application.Run (new UI.FrmEmployee (new DAL.Employee ()));
        }
    }
}
