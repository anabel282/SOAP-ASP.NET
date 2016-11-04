using SOAP.BBLL.interfaces;
using SOAP.DAL;
using SOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP.BBLL {
    public class EjemplarServiceImp : EjemplarService {
        private EjemplarRepositoryImp eR;

        public EjemplarServiceImp() {
            eR = new EjemplarRepositoryImp();
        }
        public Ejemplar create(Ejemplar ejemplar) {
            return eR.create(ejemplar);
        }

        public void delete(int codigoEjemplar) {
            eR.delete(codigoEjemplar);
        }

        public IList<Ejemplar> getAll() {
            return eR.getAll();
        }

        public IList<Ejemplar> getByIdDeLibro(int codLibro) {
            return eR.getByIdDeLibro(codLibro);
        }

        public Ejemplar getEjemplarById(int codigoEjemplar) {
            return eR.getById(codigoEjemplar);
        }

        public Ejemplar update(Ejemplar ejemplar) {
            return eR.update(ejemplar);
        }
    }
}