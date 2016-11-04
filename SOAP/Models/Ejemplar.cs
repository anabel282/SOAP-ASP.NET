using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP.Models {
    public class Ejemplar {

        private int _codEjemplar;
        private string _iSBN;
        private int _numPaginas;
        private DateTime _fPublicacion;

        public Ejemplar() {
            this._codEjemplar = -1;
            this._iSBN = "";
            this._numPaginas = 0;
            this._fPublicacion = new DateTime();
        }

        public int CodEjemplar {
            get {
                return _codEjemplar;
            }

            set {
                _codEjemplar = value;
            }
        }

        public string ISBN {
            get {
                return _iSBN;
            }

            set {
                _iSBN = value;
            }
        }

        public int NumPaginas {
            get {
                return _numPaginas;
            }

            set {
                _numPaginas = value;
            }
        }

        public DateTime FPublicacion {
            get {
                return _fPublicacion;
            }

            set {
                _fPublicacion = value;
            }
        }
    }
}
