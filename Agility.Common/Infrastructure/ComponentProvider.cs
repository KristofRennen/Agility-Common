using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Agility.Common.Infrastructure
{
    public class ComponentProvider
    {
        private static IWindsorContainer container;

        static ComponentProvider()
        {
            ReBuild();
        }

        public static void ReBuild()
        {
            container = new WindsorContainer();
        }

        public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifeStyle.Transient);
        }

        public static void RegisterSingleton<TInterface, TImplementation>() where TImplementation : TInterface
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifeStyle.Singleton);
        }

        public static bool HasRegisteredComponentFor<TInterface>()
        {
            return container.Kernel.HasComponent(typeof (TInterface));
        }

        public static TInterface Resolve<TInterface>()
        {
            return container.Resolve<TInterface>();
        }
    }
}