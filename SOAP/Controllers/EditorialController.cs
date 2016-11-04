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

    [Authorize(Roles = "Admin")]
    public class EditorialController : Controller {
        private EditorialService eS;
        public EditorialController() {
            eS = new EditorialServiceImp();
        }
        // GET: Editorial
        [HttpGet]
        public ActionResult Index() {
            ActionResult resultado = null;
            IList<WSEditorialOLD.WSEditorial> editoriales;
            using(WSEditorialOLD.WSEditorialOLD cliente = new WSEditorialOLD.WSEditorialOLD()) {
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

        // GET Editorial/CreateUpdate
        [HttpGet]
        public ActionResult createUpdate(int codEditorial = -1) {

            WSEditorialOLD.WSEditorial editorial = null;

            if (codEditorial < 0) {
                ViewBag.Title = "Editorial nuevo";
                editorial = new WSEditorialOLD.WSEditorial();
                using (WSEditorialOLD.WSEditorialOLD cliente = new WSEditorialOLD.WSEditorialOLD()) {
                    editorial = cliente.Create(editorial);
                }
            } else {
                ViewBag.Title = "Editar editorial";
                //editorial = eS.getById(codEditorial);
                using (WSEditorialOLD.WSEditorialOLD cliente = new WSEditorialOLD.WSEditorialOLD()) {
                    editorial = cliente.Update(editorial);
                }
            }

            return View("Editorial", editorial);
        }
        [HttpPost]
        //POST: Editorial/Save
        public ActionResult save(WSEditorialOLD.WSEditorial editorial) {
            ActionResult resultado = null;
            if (ModelState.IsValid) {
                if (editorial.nombre != null) {
                    try {
                        using (WSEditorialOLD.WSEditorialOLD cliente = new WSEditorialOLD.WSEditorialOLD()) {
                            cliente.Update(editorial);
                        }
                        //eS.update(editorial);
                        ViewBag.Message = "La editorial se ha actualizado con exito";
                    } catch (Exception ex) {
                        
                        ViewBag.ErrorMessage = "Algo ha salido mal: " + ex.Message;
                    }
                } else {
                    //eS.create(editorial);
                    using (WSEditorialOLD.WSEditorialOLD cliente = new WSEditorialOLD.WSEditorialOLD()) {
                        cliente.Create(editorial);
                    }
                    ViewBag.Message = "La editorial se ha creado con exito";
                }

                resultado = RedirectToAction("Index");
            } else {
                resultado = View("Editorial", editorial);
            }
            return resultado;
        }
        // GET: Editorial/Delete
        [HttpGet]
        public ActionResult delete(int codEditorial) {
            //eS.delete(codEditorial);
            using (WSEditorialOLD.WSEditorialOLD cliente = new WSEditorialOLD.WSEditorialOLD()) {
                cliente.Delete(codEditorial);
            }
            return RedirectToAction("index");
        }
    }
}