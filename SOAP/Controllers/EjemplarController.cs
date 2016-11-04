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

            using (EjemplarWSClient.IWSEjemplar cliente = new EjemplarWSClient.WSEjemplarClient()) {
                editoriales = cliente.GetAll();
            }
            // IList<Editorial> editoriales = eS.getAll();
            if (editoriales.Count() > 0) {
                resultado = View("Index", editoriales);
            } else {
                ViewBag.ErrorMessage("No hay editores en la BB.DD.");
                resultado = View("Index", editoriales);
            }
            return resultado;
        }

        //POST: Ejemplar/save
        [HttpPost]
        public ActionResult save(Ejemplar ejemplar) {
            ActionResult resultado = null;
            if (ModelState.IsValid) {
                if (ejemplar.CodEjemplar > -1) {
                    es.update(ejemplar);
                    ViewBag.Message = "El ejemplar se ha actualizado";
                } else {
                    es.create(ejemplar);
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
            Ejemplar ejemplar = null;
            //Libro libro = null;

            if (cod > 0) {
                ejemplar = es.getEjemplarById(cod);
                ViewBag.Message = "Editar Ejemplar";
                //libro = lS.getById(codLibro);
                //ejemplar.CodLibro = libro.CodLibro;
                //ejemplar.Titulo = libro.Titulo;
                //ejemplar.Autor = libro.Autor;
                resultado = View("Ejemplar", ejemplar);
            } else {
                ViewBag.Message = "Nuevo Ejemplar";
                ejemplar = new Ejemplar();
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
            if (es.getEjemplarById(cod) != null) {
                es.delete(cod);
                ViewBag.Message = "El ejemplar se ha borrado correctamente";
            }
            /*
             * Si pones View("") --> Lo mandas a la vista
             * Si pones RedirectToAction --> lo mandas al metodo del controlador
             */
            return RedirectToAction("Index");
        }
    }
}