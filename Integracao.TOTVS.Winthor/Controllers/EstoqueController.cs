using Integracao.TOTVS.Winthor.Domain.Interfaces.Services;
using Integracao.TOTVS.Winthor.Entitys.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.TOTVS.Winthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueServices _services;

        public EstoqueController(IEstoqueServices services)
        {
            _services = services;
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<VendasPorVendedor>> Buscar(string filial)
        {
            try
            {
                var response = await _services.BuscarEstoqueAsync(filial);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}