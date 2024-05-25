using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppClienteMVCGMingenieros.Models;
using Microsoft.EntityFrameworkCore;
namespace AppClienteMVCGMingenieros.Controllers
{
   
    public class ComprobantesController : Controller
    {
        private readonly DatadecomprasgmContext bd;
        public ComprobantesController(DatadecomprasgmContext _contexto)
        {
            bd = _contexto;
        }

        // GET: ComprobantesController
        public ActionResult IndexComprobantes()
        {
            var comprobantes = bd.Comprobantes.ToList();
            return View(comprobantes);
        }


        public ActionResult Details(int id)
        {
            var comprobante = bd.Comprobantes.FirstOrDefault(c => c.Idcomprobante == id);
            if (comprobante == null)
            {
                return NotFound(); 
            }
            return View(comprobante);
        }


        // GET: ComprobantesController/Create
        public ActionResult CreateComprobante()
        {
            Comprobante nuevo = new Comprobante();
         
            return View(nuevo);
        }

        // POST: ComprobantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComprobante(Comprobante obj)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    bd.Comprobantes.Add(obj); // lo graba en la memoria
                    bd.SaveChanges(); // lo graba en la BD
                    TempData["mensaje"] = "Nuevo Comprobante registrado correctamente";
                    return RedirectToAction(nameof(IndexComprobantes));
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            
            return View();
        }
        public ActionResult EditComprobantes(int id)
        {
            var comprobante = bd.Comprobantes.FirstOrDefault(c => c.Idcomprobante == id);
            if (comprobante == null)
            {
                return NotFound(); // Otra vista para mostrar un mensaje de "no encontrado"
            }
            return View(comprobante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComprobantes(int id, Comprobante comprobanteEditado)
        {
            var comprobante = bd.Comprobantes.FirstOrDefault(c => c.Idcomprobante == id);
            if (comprobante == null)
            {
                return NotFound(); // Otra vista para mostrar un mensaje de "no encontrado"
            }

            // Actualiza los campos del comprobante con los valores del comprobanteEditado
            
            comprobante.Fecha = comprobanteEditado.Fecha;
            comprobante.Numerodocumento = comprobanteEditado.Numerodocumento;
            comprobante.Ruc = comprobanteEditado.Ruc;
            comprobante.Razonsocial = comprobanteEditado.Razonsocial;
            comprobante.Concepto = comprobanteEditado.Concepto;
            comprobante.Moneda = comprobanteEditado.Moneda;
            comprobante.Importe = comprobanteEditado.Importe;
            comprobante.Tipodocumento = comprobanteEditado.Tipodocumento;
            comprobante.Emitidorecibido = comprobanteEditado.Emitidorecibido;
            // ... (continúa con las demás propiedades)

            bd.SaveChanges(); // Guarda los cambios en la base de datos

            return RedirectToAction(nameof(IndexComprobantes));
        }


        // GET: ComprobantesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComprobantesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComprobante(int id, IFormCollection collection)
        {
            try
            {
                Comprobante buscado = bd.Comprobantes.FirstOrDefault(x => x.Idcomprobante == id)!;
              
                //db.TbEmpleados.Remove(buscado);  // 
                bd.SaveChanges();
                //
                TempData["mensaje"] = "Comprobante Eliminado correctamente";
                //
                return RedirectToAction(nameof(IndexComprobantes));
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            //
            return View();
        }
    }
}
