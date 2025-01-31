using Autofac;

namespace Integracao.TOTVS.Winthor.CrossCute;

public class ModuleIoc : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        ConfigurationIoc.Load(builder);
    }
}
