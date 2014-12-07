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
        public DatiCliente DatiGenarali
        {
            get { return _datiGenerali; }
            set { _datiGenerali = value; }

        }
        #endregion

        public override string ToString()
        {
            return DatiGenarali.ToString() ;
        }
    }
}
