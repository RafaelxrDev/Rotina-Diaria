using Microsoft.AspNetCore.Mvc;
using RotinaDiaria.Models;
using System.Collections.Generic;


namespace  RotinaDiaria.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class CompromissoController : ControllerBase
    {
        private static List<Compromissos> compromissos = new List<Compromissos>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(compromissos);
        }

        [HttpPost]
        public IActionResult Post(Compromissos compromisso)
        {
            compromisso.Id = compromisso.Count + 1;
            compromissos.Add(compromisso);
            return CreatedAtAction(nameof(Get), new {id = compromisso.Id}, compromisso);
        }



    } 


}