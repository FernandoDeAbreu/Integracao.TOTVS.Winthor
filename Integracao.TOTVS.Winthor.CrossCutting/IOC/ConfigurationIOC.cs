using Autofac;
using Integracao.TOTVS.Winthor.Domain.Core;
using Integracao.TOTVS.Winthor.Domain.Interfaces.Repository;
using Integracao.TOTVS.Winthor.Domain.Interfaces.Services;
using Integracao.TOTVS.Winthor.Domain.Services;
using Integracao.TOTVS.Winthor.Infra.Database;
using Integracao.TOTVS.Winthor.Infra.Repositorys;

namespace Integracao.TOTVS.Winthor.CrossCutting.IOC;

public class ConfigurationIOC
{
    public static void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DbConfiguration>().As<DbConfiguration>();
        builder.RegisterType<DatabaseProviderFactory>().As<IDatabaseProviderFactory>();

        builder.RegisterType<VendasRepository>().As<IVendasRepository>();
        builder.RegisterType<VendasService>().As<IVendasServices>();

        builder.RegisterType<ContasPagarRepository>().As<IContasPagarRepository>();
        builder.RegisterType<ContasPagarServices>().As<IContasPagarServices>();

        builder.RegisterType<FornecedorRepository>().As<IFornecedorRepository>();

        builder.RegisterType<EstoqueRepository>().As<IEstoqueRepository>();
        builder.RegisterType<EstoqueServices>().As<IEstoqueServices>();
    }
}