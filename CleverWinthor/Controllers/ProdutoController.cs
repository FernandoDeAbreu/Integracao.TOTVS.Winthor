using Integracao.TOTVS.Winthor.Api.Controllers.Common;
using Integracao.TOTVS.Winthor.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.TOTVS.Winthor.Api.Controllers;

[Route("api/produto")]
[ApiController]
public class ProdutoController : CleverControllerBase
{
    private readonly ILogger<ProdutoController> _logger;
    private readonly IProdutoService _ProdutoService;

    public ProdutoController(ILogger<ProdutoController> logger, IProdutoService ProdutoService)
    {
        _logger = logger;
        _ProdutoService = ProdutoService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            _logger.LogInformation("Processando a solicitação do método Get.");
            var data = await _ProdutoService.ObterProdutoAsync(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }
        catch (Exception ex)
        {
            return CustomError(ex);
        }
    }

    [HttpGet("{fornecedorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetProtudoByFilter(int fornecedorId)
    {
        try
        {
            _logger.LogInformation("Processando a solicitação do método Get.");
            var data = await _ProdutoService.ObterProdutoByFilterAsync(fornecedorId);
            if (data == null)
                return NotFound();

            return Ok(data);
        }
        catch (Exception ex)
        {
            return CustomError(ex);
        }
    }
}