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
            ComponentProvider.Register<ISampleComponent, SampleComponent>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<ISampleComponent>());
        }

        [Test]
        [ExpectedException(ExpectedMessage = "There is already a component registered for Agility.Common.Tests.Infrastructure.ISampleComponent")]
        public void Register_ComponentAlreadyRegistered_ShouldGiveRegistrationException()
        {
            ComponentProvider.Register<ISampleComponent, SampleComponent>();
            ComponentProvider.Register<ISampleComponent, SampleComponent2>();
        }

        [Test]
        public void RegisterSingleton_ComponentNotRegisteredYet_ComponentShouldBeRegistered()
        {
            ComponentProvider.RegisterSingleton<ISampleComponent, SampleComponent>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<ISampleComponent>());
        }

        [Test]
        [ExpectedException(ExpectedMessage = "There is already a component registered for Agility.Common.Tests.Infrastructure.ISampleComponent")]
        public void RegisterSingleton_ComponentAlreadyRegistered_ShouldGiveRegistrationException()
        {
            ComponentProvider.RegisterSingleton<ISampleComponent, SampleComponent>();
            ComponentProvider.RegisterSingleton<ISampleComponent, SampleComponent2>();
        }

        [Test]
        public void Resolve_ComponentWasRegisteredWithDefaultLifestyle_NewComponentShouldBeReturned()
        {
            ComponentProvider.Register<ISampleComponent, SampleComponent>();

            var resolvedComponent1 = ComponentProvider.Resolve<ISampleComponent>();
            var resolvedComponent2 = ComponentProvider.Resolve<ISampleComponent>();

            Assert.AreNotSame(resolvedComponent1, resolvedComponent2);
        }

        [Test]
        public void Resolve_ComponentWasRegisteredWithSingletonLifestyle_SameComponentShouldBeReturned()
        {
            ComponentProvider.RegisterSingleton<ISampleComponent, SampleComponent>();

            var resolvedComponent1 = ComponentProvider.Resolve<ISampleComponent>();
            var resolvedComponent2 = ComponentProvider.Resolve<ISampleComponent>();

            Assert.AreSame(resolvedComponent1, resolvedComponent2);
        }

        [Test]
        [ExpectedException(ExpectedMessage = "There is no component registered for Agility.Common.Tests.Infrastructure.ISampleComponent")]
        public void Resolve_ComponentNotRegisteredYet_ShouldGiveRegistrationException()
        {
            ComponentProvider.Resolve<ISampleComponent>();
        }

        [Test]
        public void Resolve_ComponentAlreadyRegistered_ShouldReturnComponent()
        {
            ComponentProvider.Register<ISampleComponent, SampleComponent>();

            Assert.IsNotNull(ComponentProvider.Resolve<ISampleComponent>());
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentNotRegisteredYet_False()
        {
            Assert.IsFalse(ComponentProvider.HasRegisteredComponentFor<ISampleComponent>());
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentAlreadyRegistered_True()
        {
            ComponentProvider.Register<ISampleComponent, SampleComponent>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<ISampleComponent>());
        }
    }

    interface ISampleComponent {}
    class SampleComponent : ISampleComponent { }
    class SampleComponent2 : ISampleComponent { }
}