using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EF_Fiap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var livros = _livroRepository.ObterTodos();
                return Ok(livros);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                var livro = _livroRepository.ObterPorId(id);
                if (livro == null)
                    return NotFound();
                return Ok(livro);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        [HttpPost]
        public IActionResult Post([FromBody] LivroInput input)
        {
            try
            {
                var livro = new Livro()
                {
                    Nome = input.Nome,
                    Editora = input.Editora
                };

                _livroRepository.Cadastrar(livro);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPut()]
        public IActionResult Put([FromBody] LivroUpdateInput input)
        {
            try
            {
                var livro = _livroRepository.ObterPorId(input.Id);
                if (livro == null)
                    return NotFound();
                livro.Nome = input.Nome;
                livro.Editora = input.Editora;
                _livroRepository.Alterar(livro);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
               _livroRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
