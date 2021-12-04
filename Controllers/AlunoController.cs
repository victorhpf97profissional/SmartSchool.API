using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var alunoEncontrado = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (alunoEncontrado == null) return BadRequest("O Aluno não foi encontrado");
            return Ok(alunoEncontrado);
        }


        //api/aluno/byName?nome=Pedro&sobreNome=Ferreira
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var alunoEncontrado = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.SobreNome.Contains(sobrenome));
            if (alunoEncontrado == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(alunoEncontrado);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoEncontrado = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alunoEncontrado == null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alunoEncontrado = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (alunoEncontrado == null) return BadRequest("Aluno não encontrado");
            _context.Remove(alunoEncontrado);
            _context.SaveChanges();
            return Ok();
        }
    }



}