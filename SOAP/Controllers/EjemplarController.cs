using SOAP.BBLL;
using SOAP.BBLL.interfaces;
using SOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOAP.Controllers
{
    public class EjemplarController : Controller {
        private EjemplarService es;
        //private LibroServiceImp lS;

        public EjemplarController() {
            es = new EjemplarServiceImp();
            //lS = new LibroServiceImp();
        }
        // GET: Ejemplar
        [HttpGet]
        public ActionResult Index() {
            ActionResult paginaRedirect = null;
            IList<EjemplarWSClient.WSEjemplarModel> ejemplares = null;

            using (EjemplarWSClient.WSEjemplarClient cliente = new EjemplarWSClient.WSEjemplarClient()) {
                ejemplares = cliente.GetAll();
            }
            // IList<Editorial> editoriales = eS.getAll();
            if (ejemplares.Count() > 0) {
                paginaRedirect = View("Index", ejemplares);
            } else {
                ViewBag.ErrorMessage("No hay editores en la BB.DD.");
                paginaRedirect = View("Index", ejemplares);
            }
            return paginaRedirect;
        }

        //POST: Ejemplar/save
        [HttpPost]
        public ActionResult save(EjemplarWSClient.WSEjemplarModel ejemplar) {
            ActionResult resultado = null;
            if (ModelState.IsValid) {
                if (ejemplar.ISBN != null) {
                    //es.update(ejemplar);
                    using (EjemplarWSClient.WSEjemplarClient cliente = new EjemplarWSClient.WSEjemplarClient()) {
                        cliente.Update(ejemplar);
                    }
                    ViewBag.Message = "El ejemplar se ha actualizado";
                } else {
                    //es.create(ejemplar);
                    using (EjemplarWSClient.WSEjemplarClient cliente = new EjemplarWSClient.WSEjemplarClient()) {
                        cliente.Create(ejemplar);
                    }
                    ViewBag.Message = "El ejemplar se ha creado con éxito";
                }
                resultado = RedirectToAction("Index");
            } else {
                resultado = View(ejemplar);
            }
            return resultado;
        }

        //GET : Ejemplar/createUpdate
        public ActionResult createUpdate(int codLibro, int cod = -1) {
            ActionResult resultado = null;
            EjemplarWSClient.WSEjemplarModel ejemplar = null;
            //Libro libro = null;

            if (cod > 0) {
                using (EjemplarWSClient.WSEjemplarClient cliente = new EjemplarWSClient.WSEjemplarClient()) {
                    ejemplar = cliente.GetById(cod);
                }
                ViewBag.Message = "Editar Ejemplar";
                //libro = lS.getById(codLibro);
                //ejemplar.CodLibro = libro.CodLibro;
                //ejemplar.Titulo = libro.Titulo;
                //ejemplar.Autor = libro.Autor;
                resultado = View("Ejemplar", ejemplar);
            } else {
                ViewBag.Message = "Nuevo Ejemplar";
                ejemplar = new EjemplarWSClient.WSEjemplarModel();
                //ejemplar.CodLibro = libro.CodLibro;
                //ejemplar.Titulo = libro.Titulo;
                //ejemplar.Autor = libro.Autor;
                //libro = lS.getById(codLibro);
                resultado = View("Ejemplar", ejemplar);
            }
            return resultado;
        }

        //GET: Ejemplar/Delete/5
        public ActionResult delete(int cod) {
            using (EjemplarWSClient.WSEjemplarClient cliente = new EjemplarWSClient.WSEjemplarClient()) {
                if (cliente.GetById(cod) != null) {
                    cliente.Delete(cod);
                    ViewBag.Message = "El ejemplar se ha borrado correctamente";
                }
            }
            
            /*
             * Si pones View("") --> Lo mandas a la vista
             * Si pones RedirectToAction --> lo mandas al metodo del controlador
             */
            return RedirectToAction("Index");
        }
    }
}