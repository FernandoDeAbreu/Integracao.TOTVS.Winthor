using Dapper;
using Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;
using Integracao.TOTVS.Winthor.Entitys.Entitys;
using Integracao.TOTVS.Winthor.Infra.Database;

namespace Integracao.TOTVS.Winthor.Infra.Repositorys;

public class VendasRepository : IVendasRepository
{
    private readonly IDatabaseProviderFactory _databaseProviderFactory;

    public VendasRepository(IDatabaseProviderFactory databaseProviderFactory)
    {
        _databaseProviderFactory = databaseProviderFactory;
    }

    public async Task<IEnumerable<VendasPorVendedor>> VendasPorVendendorAsync(string data)
    {
        var connection = _databaseProviderFactory.CriarDatabaseConnection();
        connection.Open();

        string sqlQuery = @" SELECT
                                 PCUSUARI.NOME,
                                        SUM(PCPEDC.VLATEND) VALOR

                                 FROM  PCPEDC, PCPLPAG,PCUSUARI
                                 WHERE(PCPEDC.CODPLPAG = PCPLPAG.CODPLPAG)
                                   AND PCPEDC.CODUSUR = PCUSUARI.CODUSUR
                                   AND(PCPEDC.DATA >= SYSDATE - 1)
                                   AND(PCPEDC.DATA <= SYSDATE)
                                   AND(PCPEDC.DTCANCEL IS NULL)
                                   AND(PCPEDC.CONDVENDA NOT IN(4, 8, 10, 13, 20, 5))
                                   AND(LTRIM(RTRIM(PCPEDC.CODFILIAL)) = 4)
                                 GROUP BY PCPEDC.CODUSUR, PCUSUARI.NOME
                                 ORDER BY VALOR DESC";

        return await connection.QueryAsync<VendasPorVendedor>(sqlQuery);
    }
}