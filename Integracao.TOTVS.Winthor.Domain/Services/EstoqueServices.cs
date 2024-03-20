using Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;
using Integracao.TOTVS.Winthor.Domain.Interfaces.Services;
using Integracao.TOTVS.Winthor.Entitys.Entitys;

namespace Integracao.TOTVS.Winthor.Domain.Services;

public class EstoqueServices : IEstoqueServices
{
    private readonly IEstoqueRepository _repository;

    public EstoqueServices(IEstoqueRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PcEst>> BuscarEstoqueAsync(string codprod)
    {
        var response =  await _repository.BuscarEstoqueAsync(codprod);
        return response;
    }
}