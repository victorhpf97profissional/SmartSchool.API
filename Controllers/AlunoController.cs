using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
        new Aluno(){
            Id = 1,
            Nome = "Pedro",
            SobreNome = "Ferreira",
            Telefone = "981249303"
        },
         new Aluno(){
            Id = 2,
            Nome = "Jõao",
            SobreNome = "Ferreira",
            Telefone = "981249303"
        }
    };

        public AlunoController() { }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }


        //api/aluno/byName?nome=Pedro&sobreNome=Ferreira
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.SobreNome.Contains(sobrenome));
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

            return Ok(aluno);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok();
        }
    }

}