﻿using Integracao.TOTVS.Winthor.Domain;

namespace Integracao.TOTVS.Winthor.Infra.Interfaces;

public interface IResumoVendasRepository
{
    Task<IEnumerable<Venda>> ObterVendasPorEvolucaoAsync();

    Task<IEnumerable<Venda>> ObterVendasPorTipoPessoaAsync(string dateTimeIni, string dateTimeFim);
}