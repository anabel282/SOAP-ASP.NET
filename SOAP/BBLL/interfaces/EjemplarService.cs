using SOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP.BBLL.interfaces {
    public interface EjemplarService {

        IList<Ejemplar> getAll();
        Ejemplar getEjemplarById(int codigoEjemplar);
        Ejemplar create(Ejemplar ejemplar);
        Ejemplar update(Ejemplar ejemplar);
        void delete(int codigoEjemplar);
        IList<Ejemplar> getByIdDeLibro(int codLibro);
    }
}
