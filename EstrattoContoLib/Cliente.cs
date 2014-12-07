using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrattoContoLib
{
    public class Cliente
    {
        #region campi

        private int _id;
        private EnumTipoCliente _tipo;
        private DatiCliente _datiGenerali;
        private string _Cognome;
        private string _Nome;

        #endregion

        #region proprietà

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public EnumTipoCliente Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

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

        public DatiCliente DatiGenarali
        {
            get { return _datiGenerali; }
            set { _datiGenerali = value; }

        }
        #endregion

        public override string ToString()
        {
            return _Nome + " " + _Cognome;
        }
    }
}
