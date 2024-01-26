using Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;
using Integracao.TOTVS.Winthor.Domain.Interfaces.Services;
using Integracao.TOTVS.Winthor.Entitys.Entitys;

namespace Integracao.TOTVS.Winthor.Domain.Services;

public class VendasService : IVendasServices
{
    private readonly IVendasRepository _vendasRepository;

    public VendasService(IVendasRepository vendasRepository)
    {
        _vendasRepository = vendasRepository;
    }

    public async Task<IEnumerable<VendasPorVendedor>> VendasPorVendendorAsync(string data)
    {
        return await _vendasRepository.VendasPorVendendorAsync(data);
    }
}