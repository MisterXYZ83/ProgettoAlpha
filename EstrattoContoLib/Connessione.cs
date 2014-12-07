using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EstrattoContoLib
{
    public class Connessione
    {
        static string STRINGA_CONNESSIONE = "";
        
        public SqlConnection connessione;

        public bool ApriConnessione()
        {
            bool ok = true;
            connessione = new SqlConnection();
            try
            {
                connessione.ConnectionString = STRINGA_CONNESSIONE;
                connessione.Open();
            }
            catch (Exception e)
            { 
                ok = false;
            }

            return ok;
        }

        public bool ChiudiConnessione()
        {
            bool ok = true;
            
            try
            {
                connessione.Close();
            }
            catch (Exception e)
            {
                ok = false;
            }

            return ok;
        }
    }
}
