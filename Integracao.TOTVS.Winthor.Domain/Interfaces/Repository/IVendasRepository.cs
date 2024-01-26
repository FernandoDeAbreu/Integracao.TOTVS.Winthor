using Integracao.TOTVS.Winthor.Entitys.Entitys;

namespace Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;

public interface IVendasRepository
{
    Task<IEnumerable<VendasPorVendedor>> VendasPorVendendorAsync(string data);
}