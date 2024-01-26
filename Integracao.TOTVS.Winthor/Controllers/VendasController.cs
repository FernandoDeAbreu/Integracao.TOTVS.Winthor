using Integracao.TOTVS.Winthor.Domain.Interfaces.Services;
using Integracao.TOTVS.Winthor.Entitys.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.TOTVS.Winthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendasServices _vendasService;

        public VendasController(IVendasServices vendasService)
        {
            _vendasService = vendasService;
        }

        [HttpGet("vendas-por-vendedor")]
        public async Task<ActionResult<VendasPorVendedor>> VendasPorVendedor(string data)
        {
            try
            {
                var response = _vendasService.VendasPorVendendorAsync(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}