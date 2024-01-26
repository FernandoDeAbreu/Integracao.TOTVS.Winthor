using Integracao.TOTVS.Winthor.Entitys.Entitys;

namespace Integracao.TOTVS.Winthor.Domain.Interfaces.Services;

public interface IVendasServices
{
    Task<IEnumerable<VendasPorVendedor>> VendasPorVendendorAsync(string data);
}