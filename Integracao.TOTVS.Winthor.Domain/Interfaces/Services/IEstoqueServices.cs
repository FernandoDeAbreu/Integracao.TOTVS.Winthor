using Integracao.TOTVS.Winthor.Entitys.Entitys;

namespace Integracao.TOTVS.Winthor.Domain.Interfaces.Services;

public interface IEstoqueServices
{
    Task<IEnumerable<PcEst>> BuscarEstoqueAsync(string codprod);
}