using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrattoContoLib
{
    public class EstrattoConto
    {
        private int _id;
        private int _idContoCorrente;
        private DateTime _data;
        private string _riferimentoOperazioni;
        private string _descrizione;
        private List<Operazione> _listOperazioni;


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int IdContoCorrente
        {
            get { return _idContoCorrente; }
            set { _idContoCorrente = value; }
        }
        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public string Descrizione
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_descrizione))
                    _descrizione = "";

                return _descrizione;
            }
            set
            {
                _descrizione = value;
            }
        }

        public List<Operazione> ListaOperazioni
        {
            get { return _listOperazioni; }
            set { _listOperazioni = value; }
        }
        public string RiferimentoOperazioni
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_riferimentoOperazioni))
                {
                    _riferimentoOperazioni = "";
                    foreach (Operazione o in _listOperazioni)
                    {
                        if (o != null && o.ID != 0)
                            _riferimentoOperazioni += o.ID.ToString() + ";";
                    }
                    if (_riferimentoOperazioni.Length > 1)
                        _riferimentoOperazioni = _riferimentoOperazioni.Remove(_riferimentoOperazioni.Length - 2, 1);

                }
                return _riferimentoOperazioni;
            }
            set
            {
                _riferimentoOperazioni = value;
            }
        }
    }
}
