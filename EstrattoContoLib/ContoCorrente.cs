using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrattoContoLib
{
    public class ContoCorrente
    {
        private int _id;
        private int _idCliente;
        private string _iban;


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
        public string IBAN
        {
            get 
            {
                if (string.IsNullOrWhiteSpace(_iban))
                    _iban = "";

                return _iban;
            }
            set { _iban = value; }
        }

    }
}
