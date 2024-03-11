using Dapper;
using Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;
using Integracao.TOTVS.Winthor.Entitys.Entitys;
using Integracao.TOTVS.Winthor.Infra.Database;

namespace Integracao.TOTVS.Winthor.Infra.Repositorys;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly IDatabaseProviderFactory _databaseProviderFactory;

    public FornecedorRepository(IDatabaseProviderFactory databaseProviderFactory)
    {
        _databaseProviderFactory = databaseProviderFactory;
    }

    public async Task<IEnumerable<Fornecedor>> BuscarFornecedorPorCodFornecAsync(int CodFornec)
    {
        var connection = _databaseProviderFactory.CriarDatabaseConnection();
        connection.Open();

        var paremetros = new { CodFornec };

        var query = "SELECT CODFORNEC as CodFornec, FORNECEDOR as NomeFornec FROM PCFORNEC WHERE CODFORNEC = :CODFORNEC";

        var fornecedor = await connection.QueryAsync<Fornecedor>(query, paremetros);
        return fornecedor;
    }
}