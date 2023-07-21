using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BlazorServerTestProject;

[DependsOn(typeof(AbpAutofacModule))]
public class BlazorServerModule : AbpModule
{
}
