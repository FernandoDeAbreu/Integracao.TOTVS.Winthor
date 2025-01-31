namespace Integracao.TOTVS.Winthor.Domain.Services.Interfaces;

public interface IResumoVendasService
{
    Task<IEnumerable<Venda>> ObterVendasPorEvolucaoAsync();
    Task<IEnumerable<ResumoVenda>> ObterResumoVendasAsync();
}