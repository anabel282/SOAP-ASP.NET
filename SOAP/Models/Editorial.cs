using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP.Models {
    public class Editorial {

        private int codEditorial;
        private string nombre;

        public Editorial() {
            this.codEditorial = -1;
            this.nombre = "";
        }

        public int CodEditorial {
            get {
                return codEditorial;
            }

            set {
                codEditorial = value;
            }
        }
        
        public string Nombre {
            get {
                return nombre;
            }

            set {
                nombre = value;
            }
        }
    }
}