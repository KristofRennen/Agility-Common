using StructureMap;

namespace Agility.Common.Infrastructure
{
    /// <summary>
    /// Wrapper around an Inversion of Control container, managing all components and its dependencies.
    /// The combination of contract and implementation should be unique.
    /// </summary>
    public static class ComponentProvider
    {
        private static IContainer container;

        static ComponentProvider()
        {
            ReBuild();
        }

        /// <summary>
        /// Releases all registered components and rebuilds the container.
        /// </summary>
        public static void ReBuild()
        {
            container = new Container(c => { });
        }

        /// <summary>
        /// Registers a transient component within the container if the given contract / implementation combination was not registered yet.
        /// Throws a ComponentRegistrationException when a component was already registered for the given contract. 
        /// </summary>
        /// <exception cref="Agility.Common.Infrastructure.ComponentRegistrationException">When an implementation was already registered for the given contract.</exception>
        /// <typeparam name="TInterface">The contract of the component to register.</typeparam>
        /// <typeparam name="TImplementation">The implementation of the component to register.</typeparam>
        public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            CheckComponentUniqueness<TInterface>();

            container.Configure(o => o.For<TInterface>().Use<TImplementation>());
        }

        /// <summary>
        /// Registers a singleton component within the container if the given contract / implementation combination was not registered yet.
        /// Throws a ComponentRegistrationException when a component was already registered for the given contract. 
        /// </summary>
        /// <exception cref="Agility.Common.Infrastructure.ComponentRegistrationException">When an implementation was already registered for the given contract.</exception>
        /// <typeparam name="TInterface">The contract of the component to register.</typeparam>
        /// <typeparam name="TImplementation">The implementation of the component to register.</typeparam>
        public static void RegisterSingleton<TInterface, TImplementation>() where TImplementation : TInterface
        {
            CheckComponentUniqueness<TInterface>();

            container.Configure(o => o.For<TInterface>().Singleton().Use<TImplementation>());
            RegisterAutomaticPropertyInjection<TInterface, TImplementation>();
        }

        /// <summary>
        /// Returns whether a component for a given contract was registered within the container.
        /// </summary>
        /// <typeparam name="TInterface">The contract of the component to check.</typeparam>
        /// <returns>True if the component was registered, False when no component was registered.</returns>
        public static bool HasRegisteredComponentFor<TInterface>()
        {
            return container.Model.HasImplementationsFor<TInterface>();
        }

        /// <summary>
        /// Returns the implementation for a given contract from the container.
        /// Throws a ComponentRegistrationException when no component was registered for the given contract. 
        /// </summary>
        /// <exception cref="Agility.Common.Infrastructure.ComponentRegistrationException">When an implementation is not registered for the given contract.</exception>
        /// <typeparam name="TInterface">The contract of the component to resolve.</typeparam>
        /// <returns>The implementation for the given contract from the container.</returns>
        public static TInterface Resolve<TInterface>()
        {
            if (!HasRegisteredComponentFor<TInterface>())
            {
                throw new ComponentRegistrationException(string.Format("There is no component registered for {0}", typeof(TInterface).FullName));
            }

            try
            {
                return container.GetInstance<TInterface>();
            }
            catch
            {
                throw new ComponentRegistrationException(string.Format("There are unregistered dependencies for component {0}", typeof(TInterface).FullName));
            }
        }

        /// <summary>
        /// Checks whether an implementation for the given contract was already registered within the container.
        /// Does nothing when no component was registered yet.
        /// Throws a ComponentRegistrationException when a component was already registered for the given contract. 
        /// </summary>
        /// <exception cref="Agility.Common.Infrastructure.ComponentRegistrationException">When an implementation is registered for the given contract.</exception>
        /// <typeparam name="TInterface">The contract of the component to check.</typeparam>
        private static void CheckComponentUniqueness<TInterface>()
        {
            if (HasRegisteredComponentFor<TInterface>())
            {
                throw new ComponentRegistrationException(string.Format("There is already a component registered for {0}", typeof(TInterface).FullName));
            }
        }

        /// <summary>
        /// Registers an implementation for the given contract to be auto wired through property injection as to support optional dependencies.
        /// </summary>
        /// <typeparam name="TInterface">The contract of the component to register.</typeparam>
        /// <typeparam name="TImplementation">The implementation of the component to register.</typeparam>
        private static void RegisterAutomaticPropertyInjection<TInterface, TImplementation>() where TImplementation : TInterface
        {
            container.Configure(o => o.FillAllPropertiesOfType<TInterface>().Use<TImplementation>());
        }
    }
}