using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Context;

namespace atendimentoEmpresaMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> Get()
        {
            try
            {
                var enderecos = _context.Enderecos.AsNoTracking().ToList();

                if (enderecos == null || enderecos.Count == 0)
                {
                    return NotFound("Endereços Não Encontrados");
                }

                return enderecos;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Endereco> Get(int id)
        {
            try
            {
                var endereco = _context.Enderecos.AsNoTracking().FirstOrDefault(e => e.EnderecoID == id);

                if (endereco == null)
                {
                    return NotFound("Endereço não encontrado.");
                }

                return endereco;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Endereco endereco)
        {
            try
            {
                if (endereco == null)
                {
                    return BadRequest("Endereço inválido.");
                }

                _context.Enderecos.Add(endereco);
                _context.SaveChanges();

                return CreatedAtAction("Get", new { id = endereco.EnderecoID }, endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Endereco endereco)
        {
            try
            {
                if (id != endereco.EnderecoID)
                {
                    return BadRequest("ID do Endereço não corresponde ao ID na requisição.");
                }

                _context.Entry(endereco).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok("Endereço atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var endereco = _context.Enderecos.FirstOrDefault(
                    e => e.EnderecoID == id
                );

                if (endereco == null)
                {
                    return NotFound("Endereço não encontrado.");
                }

                _context.Enderecos.Remove(endereco);
                _context.SaveChanges();

                return Ok("Endereço excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua Solicitação. Favor tentar novamente mais tarde");
            }
        }
    }
}
