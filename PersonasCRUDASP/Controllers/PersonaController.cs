using BL;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonasCRUDASP.Models;

namespace PersonasCRUDASP.Controllers
{
    public class PersonaController : Controller
    {
        // GET: PersonaController
        public ActionResult Index()
        {
            ClsListadoPersonaConNombreDepartamento personas = new ClsListadoPersonaConNombreDepartamento();
            try
            {

            }
            catch (Exception ex)
            {
                //TODO Pagina de error
            }
            return View(personas.PersonasConNombreDept);
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
        public ActionResult Edit(ClsPersona personaNueva)
        {
            string pagina = "";
            try
            {
                ClsManejadoraBL.modificarPersona(personaNueva);
                pagina = "Index";
            }
            catch (Exception ex)
            {
                pagina = "Error";
            }
            return RedirectToAction(pagina);
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
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

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClsPersona persona)
        {
            string pagina = "";
            try
            {
                ClsManejadoraBL.eliminarPersona(persona.id);
                pagina = "Index";
            }
            catch (Exception ex)
            {
                pagina = "Error";
            }
            return RedirectToAction(pagina);
        }
    }
}
