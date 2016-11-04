using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAP.Models;
using SOAP.BBLL.interfaces;
using SOAP.BBLL;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WSEjemplar" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WSEjemplar.svc o WSEjemplar.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WSEjemplar : IWSEjemplar {

        private EjemplarService eS = null;

        public WSEjemplar() {
            eS = new EjemplarServiceImp();
        }

        public string Create(WSEjemplarModel WSEjemplarModel) {
            Ejemplar ejemplar = parseWSModel(WSEjemplarModel);
            Ejemplar ejemplarDev = eS.create(ejemplar);
            string response = null;
            if (ejemplarDev != null) {
                response = "Se ha creado con exito";
            } else {
                response = "No se ha creado con exito";
            }
            return response;
        }

        public void Delete(int codEjemplar) {
            eS.delete(codEjemplar);
        }

        public IList<WSEjemplarModel> GetAll() {
            IList<Ejemplar> ejemplares = eS.getAll();
            IList<WSEjemplarModel> WSEjemplares = new List<WSEjemplarModel>();
            WSEjemplarModel wsejemplarModel = new WSEjemplarModel();
            foreach(Ejemplar ej in ejemplares){
                wsejemplarModel = parseModelWS(ej);
                WSEjemplares.Add(wsejemplarModel);
            }
            return WSEjemplares;

        }

        public WSEjemplarModel GetById(int codEjemplar) {
            Ejemplar ejemplar = eS.getEjemplarById(codEjemplar);
            WSEjemplarModel wsejemplar = null;
            wsejemplar = parseModelWS(ejemplar);
            return wsejemplar;
        }

        public string Update(WSEjemplarModel WSEjemplarModel) {
            Ejemplar ejemplar = null;
            Ejemplar ejemplarDev = null;
            ejemplar = parseWSModel(WSEjemplarModel);
            ejemplarDev = eS.update(ejemplar);
            string response = null;
            if (ejemplarDev != null) {
                response = "Se ha actualizado con exito";
            } else {
                response = "No se ha actualizado con exito";
            }
            return response;
        }

        private Ejemplar parseWSModel(WSEjemplarModel WSEjemplarModel) {

            Ejemplar ejemplar = new Ejemplar();
            ejemplar.FPublicacion = WSEjemplarModel.FPublicacion;
            ejemplar.ISBN = WSEjemplarModel.ISBN;
            ejemplar.NumPaginas = WSEjemplarModel.NumPaginas;
            return ejemplar;
        }

        private WSEjemplarModel parseModelWS(Ejemplar ejemplar) {
            WSEjemplarModel WSEjemplarModel = new WSEjemplarModel();
            WSEjemplarModel.FPublicacion = ejemplar.FPublicacion;
            WSEjemplarModel.ISBN = ejemplar.ISBN;
            WSEjemplarModel.NumPaginas = ejemplar.NumPaginas;
            return WSEjemplarModel;
        }
    }
}
