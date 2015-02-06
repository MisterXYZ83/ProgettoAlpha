using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EstrattoContoLib
{
    public static class ManagerCliente
    {

        /// <summary>
        /// 1. Crea sul database il cliente con i dati generici passati in Cliente
        /// 2. Verifica la coerenza ed esistenza del cliente
        /// 3. OTTENERE ID NUOVO DAL DB !!
        /// 4. Ritorna 0 se OK, negativo per errore
        /// </summary>
        /// <param name="c"></param>
        public static int InserimentoCliente(Cliente c)
        {
            int ret = -1;

            string insert = "INSERT INTO CLIENTI ( NOME, COGNOME, TIPO_CLIENTE, ALTRI_DATI ) " +
                            "               VALUES ( @nome , @cognome, @tipo, @altro ) " +
                            "SET @newId = SCOPE_IDENTITY(); ";

            Connessione conn = new Connessione();

            try
            {
                bool ok = conn.ApriConnessione();

                if (!ok)
                    return -1;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = insert;
                cmd.Connection = conn.connessione;

                //serializzazione dati extra
                XmlSerializer xml = new XmlSerializer(typeof(DatiCliente));
                MemoryStream memo = new MemoryStream();

                xml.Serialize(memo, c.DatiGenarali);

                string extra_info = ManagerDataBase.UTF8ByteArrayToString(memo.ToArray());

                cmd.Parameters.AddWithValue("@nome", c.Nome);
                cmd.Parameters.AddWithValue("@cognome", c.Cognome);
                cmd.Parameters.AddWithValue("@tipo", (int)c.Tipo);
                cmd.Parameters.AddWithValue("@altro", extra_info);

                cmd.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteScalar();

                int nuovoID = (int)cmd.Parameters["@newId"].Value;

                c.ID = nuovoID;

                ret = 0;
            }
            catch (Exception e)
            {
                ret = -1;
            }
            finally
            {
                conn.ChiudiConnessione();
            }

            return ret;
        }

    }
}
