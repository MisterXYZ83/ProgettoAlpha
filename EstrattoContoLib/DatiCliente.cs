using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrattoContoLib
{
    [Serializable]
    public class DatiCliente
    {
        #region campi privati

        private string _Cognome;
        private string _Nome;
         

        #endregion

        #region proprietà

        public string Cognome
        {
            get 
            {
                if (string.IsNullOrWhiteSpace(_Cognome))
                    _Cognome = "";

                return _Cognome;
            }
            set
            {
                _Cognome = value;
            }

        }
        public string Nome
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_Nome))
                    _Nome = "";
                return _Nome;
            }
            set
            {
                _Nome = value;
            }
        }
        #endregion

        public override string ToString()
        {
            return Cognome + " " + Nome;
        }
    }
}
