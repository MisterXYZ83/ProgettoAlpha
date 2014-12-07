using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using System.Xml.Serialization;
using System.Xml;


namespace EstrattoContoLib
{

    public static class ManagerDataBase
    {


        /// <summary>
        /// 1. Crea sul database il cliente con i dati generici passati in Cliente
        /// 2. Verifica la coerenza ed esistenza del cliente
        /// 3. OTTENERE ID NUOVO DAL DB !!
        /// 4. Ritorna 0 se OK, negativo per errore
        /// </summary>
        /// <param name="c"></param>
        public static int AggiungiCliente(Cliente c)
        {
            string select = "INSERT INTO Clienti ( Tester , Premise ) " +
                            "               VALUES ( @tester , @premise ) " +
                            "SET @newId = SCOPE_IDENTITY(); ";
            Connessione conn = new Connessione();
            try
            {
                bool ok = conn.ApriConnessione();
                if (!ok)
                    return -1;

                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = select;
                cmd.Connection = conn.connessione;

                XmlSerializer xml = new XmlSerializer(typeof (DatiCliente));
                Byte[] stream = new System.IO.MemoryStream().ToArray();
                //xml.Serialize((stream, c.DatiGenarali);
                 

                //cmd.Parameters.AddWithValue("@tester", newTest.tester);
                //cmd.Parameters.AddWithValue("@premise", newTest.premise);
                cmd.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteScalar();
                int nuovoID = (int)cmd.Parameters["@newId"].Value;


                c.ID = nuovoID;
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.ChiudiConnessione();
            }

            return 0;
        }

        /// <summary>
        /// NB. Il conto corrente DEVE essere linkato ad una istanza di Cliente esistente (istanze sul database, dunque IDCliente != 0)
        /// 
        /// 1. Crea sul database il conto corrente
        /// 2. Crea tabelle sul database (Operazioni_IDContoCorrente, EstrattiConto_IDContoCorrente)
        /// 3. OTTIENE IL NUOVO ID dal DATABASE!!
        /// 4. ritorna 0 se OK, negativo per errore
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static int AggiungiContoCorrente(ContoCorrente cc)
        {
            return 0;
        }

        /// <summary>
        /// NB. DEVE ESISTERE UN ESTRATTO CONTO SU CUI INSERIRE L'OPERAZIONE
        /// 
        /// 1. Verifica validita parametri Operazione ( IDContoCorrente, date assurde )
        /// 2. Verifica esistenza operazione
        /// 2.a se force_update == true ritorna negativo se esistente e aggiorna i riferimenti agli estratti conto su database e sull'oggetto (quindi il chiamante ha gia il dominio di collisione)
        /// 2.aa se force_update == false ritorna negativo se esistente e aggiorna i campi dell'oggetto
        /// 2.b continua con la procedura
        /// 3. Inserisce nella tabella OPERAZIONI e aggiorna il riferimento sulla tabella ESTRATTI_CONTO
        /// 4. Aggiorna IDOperazione e GUID.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int AggiungiOperazione(Operazione o, bool force_update)
        {
            return 0;
        }

        /// <summary>
        /// 1. Verifica che non esista lo stesso estratto conto (da definifire criterio isEqual)
        /// 2. Inserisce su database e riempie l'IDEstratto
        /// 3. Lista operazioni VUOTA
        /// 4. ritorna 0 se tutto ok, negativo in caso di errore
        /// </summary>
        /// <param name="ec"></param>
        /// <returns></returns>
        public static int AggiungiEstrattoConto(EstrattoConto ec)
        {
            return 0;
        }


    }
}
