using Integracao.TOTVS.Winthor.Entitys.Entitys;

namespace Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;

public interface IEstoqueRepository
{
    Task<IEnumerable<PcEst>> BuscarEstoqueAsync(string codprod);
}