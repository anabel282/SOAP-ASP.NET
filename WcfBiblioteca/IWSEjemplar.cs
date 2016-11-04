using SOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWSEjemplar" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWSEjemplar {
        [OperationContract]
        string Create(WSEjemplarModel WSEjemplarModel);

        [OperationContract]
        string Update(WSEjemplarModel WSEjemplarModel);

        [OperationContract]
        void Delete(int codEjemplar);

        [OperationContract]
        IList<WSEjemplarModel> GetAll();

        [OperationContract]
        WSEjemplarModel GetById(int codEjemplar);
    }

    [DataContract]
    public class WSEjemplarModel {

        private string _iSBN;
        private int _numPaginas;
        private DateTime _fPublicacion;

        [DataMember]
        public string ISBN {
            get {
                return _iSBN;
            }

            set {
                _iSBN = value;
            }
        }

        [DataMember]
        public int NumPaginas {
            get {
                return _numPaginas;
            }

            set {
                _numPaginas = value;
            }
        }

        [DataMember]
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
