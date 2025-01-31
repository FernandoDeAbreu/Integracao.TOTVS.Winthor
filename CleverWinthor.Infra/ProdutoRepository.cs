using Dapper;
using Integracao.TOTVS.Winthor.Domain;
using Integracao.TOTVS.Winthor.Infra.Database;
using Integracao.TOTVS.Winthor.Infra.Interfaces;

namespace Integracao.TOTVS.Winthor.Infra;

public class ProdutoRepository : IProdutoRepository
{
    private readonly IDatabaseProviderFactory _databaseProviderFactory;

    public ProdutoRepository(IDatabaseProviderFactory databaseProviderFactory)
    {
        _databaseProviderFactory = databaseProviderFactory;
    }

    public async Task<Produto> ObterProdutoAsync(int CodProd)
    {
        using var connection = _databaseProviderFactory.CriarDatabaseConnection();
        connection.Open();

        var parameters = new { CodProd };
        var query = @" SELECT
                            P.CODPROD,
                            P.DESCRICAO,
                            P.CODFAB,
                            P.CODAUXILIAR,
                            P.CODFORNEC,
                            F.FORNECEDOR,
                            P.CODNCMEX,
                            N.DESCRICAO NCM,
                            P.CODEPTO,
                            D.DESCRICAO DEPARTAMENTO,
                            P.CODSEC,
                            S.DESCRICAO SECAO,
                            E.CUSTOULTENT,
                            E.CUSTOCONT,
                            E.CUSTOREAL,
                            E.CUSTOULTENTFIN,
                            E.CUSTOFIN,
                            E.CUSTOFIN,
                            T.PVENDA,
                            T.PTABELA,
                            E.QTESTGER
                        FROM
                            PCPRODUT    P,
                            PCEST       E,
                            PCTABPR     T,
                            PCFORNEC    F,
                            PCNCM       N,
                            PCDEPTO     D,
                            PCSECAO     S
                        WHERE
                            P.CODPROD = E.CODPROD AND
                            E.CODFILIAL = 4       AND
                            P.CODPROD = T.CODPROD AND
                            T.NUMREGIAO = 3       AND
                            P.CODFORNEC = F.CODFORNEC AND
                            P.CODNCMEX = N.CODNCMEX AND
                            P.CODEPTO  = D.CODEPTO AND
                            P.CODSEC   = S.CODSEC  AND
                            P.CODPROD  = :CODPROD  ";

        return await connection.QueryFirstAsync<Produto>(query, parameters);
    }

    public async Task<IEnumerable<Produto>> ObterProdutoByFilterAsync(int FornecedorId)
    {
        using var connection = _databaseProviderFactory.CriarDatabaseConnection();
        connection.Open();

        var parameters = new { FornecedorId };
        var query = @" SELECT
                           P.CODPROD,
                           P.DESCRICAO,
                           P.CODFAB,
                           P.CODAUXILIAR,
                           P.CODFORNEC,
                           F.FORNECEDOR,
                           P.CODNCMEX,
                           N.DESCRICAO NCM,
                           P.CODEPTO,
                           D.DESCRICAO DEPARTAMENTO,
                           P.CODSEC,
                           S.DESCRICAO SECAO,
                           E.CUSTOULTENT,
                           E.CUSTOCONT,
                           E.CUSTOREAL,
                           E.CUSTOULTENTFIN,
                           E.CUSTOFIN,
                           E.CUSTOFIN,
                           T.PVENDA,
                           T.PTABELA,
                           E.QTESTGER
                       FROM
                           PCPRODUT    P,
                           PCEST       E,
                           PCTABPR     T,
                           PCFORNEC    F,
                           PCNCM       N,
                           PCDEPTO     D,
                           PCSECAO     S
                       WHERE
                           P.CODPROD = E.CODPROD AND
                           E.CODFILIAL = 4       AND
                           P.CODPROD = T.CODPROD AND
                           T.NUMREGIAO = 3       AND
                           P.CODFORNEC = F.CODFORNEC AND
                           P.CODNCMEX = N.CODNCMEX AND
                           P.CODEPTO  = D.CODEPTO AND
                           P.CODSEC   = S.CODSEC  AND
                           P.CODFORNEC  = :FornecedorId  ";

        return await connection.QueryAsync<Produto>(query, parameters);
    }
}