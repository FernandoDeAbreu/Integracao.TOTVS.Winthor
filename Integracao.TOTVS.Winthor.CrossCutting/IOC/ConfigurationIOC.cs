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

        builder.RegisterType<HisConfiguracao>().As<HisConfiguracao>();
        builder.RegisterType<DatabaseProviderFactory>().As<IDatabaseProviderFactory>();

        builder.RegisterType<VendasRepository>().As<IVendasRepository>();
        builder.RegisterType<VendasService>().As<IVendasServices>();
    }
}