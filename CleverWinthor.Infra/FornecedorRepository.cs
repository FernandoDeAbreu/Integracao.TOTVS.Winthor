using Integracao.TOTVS.Winthor.Domain;
using Integracao.TOTVS.Winthor.Infra.Database;
using Integracao.TOTVS.Winthor.Infra.Interfaces;
using Dapper;

namespace Integracao.TOTVS.Winthor.Infra;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly IDatabaseProviderFactory _databaseProviderFactory;

    public FornecedorRepository(IDatabaseProviderFactory databaseProviderFactory)
    {
        _databaseProviderFactory = databaseProviderFactory;
    }

    public async Task<IEnumerable<Fornecedor>> ObterFornecedorAsync(int CodFornec)
    {
        using var connection = _databaseProviderFactory.CriarDatabaseConnection();
        connection.Open();

        var parameters = new { CodFornec };
        var query = @"SELECT 
                        CODFORNEC,
                        FORNECEDOR AS Descricao, 
                        CGC as CNPJ 
                      FROM 
                         PCFORNEC 
                      WHERE 
                          CODFORNEC = :CODFORNEC";

        return await connection.QueryAsync<Fornecedor>(query, parameters);
    }
    public async Task<IEnumerable<Fornecedor>> ObterTodosFornecedoresAsync()
    {
        using var connection = _databaseProviderFactory.CriarDatabaseConnection();
        connection.Open();

        var query = @"SELECT 
                     CODFORNEC,
                     FORNECEDOR AS Descricao, 
                     CGC as CNPJ 
                   FROM 
                      PCFORNEC
                    ORDER BY CODFORNEC DESC";


        return await connection.QueryAsync<Fornecedor>(query);
    }
}