using Microsoft.Practices.Unity;

using Quartz.Unity.UnityExtensions;

using Topshelf.HostConfigurators;
using Topshelf.Quartz.Unity.WindowsServices;
using Topshelf.Unity.Extensions;

namespace Topshelf.Quartz.Unity.Extensions
{
    public static class HostConfiguratorExtensions
    {
        public static HostConfigurator RunQuartzService(this HostConfigurator configurator, IUnityContainer container)
        {
            container.AddNewExtension<QuartzUnityExtension>();

            configurator.RunService<QuartzService>(container);

            return configurator;
        }
    }
}
