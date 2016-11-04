using SOAP.BBLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAP.Models;
using SOAP.DAL.interfaces;
using SOAP.DAL;

namespace SOAP.BBLL {
    public class EditorialServiceImp : EditorialService {
        private EditorialRepository ed;

        public EditorialServiceImp() {
            this.ed = new EditorialRepositoryImp();
        }

        public Editorial create(Editorial editorial) {
            ed.create(editorial);
            return editorial;
        }

        public void delete(int codigoEditorial) {
            ed.delete(codigoEditorial);
        }

        public IList<Editorial> getAll() {
            IList<Editorial> editoriales = ed.getAll();
            return editoriales;
        }

        public Editorial getById(int codigoEditorial) {
            Editorial editoriales = ed.getById(codigoEditorial);
            return editoriales;
        }

        public Editorial update(Editorial editorial) {
            ed.update(editorial);
            return editorial;
        }
    }
}
