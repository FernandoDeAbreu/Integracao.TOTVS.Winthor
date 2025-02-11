using Dapper;
using Integracao.TOTVS.Winthor.Domain;
using Integracao.TOTVS.Winthor.Infra.Database;
using Integracao.TOTVS.Winthor.Infra.Interfaces;

namespace Integracao.TOTVS.Winthor.Infra;

public class ResumoVendasRepository : IResumoVendasRepository
{
    private readonly IDatabaseProviderFactory _databaseProviderFactory;

    public ResumoVendasRepository(IDatabaseProviderFactory databaseProviderFactory)
    {
        _databaseProviderFactory = databaseProviderFactory;
    }

    public async Task<IEnumerable<Venda>> ObterVendasPorEvolucaoAsync()
    {
        using var connection = _databaseProviderFactory.CriarDatabaseConnection();
        connection.Open();

        var query = @"SELECT
                              PCPEDC.DATA,
                              SUM(DECODE(PCPEDC.CONDVENDA, 5, 0, 6, 0, 11, 0, 12, 0, NVL(PCPEDC.VLATEND - NVL(PCPEDC.VLOUTRASDESP, 0) - NVL(PCPEDC.VLFRETE, 0), 0)))VLVENDA

                      FROM PCPEDC,
                              PCPLPAG,
                              PCUSUARI
                      WHERE PCPEDC.CODPLPAG = PCPLPAG.CODPLPAG
                          AND PCPEDC.CODUSUR = PCUSUARI.CODUSUR
                          AND PCPEDC.POSICAO IN('L','M','B','P','F','C')
                          AND PCPEDC.CONDVENDA NOT IN(4, 8, 10, 13, 20, 98, 99)
                          AND PCPEDC.DTCANCEL IS NULL
                          AND PCPEDC.DATA >= (SELECT MIN(PCPEDC.DATA)
                                             FROM PCPEDC
                                            WHERE 0 = 0
                                             )
                          AND    PCPEDC.DATA >= TO_DATE('01/01/2014', 'DD-MM-YYYY')
                      GROUP BY
                          PCPEDC.DATA
                      ORDER BY PCPEDC.DATA DESC";

        return await connection.QueryAsync<Venda>(query);
    }

    public async Task<IEnumerable<Venda>> ObterVendasPorTipoPessoaAsync(string dateTimeIni, string dateTimeFim)
    {
        using var connection = _databaseProviderFactory.CriarDatabaseConnection();
        connection.Open();

        var parameters = new { dateTimeIni, dateTimeFim };

        var query = @"SELECT
                            PCCOB.CODECF as SgPessoa,
                            PCCOB.CODCOB as Moeda,
                            PCCOB.COBRANCA as Cobranca,
                            SUM(DECODE(PCPEDC.CONDVENDA, 5, 0, 6, 0, 11, 0, 12, 0, NVL(PCPEDC.VLATEND - NVL(PCPEDC.VLOUTRASDESP, 0) - NVL(PCPEDC.VLFRETE, 0), 0)))VLVENDA
                     
                     FROM PCPEDC,
                             PCPLPAG,
                             PCUSUARI,
                             PCCOB
                       WHERE PCPEDC.CODPLPAG = PCPLPAG.CODPLPAG
                         AND PCPEDC.CODUSUR = PCUSUARI.CODUSUR
                         AND PCPEDC.CODCOB = PCCOB.CODCOB
                         AND PCPEDC.POSICAO IN('L','M','B','P','F','C')
                         AND PCPEDC.CONDVENDA NOT IN(4, 8, 10, 13, 20, 98, 99)
                         AND PCPEDC.DTCANCEL IS NULL
                       AND PCPEDC.DATA >= (SELECT MIN(PCPEDC.DATA)
                                            FROM PCPEDC
                                           WHERE 0 = 0
                                            )
                         AND PCPEDC.DATA BETWEEN TO_DATE(:dateTimeIni, 'DD-MM-YYYY') AND TO_DATE(:dateTimeFim, 'DD-MM-YYYY')
                         GROUP BY
                         PCCOB.CODECF,
                         PCCOB.CODCOB,
                         PCCOB.COBRANCA";

        return await connection.QueryAsync<Venda>(query, parameters);
    }
}