using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using System.Xml.Serialization;
using System.Xml;
using System.IO;


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
        public static int InserimentoCliente(Cliente c)
        {
            int ret = -1;

            string select = "INSERT INTO CLIENTI ( NOME, COGNOME, TIPO_CLIENTE, ALTRI_DATI ) " +
                            "               VALUES ( @nome , @cognome, @tipo, @altro ) " +
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

                //serializzazione dati extra
                XmlSerializer xml = new XmlSerializer(typeof (DatiCliente));
                MemoryStream memo = new MemoryStream();

                xml.Serialize(memo, c.DatiGenarali);

                string extra_info = UTF8ByteArrayToString(memo.ToArray());

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

        /// <summary>
        /// NB. Il conto corrente DEVE essere linkato ad una istanza di Cliente esistente (istanze sul database, dunque IDCliente != 0)
        /// 
        /// 1. Crea sul database il conto corrente
        /// 2. Crea tabelle sul database (Operazioni_IDContoCorrente, )
        /// 3. OTTIENE IL NUOVO ID dal DATABASE!!
        /// 4. ritorna 0 se OK, negativo per errore
        /// </summary>EstrattiConto_IDContoCorrente
        /// <param name="cc"></param>
        /// <returns></returns>
        public static int InserimentoContoCorrente(ContoCorrente cc)
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
        public static int InserimentoOperazione(Operazione o, bool force_update)
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
        public static int InserimentoEstrattoConto(EstrattoConto ec)
        {
            return 0;
        }



        private static string TabellaOperazioni = "OPERAZIONI_";
        private static string TabellaEstrattoConto = "ESTRATTICONTO_";





        /// <summary>
        ///  Converte una sequenza di byte in stringa con codifica UTF8
        /// </summary>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static String UTF8ByteArrayToString(Byte[] characters)
        {

            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }
     
   
        /*
         *  DESERIALIZZAZIONE
         * byte[] byteArray = Encoding.UTF8.GetBytes(dr["ImpostazioniDietaDaElaborare"].ToString());
                        MemoryStream stream = new MemoryStream(byteArray);

                        XmlSerializer s = new XmlSerializer(typeof(ImpostazioniDietaDaElaborare));
                        TextReader r = new StreamReader(stream);

                        ImpostazioniDieta = (ImpostazioniDietaDaElaborare)s.Deserialize(r);
         * 
         */


        /* SERIALIZZAZIONE
         * XmlSerializer srO = new XmlSerializer(typeof(OpzioniStampa));
           MemoryStream mO = new MemoryStream();

           IFormatter ftO = new BinaryFormatter();
           srO.Serialize(mO, OpzStampa);



           string XmlizedStringO = UTF8ByteArrayToString(mO.ToArray());



           dr["OpzioniStampa"] = XmlizedStringO;
         * 
         */
    }
}
