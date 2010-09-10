using System;
using Agility.Common.Infrastructure;
using NUnit.Framework;

namespace Agility.Common.Tests.Infrastructure
{
    [TestFixture]
    public class ComponentProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            ComponentProvider.ReBuild();
        }

        [Test]
        public void Register_ComponentNotRegisteredYet_ComponentShouldBeRegistered()
        {
            ComponentProvider.Register<IComponent, Component>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponent>());
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There is already a component registered for Agility.Common.Tests.Infrastructure.IComponent")]
        public void Register_ComponentAlreadyRegistered_ShouldGiveRegistrationException()
        {
            ComponentProvider.Register<IComponent, Component>();
            ComponentProvider.Register<IComponent, Component2>();
        }

        [Test]
        public void Register_ComponentWithGenericArgument_ComponentShouldBeRegistered()
        {
            ComponentProvider.Register<IComponentWithGenericArguments<IComponent>, ComponentWithGenericArgument<IComponent>>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponentWithGenericArguments<IComponent>>());
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There is already a component registered for Agility.Common.Tests.Infrastructure.IComponentWithGenericArguments<Agility.Common.Tests.Infrastructure.IComponent>")]
        public void Register_ComponentWithGenericArgumentButWasAlreadyRegistered_ShouldGiveRegistrationException()
        {
            ComponentProvider.Register<IComponentWithGenericArguments<IComponent>, ComponentWithGenericArgument<IComponent>>();
            ComponentProvider.Register<IComponentWithGenericArguments<IComponent>, ComponentWithGenericArgument<IComponent>>();
        }

        [Test]
        public void RegisterSingleton_ComponentNotRegisteredYet_ComponentShouldBeRegistered()
        {
            ComponentProvider.RegisterSingleton<IComponent, Component>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponent>());
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There is already a component registered for Agility.Common.Tests.Infrastructure.IComponent")]
        public void RegisterSingleton_ComponentAlreadyRegistered_ShouldGiveRegistrationException()
        {
            ComponentProvider.RegisterSingleton<IComponent, Component>();
            ComponentProvider.RegisterSingleton<IComponent, Component2>();
        }

        [Test]
        public void RegisterSingleton_ComponentWithGenericArgument_ComponentShouldBeRegistered()
        {
            ComponentProvider.RegisterSingleton<IComponentWithGenericArguments<IComponent>, ComponentWithGenericArgument<IComponent>>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponentWithGenericArguments<IComponent>>());
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There is already a component registered for Agility.Common.Tests.Infrastructure.IComponentWithGenericArguments<Agility.Common.Tests.Infrastructure.IComponent>")]
        public void RegisterSingleton_ComponentWithGenericArgumentButWasAlreadyRegistered_ShouldGiveRegistrationException()
        {
            ComponentProvider.RegisterSingleton<IComponentWithGenericArguments<IComponent>, ComponentWithGenericArgument<IComponent>>();
            ComponentProvider.RegisterSingleton<IComponentWithGenericArguments<IComponent>, ComponentWithGenericArgument<IComponent>>();
        }

        [Test]
        public void Resolve_ComponentWasRegisteredWithDefaultLifestyle_NewComponentShouldBeReturned()
        {
            ComponentProvider.Register<IComponent, Component>();

            var resolvedComponent1 = ComponentProvider.Resolve<IComponent>();
            var resolvedComponent2 = ComponentProvider.Resolve<IComponent>();

            Assert.AreNotSame(resolvedComponent1, resolvedComponent2);
        }

        [Test]
        public void Resolve_ComponentWasRegisteredWithSingletonLifestyle_SameComponentShouldBeReturned()
        {
            ComponentProvider.RegisterSingleton<IComponent, Component>();

            var resolvedComponent1 = ComponentProvider.Resolve<IComponent>();
            var resolvedComponent2 = ComponentProvider.Resolve<IComponent>();

            Assert.AreSame(resolvedComponent1, resolvedComponent2);
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There is no component registered for Agility.Common.Tests.Infrastructure.IComponent")]
        public void Resolve_ComponentNotRegisteredYet_ShouldGiveRegistrationException()
        {
            ComponentProvider.Resolve<IComponent>();
        }

        [Test]
        public void Resolve_ComponentAlreadyRegistered_ShouldReturnComponent()
        {
            ComponentProvider.Register<IComponent, Component>();

            Assert.IsNotNull(ComponentProvider.Resolve<IComponent>());
        }

        [Test]
        public void Resolve_ComponentRegisteredWithConstructorDependenciesAsTransient_NewComponentShouldBeReturned()
        {
            ComponentProvider.Register<IComponent, Component>();
            ComponentProvider.Register<IComponentWithConstructorDependencies, ComponentWithConstructorDependencies>();

            var component = ComponentProvider.Resolve<IComponentWithConstructorDependencies>();

            Assert.IsNotNull(component);
            Assert.IsNotNull(component.Component);
        }

        [Test]
        public void Resolve_ComponentRegisteredWithConstructorDependenciesAsSingleton_SameComponentShouldBeReturned()
        {
            ComponentProvider.RegisterSingleton<IComponent, Component>();
            ComponentProvider.Register<IComponentWithConstructorDependencies, ComponentWithConstructorDependencies>();

            var component1 = ComponentProvider.Resolve<IComponent>();
            var component2 = ComponentProvider.Resolve<IComponentWithConstructorDependencies>();

            Assert.IsNotNull(component1);
            Assert.IsNotNull(component2);
            Assert.IsNotNull(component2.Component);
            Assert.AreSame(component1, component2.Component);
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There are unregistered dependencies for component Agility.Common.Tests.Infrastructure.IComponentWithConstructorDependencies")]
        public void Resolve_ComponentRegisteredWithoutConstructorDependency_ShouldGiveRegistrationException()
        {
            ComponentProvider.Register<IComponentWithConstructorDependencies, ComponentWithConstructorDependencies>();

            ComponentProvider.Resolve<IComponentWithConstructorDependencies>();
        }

        [Test]
        public void Resolve_ComponentRegisteredWithPropertyDependenciesAsTransient_DependenciesShouldBeCorrectlySet()
        {
            ComponentProvider.Register<IComponent, Component>();
            ComponentProvider.Register<IComponentWithPropertyDependencies, ComponentWithPropertyDependencies>();

            var component = ComponentProvider.Resolve<IComponentWithPropertyDependencies>();

            Assert.IsNotNull(component);
            Assert.IsNotNull(component.Component);
        }

        [Test]
        public void Resolve_ComponentRegisteredWithPropertyDependenciesAsSingleton_DependenciesShouldBeCorrectlySet()
        {
            ComponentProvider.RegisterSingleton<IComponent, Component>();
            ComponentProvider.Register<IComponentWithPropertyDependencies, ComponentWithPropertyDependencies>();

            var component1 = ComponentProvider.Resolve<IComponent>();
            var component2 = ComponentProvider.Resolve<IComponentWithPropertyDependencies>();

            Assert.IsNotNull(component1);
            Assert.IsNotNull(component2);
            Assert.IsNotNull(component2.Component);
            Assert.AreSame(component1, component2.Component);
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There are unregistered dependencies for component Agility.Common.Tests.Infrastructure.IComponentWithPropertyDependencies")]
        public void Resolve_ComponentRegisteredWithoutPropertyDependency_ShouldGiveRegistrationException()
        {
            ComponentProvider.Register<IComponentWithPropertyDependencies, ComponentWithPropertyDependencies>();

            ComponentProvider.Resolve<IComponentWithPropertyDependencies>();
        }

        [Test]
        public void Resolve_ComponentRegisteredWithAllDependenciesAsTransient_DependenciesShouldBeCorrectlySet()
        {
            ComponentProvider.Register<IComponent, Component>();
            ComponentProvider.Register<IComponentWithAllDependencies, ComponentWithAllDependencies>();

            var component = ComponentProvider.Resolve<IComponentWithAllDependencies>();
            
            Assert.IsNotNull(component);
            Assert.IsNotNull(component.Component1);
            Assert.IsNotNull(component.Component2);
        }

        [Test]
        public void Resolve_ComponentRegisteredWithAllDependenciesAsSingleton_DependenciesShouldBeCorrectlySet()
        {
            ComponentProvider.RegisterSingleton<IComponent, Component>();
            ComponentProvider.Register<IComponentWithAllDependencies, ComponentWithAllDependencies>();

            var component1 = ComponentProvider.Resolve<IComponent>();
            var component2 = ComponentProvider.Resolve<IComponentWithAllDependencies>();

            Assert.IsNotNull(component1);
            Assert.IsNotNull(component2);
            Assert.IsNotNull(component2.Component1);
            Assert.AreSame(component1, component2.Component1);
            Assert.IsNotNull(component2.Component2);
            Assert.AreSame(component1, component2.Component2);
            Assert.AreSame(component2.Component1, component2.Component2);
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There are unregistered dependencies for component Agility.Common.Tests.Infrastructure.IComponentWithAllDependencies")]
        public void Resolve_ComponentRegisteredWithoutAllDependencies_ShouldGiveRegistrationException()
        {
            ComponentProvider.Register<IComponentWithAllDependencies, ComponentWithAllDependencies>();

            ComponentProvider.Resolve<IComponentWithAllDependencies>();
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There is no component registered for Agility.Common.Tests.Infrastructure.IComponentWithGenericArguments<Agility.Common.Tests.Infrastructure.IComponent>")]
        public void Resolve_GenericComponentNotRegisteredYet_ShouldGiveRegistrationException()
        {
            ComponentProvider.Resolve<IComponentWithGenericArguments<IComponent>>();
        }

        [Test]
        public void Resolve_GenericComponentRegistered_ShouldReturnNewInstanceOfGenericComponent()
        {
            ComponentProvider.Register<IComponentWithGenericArguments<IComponent>, ComponentWithGenericArgument<IComponent>>();

            var component = ComponentProvider.Resolve<IComponentWithGenericArguments<IComponent>>();

            Assert.IsNotNull(component);
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There are unregistered dependencies for component Agility.Common.Tests.Infrastructure.IComponentWithGenericDependency")]
        public void Resolve_ComponentRegisteredWithoutGenericDependency_ShouldGiveRegistrationException()
        {
            ComponentProvider.Register<IComponentWithGenericDependency, ComponentWithGenericDependency>();
            ComponentProvider.Resolve<IComponentWithGenericDependency>();
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentNotRegisteredYet_False()
        {
            Assert.IsFalse(ComponentProvider.HasRegisteredComponentFor<IComponent>());
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentAlreadyRegistered_True()
        {
            ComponentProvider.Register<IComponent, Component>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponent>());
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentRegisteredButRequiredDependencyHasNot_True()
        {
            ComponentProvider.Register<IComponentWithConstructorDependencies, ComponentWithConstructorDependencies>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponentWithConstructorDependencies>());
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentRegisteredButOptionalDependencyHasNot_True()
        {
            ComponentProvider.Register<IComponentWithPropertyDependencies, ComponentWithPropertyDependencies>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponentWithPropertyDependencies>());
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentRegisteredWithRequiredDependency_True()
        {
            ComponentProvider.RegisterSingleton<IComponent, Component>();
            ComponentProvider.Register<IComponentWithConstructorDependencies, ComponentWithConstructorDependencies>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponentWithConstructorDependencies>());
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentRegisteredWithOptionalDependency_True()
        {
            ComponentProvider.RegisterSingleton<IComponent, Component>();
            ComponentProvider.Register<IComponentWithPropertyDependencies, ComponentWithPropertyDependencies>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponentWithPropertyDependencies>());
        }

        [Test]
        public void HasRegisteredComponentFor_NotRegisteredGenericComponent_False()
        {
            Assert.IsFalse(ComponentProvider.HasRegisteredComponentFor<IComponentWithGenericArguments<IComponent>>());
        }

        [Test]
        public void HasRegisteredComponentFor_RegisteredGenericComponent_True()
        {
            ComponentProvider.Register<IComponentWithGenericArguments<IComponent>, ComponentWithGenericArgument<IComponent>>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponentWithGenericArguments<IComponent>>());
        }

        [Test]
        public void Unregister_NotRegisteredComponent_NothingHappens()
        {
            Assert.IsFalse(ComponentProvider.HasRegisteredComponentFor<IComponent>());
            ComponentProvider.Unregister<IComponent>();
            Assert.IsFalse(ComponentProvider.HasRegisteredComponentFor<IComponent>());
        }

        [Test]
        public void Unregister_RegisteredComponent_ComponentIsUnregistered()
        {
            ComponentProvider.Register<IComponent, Component>();
            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponent>());
            ComponentProvider.Unregister<IComponent>();
            Assert.IsFalse(ComponentProvider.HasRegisteredComponentFor<IComponent>());
        }

        [Test]
        public void Unregister_MultipleRegisteredComponent_OnlyCorrectComponentIsUnregistered()
        {
            ComponentProvider.Register<IComponent, Component>();
            ComponentProvider.Register<IComponentWithGenericArguments<IComponent>, ComponentWithGenericArgument<IComponent>>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponent>());
            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponentWithGenericArguments<IComponent>>());

            ComponentProvider.Unregister<IComponent>();

            Assert.IsFalse(ComponentProvider.HasRegisteredComponentFor<IComponent>());
            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponentWithGenericArguments<IComponent>>());
        }
    }

    interface IComponent {}
    class Component : IComponent {}
    class Component2 : IComponent {}
    
    interface IComponentWithConstructorDependencies
    {
        IComponent Component { get; set; }
    }

    class ComponentWithConstructorDependencies : IComponentWithConstructorDependencies
    {
        public IComponent Component { get; set; }

        public ComponentWithConstructorDependencies(IComponent component)
        {
            Component = component;
        }
    }

    interface IComponentWithPropertyDependencies
    {
        IComponent Component { get; set; }
    }

    class ComponentWithPropertyDependencies : IComponentWithPropertyDependencies
    {
        public IComponent Component { get; set;}
    }

    interface IComponentWithAllDependencies
    {
        IComponent Component1 { get; set; }
        IComponent Component2 { get; set; }
    }

    class ComponentWithAllDependencies : IComponentWithAllDependencies
    {
        public IComponent Component1 { get; set; }
        public IComponent Component2 { get; set; }

        public ComponentWithAllDependencies(IComponent component)
        {
            Component2 = component;
        }
    }

    interface IComponentWithGenericArguments<T> {}

    class ComponentWithGenericArgument<T> : IComponentWithGenericArguments<T> {}

    interface IComponentWithGenericDependency {}

    class ComponentWithGenericDependency : IComponentWithGenericDependency
    {
        private readonly IComponentWithGenericArguments<IComponent> component;

        public ComponentWithGenericDependency(IComponentWithGenericArguments<IComponent> component)
        {
            this.component = component;
        }
    }
}