using System;
using System.Linq;
using StructureMap;

namespace Agility.Common.Infrastructure
{
    public static class ComponentProvider
    {
        private static IContainer container;

        static ComponentProvider()
        {
            ReBuild();
        }

        public static void ReBuild()
        {
            container = new Container(c => { });
        }

        public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            CheckComponentUniqueness<TInterface>();

            container.Configure(o => o.For<TInterface>().Use<TImplementation>());
        }

        public static void RegisterSingleton<TInterface, TImplementation>() where TImplementation : TInterface
        {
            CheckComponentUniqueness<TInterface>();

            container.Configure(o => o.For<TInterface>().Singleton().Use<TImplementation>());
        }

        public static bool HasRegisteredComponentFor<TInterface>()
        {
            return container.Model.HasImplementationsFor<TInterface>();
        }

        public static TInterface Resolve<TInterface>()
        {
            if (!HasRegisteredComponentFor<TInterface>())
            {
                throw new ComponentRegistrationException(string.Format("There is no component registered for {0}", typeof(TInterface).FullName));
            }

            return container.GetInstance<TInterface>();
        }

        private static void CheckComponentUniqueness<TInterface>()
        {
            if (HasRegisteredComponentFor<TInterface>())
            {
                throw new ComponentRegistrationException(string.Format("There is already a component registered for {0}", typeof(TInterface).FullName));
            }
        }
    }
}