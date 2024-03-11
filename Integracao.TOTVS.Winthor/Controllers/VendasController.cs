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
        private readonly IContasPagarServices _contasPagarServices;

        public VendasController(IVendasServices vendasService, IContasPagarServices contasPagarServices)
        {
            _vendasService = vendasService;
            _contasPagarServices = contasPagarServices;
        }

        [HttpPost("editar-fornecedor-frete")]
        public async Task<ActionResult<ContasPagar>> EditarFornecedorFrete(int recNum, int codFornec)
        {
            try
            {
                var response = _contasPagarServices.EditarFornecedorFrete(recNum, codFornec);
                if (response.Result == null)
                    return NotFound("Fornecedor ou contas a pagar não encontrados");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("vendas-por-vendedor")]
        public async Task<ActionResult<VendasPorVendedor>> VendasPorVendedor(string data)
        {
            try
            {
                var response = await _vendasService.VendasPorVendendorAsync(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}