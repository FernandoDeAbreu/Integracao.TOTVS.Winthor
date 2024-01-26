using Autofac;

namespace Integracao.TOTVS.Winthor.CrossCutting.IOC;

public class ModuleIOC : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        ConfigurationIOC.Load(builder);
    }
}