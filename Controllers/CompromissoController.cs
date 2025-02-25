using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RotinaDiaria.Models;
using System.Collections.Generic;

namespace RotinaDiaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompromissoController : ControllerBase
    {
        private static List<Compromisso> compromissos = new List<Compromisso>(); 

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(compromissos);
        }

        [HttpPost]
        public IActionResult Post(Compromisso compromisso)  
        {
            compromisso.Id = compromissos.Count + 1;
            compromissos.Add(compromisso);
            return CreatedAtAction(nameof(Get), new { id = compromisso.Id }, compromisso);
        }

        [HttpPut]
        public IActionResult Put (int Id, Compromisso compromissoAtualizado)

        
        {
            var compromisso = compromissos.FirstOrDefault(c => c.Id == Id);

            if (compromisso == null) return NotFound();

            compromisso.Nome = compromissoAtualizado.Nome;
            compromisso.Tipo = compromissoAtualizado.Tipo;
            compromisso.Hora = compromissoAtualizado.Hora;
            compromisso.Duracao = compromissoAtualizado.Duracao;


            return NoContent();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var compromisso = compromissos.FirstOrDefault(c => c.Id ==Id);
            if (compromisso == null) return NotFound();

            compromissos.Remove(compromisso);
            return NoContent();
        }
    }
}
