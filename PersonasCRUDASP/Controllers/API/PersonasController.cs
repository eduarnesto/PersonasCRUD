using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonasCRUDASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasAPI>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            try
            {
                List <ClsPersona> listadoCompleto = ClsListadosBL.ListadoCompletoPersonasBL();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;

        }

        // GET api/<PersonasAPI>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            try
            {
                ClsPersona persona = ClsManejadoraBL.buscarPersonaPorId(id);
                if (persona.nombre == "")
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(persona);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<PersonasAPI>
        [HttpPost]
        public IActionResult Post([FromBody] ClsPersona persona)
        {
            int filasAfectadas;
            IActionResult salida;
            if (persona.nombre == "")
            {
                salida = BadRequest();
            }
            else
            {
                try
                {
                    filasAfectadas = ClsManejadoraBL.agregarPersona(persona);
                    if (filasAfectadas == 0)
                    {
                        salida = BadRequest();
                    }
                    else
                    {
                        salida = Ok(filasAfectadas);
                    }
                }
                catch
                {
                    salida = BadRequest();
                }
            }
            return salida;
        }

        // PUT api/<PersonasAPI>/5
        [HttpPut("{id}")]
        public IActionResult Put(ClsPersona persona)
        {
            int filasAfectadas;
            IActionResult salida;
            if (persona.nombre == "")
            {
                salida = BadRequest();
            }
            else
            {
                try
                {
                    filasAfectadas = ClsManejadoraBL.modificarPersona(persona);
                    if (filasAfectadas == 0)
                    {
                        salida = BadRequest();
                    }
                    else
                    {
                        salida = Ok(filasAfectadas);
                    }
                }
                catch
                {
                    salida = BadRequest();
                }
            }
            return salida;
        }

        // DELETE api/<PersonasAPI>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int numFilasAfectadas;

            try
            {
                numFilasAfectadas = ClsManejadoraBL.eliminarPersona(id);
                if (numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(numFilasAfectadas);
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;

        }
    }
}