using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.data;
using SmartSchool.API.Models;
using Microsoft.EntityFrameworkCore;
namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase

    {

        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {

            var professorEncontrado = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professorEncontrado == null) return BadRequest("Professor não encontrado");
            return Ok(professorEncontrado);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var professorEncontrado = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if (professorEncontrado == null) return BadRequest("Professor não encontrado");
            return Ok(professorEncontrado);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {

            var professorEncontrado = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professorEncontrado == null) return BadRequest("Professor não encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var professorEncontrado = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professorEncontrado == null) return BadRequest("Professor não encontrado");
            _context.Remove(professorEncontrado);
            _context.SaveChanges();
            return Ok();
        }
    }
}