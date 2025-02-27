using Microsoft.AspNetCore.Mvc;
using RotinaDiaria.Models;
using RotinaDiaria.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RotinaDiaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompromissoController : ControllerBase
    {
        private readonly CompromissoRepository _compromissoRepository;

        public CompromissoController(CompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Compromisso>>> Get()
        {
            var compromissos = await _compromissoRepository.GetAllAsync();
            return Ok(compromissos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compromisso>> GetById(string id) // 🔥 Ajustado para string
        {
            var compromisso = await _compromissoRepository.GetByIdAsync(id);
            if (compromisso == null)
                return NotFound();

            return Ok(compromisso);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Compromisso compromisso)
        {
            await _compromissoRepository.CreateAsync(compromisso);
            return CreatedAtAction(nameof(GetById), new { id = compromisso.Id }, compromisso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Compromisso compromissoAtualizado) // 🔥 Ajustado para string
        {
            var compromissoExistente = await _compromissoRepository.GetByIdAsync(id);
            if (compromissoExistente == null)
                return NotFound();

            await _compromissoRepository.UpdateAsync(id, compromissoAtualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) // 🔥 Ajustado para string
        {
            var compromissoExistente = await _compromissoRepository.GetByIdAsync(id);
            if (compromissoExistente == null)
                return NotFound();

            await _compromissoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
