using SOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP.BBLL.interfaces {


    public interface EditorialService {
        Editorial getById(int codigoEditorial);

        Editorial create(Editorial editorial);

        Editorial update(Editorial editorial);

        void delete(int codigoEditorial);

        IList<Editorial> getAll();
    }
}
