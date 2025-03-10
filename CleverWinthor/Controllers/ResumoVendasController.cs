﻿using Integracao.TOTVS.Winthor.Api.Controllers.Common;
using Integracao.TOTVS.Winthor.Domain.Services;
using Integracao.TOTVS.Winthor.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.TOTVS.Winthor.Api.Controllers;

[Route("api/resumo-vendas")]
[ApiController]
public class ResumoVendasController : CleverControllerBase
{
    private readonly IResumoVendasService _resumoVendasService;

    public ResumoVendasController(ILogger<ResumoVendasController> logger, IResumoVendasService resumoVendasService)
    {
        _resumoVendasService = resumoVendasService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ObterVendasPorEvolucaoAsync()
    {
        try
        {
           var data = await _resumoVendasService.ObterVendasPorEvolucaoAsync();
           return Ok(data);
        }
        catch (Exception ex)
        {
            return CustomError(ex);
        }
    }

    [HttpGet("resumo-vendas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ObterResumoVendasAsync()
    {
        try
        {
            var data = await _resumoVendasService.ObterResumoVendasAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {
            return CustomError(ex);
        }
    }

    [HttpGet("resumo-vendas-cobranca")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ObterResumoVendasPorCobrancaAsync(string dateTimeIni, string dateTimeFim)
    {
        try
        {
            var data = await _resumoVendasService.ObterVendasPorTipoPessoaAsync(dateTimeIni, dateTimeFim);
            return Ok(data);
        }
        catch (Exception ex)
        {
            return CustomError(ex);
        }
    }
}