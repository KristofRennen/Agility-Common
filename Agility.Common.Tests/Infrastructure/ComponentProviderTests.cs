using Agility.Common.Infrastructure;
using Castle.MicroKernel;
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
            ComponentProvider.Register<ISample, Sample>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<ISample>());
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There is a component already registered for the given key Agility.Common.Tests.Infrastructure.Sample")]
        public void Register_ComponentAlreadyRegistered_ShouldGiveRegistrationException()
        {
            ComponentProvider.Register<ISample, Sample>();
            ComponentProvider.Register<ISample, Sample>();
        }

        [Test]
        public void RegisterSingleton_ComponentNotRegisteredYet_ComponentShouldBeRegistered()
        {
            ComponentProvider.RegisterSingleton<ISample, Sample>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<ISample>());
        }

        [Test]
        [ExpectedException(typeof(ComponentRegistrationException), ExpectedMessage = "There is a component already registered for the given key Agility.Common.Tests.Infrastructure.Sample")]
        public void RegisterSingleton_ComponentAlreadyRegistered_ShouldGiveRegistrationException()
        {
            ComponentProvider.RegisterSingleton<ISample, Sample>();
            ComponentProvider.RegisterSingleton<ISample, Sample>();
        }

        [Test]
        public void Resolve_ComponentWasRegisteredWithDefaultLifestyle_NewComponentShouldBeReturned()
        {
            ComponentProvider.Register<ISample, Sample>();

            var resolvedComponent1 = ComponentProvider.Resolve<ISample>();
            var resolvedComponent2 = ComponentProvider.Resolve<ISample>();

            Assert.AreNotSame(resolvedComponent1, resolvedComponent2);
        }

        [Test]
        public void Resolve_ComponentWasRegisteredWithSingletonLifestyle_SameComponentShouldBeReturned()
        {
            ComponentProvider.RegisterSingleton<ISample, Sample>();

            var resolvedComponent1 = ComponentProvider.Resolve<ISample>();
            var resolvedComponent2 = ComponentProvider.Resolve<ISample>();

            Assert.AreSame(resolvedComponent1, resolvedComponent2);
        }

        [Test]
        [ExpectedException(typeof(ComponentNotFoundException), ExpectedMessage = "No component for supporting the service Agility.Common.Tests.Infrastructure.ISample was found")]
        public void Resolve_ComponentNotRegisteredYet_ShouldGiveRegistrationException()
        {
            ComponentProvider.Resolve<ISample>();
        }

        [Test]
        public void Resolve_ComponentAlreadyRegistered_ShouldReturnComponent()
        {
            ComponentProvider.Register<ISample, Sample>();

            Assert.IsNotNull(ComponentProvider.Resolve<ISample>());
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentNotRegisteredYet_False()
        {
            Assert.IsFalse(ComponentProvider.HasRegisteredComponentFor<ISample>());
        }

        [Test]
        public void HasRegisteredComponentFor_ComponentAlreadyRegistered_True()
        {
            ComponentProvider.Register<ISample, Sample>();

            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<ISample>());
        }
    }

    interface ISample {}
    class Sample : ISample {}
}