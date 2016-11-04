using SOAP.BBLL;
using SOAP.BBLL.interfaces;
using SOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WcfBiblioteca {
    [WebService(Namespace = "http://formacion-ipartek.com/")]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSEditorialOLD : System.Web.Services.WebService {

        private EditorialService eS = null;

        public WSEditorialOLD() {
            eS = new EditorialServiceImp();
        }

        [WebMethod]
        public string Create(WSEditorial WSEditorial) {
            Editorial editorial = parseWSModel(WSEditorial);
            Editorial editorialDv = eS.create(editorial);
            string response = null;
            if (editorialDv != null) {
                response = "Se ha creado correctamente";
            } else {
                response = "No se ha creado";
            }
            return response;
        }
        [WebMethod]
        public string Update(WSEditorial WSEditorial) {
            Editorial editorial = parseWSModel(WSEditorial);
            string response = null;
            Editorial editorialDV =  eS.update(editorial);
            if (editorialDV != null) {
                response = "Se ha modificado correctamente";
            } else {
                response = "no se ha creado correctamente";
            }
            return response;
        }
        [WebMethod]
        public void Delete(int codEditorial) {
            eS.delete(codEditorial);
        }
        [WebMethod]
        public List<WSEditorial> GetAll() {
            IList<Editorial> editoriales = eS.getAll();
            List<WSEditorial> WSeditoriales = new List<WSEditorial>();
            WSEditorial wsEditorial = null;
            foreach (Editorial ed in editoriales) {
                wsEditorial = parseModelWS(ed);
                WSeditoriales.Add(wsEditorial);
            }
            return WSeditoriales;
        }
        [WebMethod]
        public WSEditorial GetById(int codEditorial) {
            Editorial editorial = eS.getById(codEditorial);
            WSEditorial wsEditorial = new WSEditorial();
            wsEditorial = parseModelWS(editorial);
            return wsEditorial;
        }
        private Editorial parseWSModel(WSEditorial WSEditorial) {
            Editorial editorial = new Editorial();
            editorial.Nombre = WSEditorial.nombre;
            return editorial;
        }
        private WSEditorial parseModelWS(Editorial editorial) {
            WSEditorial wSEditorial = new WSEditorial();
            wSEditorial.nombre = editorial.Nombre;
            return wSEditorial;
        }
    }
}
