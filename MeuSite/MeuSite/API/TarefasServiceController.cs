using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MeuSite.Data;
using Microsoft.EntityFrameworkCore;

namespace MeuSite.API
{
    [Produces("application/json")]
    [Route("api/TarefasService")]
    public class TarefasServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarefasServiceController(ApplicationDbContext context)
        {
            _context = context;
        }
             
    [HttpGet]

        public async Task<IActionResult> Get(bool todas = true)
        {
            List<Models.Tarefa> tarefas;
            if (todas)
            {
                tarefas = await _context.Tarefas.ToListAsync();
            }
            else
            {
                tarefas = await _context.Tarefas.Where(p => p.Finalizado == false).ToListAsync();
            }

            return Ok(tarefas);

        } 
    
    [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.Tarefa tarefa) //aqui recebe uma parefa e vai posta no banco d dados
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return Created("api/tarefasservice",tarefa);

        }
    
    [HttpDelete]
    [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

            return NoContent();
        }
    }
}