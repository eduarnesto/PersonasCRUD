using BL;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonasCRUDASP.Controllers
{
    public class PersonaController : Controller
    {
        // GET: PersonaController
        public ActionResult Index()
        {
            List<ClsPersona> list = new List<ClsPersona>();
            try
            {
                list = ClsListadosBL.ListadoCompletoPersonasBL();
            }
            catch (Exception ex)
            {
                //TODO Pagina de errror
            }
            return View(list);
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            ClsPersona persona = new ClsPersona();
            try
            {
                persona = ClsManejadoraBL.buscarPersonaPorId(id);
            }
            catch (Exception ex)
            {
                //TODO Pagina de error
            }
            return View(persona);
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClsPersona persona)
        {
            try
            {
                ClsManejadoraBL.agregarPersona(persona);
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            ClsPersona persona = new ClsPersona();
            try
            {
                persona = ClsManejadoraBL.buscarPersonaPorId(id);
            }
            catch (Exception ex)
            {
                //TODO Pagina de error
            }
            return View(persona);
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
