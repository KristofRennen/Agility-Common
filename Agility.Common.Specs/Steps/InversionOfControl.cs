using System;
using Agility.Common.Infrastructure;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Agility.Common.Specs.Steps
{
    [Binding]
    public class InversionOfControl
    {
        [Given(@"Provider has no registered components")]
        public void GivenProviderHasNoRegisteredComponents()
        {
            ComponentProvider.ReBuild();
        }

        [Given(@"Component Agility.Common.Specs.IComponent is registered as a singleton")]
        public void GivenComponentAgility_Common_Specs_IComponentIsRegisteredAsASingleton()
        {
            ComponentProvider.RegisterSingleton<IComponent, Component>();
        }

        [Given(@"Component Agility.Common.Specs.IComponent is registered as a transient")]
        public void GivenComponentAgility_Common_Specs_IComponentIsRegisteredAsATransient()
        {
            ComponentProvider.Register<IComponent, Component>();
        }

        [Given(@"Component Agility.Common.Specs.IComponent is not registered")]
        public void GivenComponentAgility_Common_Specs_IComponentIsNotRegistered()
        {
            ComponentProvider.ReBuild();
        }
        
        [When(@"I try to register component Agility.Common.Specs.IComponent as a transient")]
        public void WhenITryToRegisterComponentAgility_Common_Specs_IComponentAsATransient()
        {
            try
            {
                ComponentProvider.Register<IComponent, Component>();
            }
            catch (Exception e)
            {
                ScenarioContext.Current["Error"] = e.Message;
            }
        }

        [When(@"I try to register component Agility.Common.Specs.IComponent as a singleton")]
        public void WhenITryToRegisterComponentAgility_Common_Specs_IComponentAsASingleton()
        {
            try
            {
                ComponentProvider.RegisterSingleton<IComponent, Component>();
            }
            catch (ComponentRegistrationException e)
            {
                ScenarioContext.Current["Error"] = e.Message;
            }
        }

        [When(@"I try to resolve component Agility.Common.Specs.IComponent")]
        public void WhenITryToResolveComponentAgility_Common_Specs_IComponent()
        {
            try
            {
                var component = ComponentProvider.Resolve<IComponent>();
                ScenarioContext.Current["Component1"] = component;
            }
            catch (Exception e)
            {
                ScenarioContext.Current["Error"] = e.Message;
            }
        }

        [When(@"I try to resolve component Agility.Common.Specs.IComponent multiple times")]
        public void WhenITryToResolveComponentAgility_Common_Specs_IComponentMultipleTimes()
        {
            var component1 = ComponentProvider.Resolve<IComponent>();
            var component2 = ComponentProvider.Resolve<IComponent>();

            ScenarioContext.Current["Component1"] = component1;
            ScenarioContext.Current["Component2"] = component2;
        }

        [Then(@"The system shows the error message ""There is already a component registered for Agility.Common.Specs.IComponent""")]
        public void ThenTheSystemShowsTheErrorMessageThereIsAlreadyAComponentRegisteredForAgility_Common_Specs_IComponent()
        {
            var error = ScenarioContext.Current["Error"].ToString();
            Assert.AreEqual("There is already a component registered for Agility.Common.Specs.IComponent", error);
        }

        [Then(@"Component Agility.Common.Specs.IComponent is registered")]
        public void ThenComponentAgility_Common_Specs_IComponentIsRegistered()
        {
            Assert.IsTrue(ComponentProvider.HasRegisteredComponentFor<IComponent>());
        }

        [Then(@"An instance of component Agility.Common.Specs.IComponent is returned")]
        public void ThenAnInstanceOfComponentAgility_Common_Specs_IComponentIsReturned()
        {
            var component = ScenarioContext.Current["Component1"];
            Assert.IsNotNull(component);
            Assert.IsTrue(component is IComponent);
        }

        [Then(@"The system shows the error message ""There is no component registered for Agility.Common.Specs.IComponent""")]
        public void ThenTheSystemShowsTheErrorMessageThereIsNoComponentRegisteredForAgility_Common_Specs_IComponent()
        {
            var error = ScenarioContext.Current["Error"].ToString();
            Assert.AreEqual("There is no component registered for Agility.Common.Specs.IComponent", error);
        }

        [Then(@"The same instance of component Agility.Common.Specs.IComponent is returned each time")]
        public void ThenTheSameInstanceOfComponentAgility_Common_Specs_IComponentIsReturnedEachTime()
        {
            var component1 = ScenarioContext.Current["Component1"];
            var component2 = ScenarioContext.Current["Component2"];

            Assert.AreSame(component1, component2);
        }

        [Then(@"A new instance of component Agility.Common.Specs.IComponent is returned each time")]
        public void ThenANewInstanceOfComponentAgility_Common_Specs_IComponentIsReturnedEachTime()
        {
            var component1 = ScenarioContext.Current["Component1"];
            var component2 = ScenarioContext.Current["Component2"];

            Assert.AreNotSame(component1, component2);
        }
    }
}
