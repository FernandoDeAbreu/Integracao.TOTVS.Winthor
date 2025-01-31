using Autofac;
using Integracao.TOTVS.Winthor.Domain.Services;
using Integracao.TOTVS.Winthor.Domain.Services.Interfaces;
using Integracao.TOTVS.Winthor.Infra;
using Integracao.TOTVS.Winthor.Infra.Database;
using Integracao.TOTVS.Winthor.Infra.Interfaces;

namespace Integracao.TOTVS.Winthor.CrossCute;

public class ConfigurationIoc
{
    public static void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DbConfiguration>().As<DbConfiguration>();
        builder.RegisterType<DatabaseProviderFactory>().As<IDatabaseProviderFactory>();

        builder.RegisterType<FornecedorService>().As<IFornecedorService>();
        builder.RegisterType<FornecedorRepository>().As<IFornecedorRepository>();
        builder.RegisterType<ProdutoService>().As<IProdutoService>();
        builder.RegisterType<ProdutoRepository>().As<IProdutoRepository>();
        builder.RegisterType<ResumoVendasService>().As<IResumoVendasService>();
        builder.RegisterType<ResumoVendasRepository>().As<IResumoVendasRepository>();
    }
}