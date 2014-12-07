using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrattoContoLib
{
    public class Operazione
    {
        private int _id;
        private int _idContoCorrente;
        private Guid _identificatore;

        private DateTime _dataValuta;
        private DateTime _dataOperazione;

        private float _dare;
        private float _avere;

        private string _descrizione;
        private string _riferimentiEstrattiConto;

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
        public Guid Identificatore
        {
            get
            {
                if (_identificatore == null)
                    _identificatore = Guid.NewGuid();

                return _identificatore;
            }
            set {_identificatore = value;}
        }

        public DateTime DataValuta
        {
            get{ return _dataValuta;}
            set {_dataValuta = value;}
        }
        public DateTime DataOperazione
        {
            get {return _dataOperazione;}
            set {_dataOperazione = value;}
        }

        public float Dare
        {
            get {return _dare;}
            set{_dare = value;}
        }
        public float Avere
        {
            get {return _avere;}
            set{_avere = value;}
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

        public string EstrattiConto
        {
            get 
            {
                if (string.IsNullOrWhiteSpace(_riferimentiEstrattiConto))
                    _riferimentiEstrattiConto = "";

                return _riferimentiEstrattiConto;
            }
            set
            {
                _riferimentiEstrattiConto = value;
            }
        }
        public List<string> RifEstrattiConto
        {
            get
            {
                string [] s = _riferimentiEstrattiConto.Split(';');
                List<string> l = new List<string>();

                for (int i = 0; i < s.Length; i++)
                    l.Add(s[i]);

                return l;
            }
        }

    }
}
