using Integracao.TOTVS.Winthor.Domain.Core;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Integracao.TOTVS.Winthor.Infra.Database;

public interface IDatabaseProviderFactory
{
    IDbConnection CriarDatabaseConnection();
}

public sealed class DatabaseProviderFactory : IDatabaseProviderFactory
{
    private readonly HisConfiguracao configuracao;

    public DatabaseProviderFactory(HisConfiguracao configuracao)
    {
        this.configuracao = configuracao;
    }

    public IDbConnection CriarDatabaseConnection()
    {
        if (configuracao.Provider == HisConfiguracao.ProviderEnum.Oracle)
            return new OracleConnection(configuracao.ConnectionString);

        if (configuracao.Provider == HisConfiguracao.ProviderEnum.SqlServer)
            return new SqlConnection(configuracao.ConnectionString);

        throw new NotImplementedException($"Provider({configuracao.Provider}) não implementado.");
    }
}