using System;
using System.Collections.Generic;
using Agility.Common.Infrastructure;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Agility.Common.Specs.Steps
{
    [Binding]
    [Explicit("Work In Progress")]
    public class InversionOfControl
    {
        private IDictionary<string, Type> Contracts = new Dictionary<string, Type>();
        private IDictionary<string, Type> Implementations = new Dictionary<string, Type>();

        public InversionOfControl()
        {
            Contracts.Add("Agility.Common.Specs.IComponent", typeof(IComponent));
            Implementations.Add("Agility.Common.Specs.IComponent", typeof(Component));

            Contracts.Add("Agility.Common.Specs.IComponentWithConstructorDependency", typeof(IComponentWithConstructorDependency));
            Implementations.Add("Agility.Common.Specs.IComponentWithConstructorDependency", typeof(ComponentWithConstructorDependency));

            Contracts.Add("Agility.Common.Specs.IComponentWithPropertyDependency", typeof(IComponentWithPropertyDependency));
            Implementations.Add("Agility.Common.Specs.IComponentWithPropertyDependency", typeof(ComponentWithPropertyDependency));

            Contracts.Add("Agility.Common.Specs.IComponentWithDependencies", typeof(IComponentWithDependencies));
            Implementations.Add("Agility.Common.Specs.IComponentWithDependencies", typeof(ComponentWithDependencies));
        }

        [Given(@"Provider has no registered components")]
        public void GivenProviderHasNoRegisteredComponents()
        {
            ComponentProvider.ReBuild();
        }

        [Given(@"Component (.*) is not registered")]
        public void GivenComponentIsNotRegistered(string contract)
        {
            ComponentProvider.ReBuild();
        }

        [Given(@"Component (.*) is registered as a singleton")]
        public void GivenComponentIsRegisteredAsASingleton(string contract)
        {
            CallMethod("RegisterSingleton", Contracts[contract], Implementations[contract]);
        }

        [Given(@"Component (.*) is registered as a transient")]
        public void GivenComponentIsRegisteredAsATransient(string contract)
        {
            CallMethod("Register", Contracts[contract], Implementations[contract]);
        }

        [When(@"I try to register component (.*) as a transient")]
        public void WhenITryToRegisterComponentAsATransient(string contract)
        {
            CallMethod("Register", Contracts[contract], Implementations[contract]);
        }

        [When(@"I try to register component (.*) as a singleton")]
        public void WhenITryToRegisterComponentAsASingleton(string contract)
        {
            CallMethod("RegisterSingleton", Contracts[contract], Implementations[contract]);
        }

        [When(@"I try to resolve component (.*)")]
        public void WhenITryToResolveComponent(string contract)
        {
            CallMethod("Resolve", Contracts[contract]);
        }

        [Then(@"The system shows the error message ""(.*)""")]
        public void ThenTheSystemShowsTheErrorMessage(string errorMessage)
        {
            Assert.AreEqual(errorMessage, ScenarioContext.Current["Error"].ToString());
        }

        [Then(@"Component (.*) is registered")]
        public void ThenComponentIsRegistered(string contract)
        {
            CallMethod("HasRegisteredComponentFor", Contracts[contract]);
        }

        [Then(@"An instance of component Agility\.Common\.Specs\.IComponentWithConstructorDependency is returned")]
        public void ThenAnInstanceOfComponentAgility_Common_Specs_IComponentWithConstructorDependencyIsReturned()
        {
            ScenarioContext.Current.Pending();
        }
        
        private static object CallMethod(string methodName, params Type[] type)
        {
            try
            {
                var method = typeof(ComponentProvider).GetMethod(methodName);
                method = method.MakeGenericMethod(type);
                return method.Invoke(null, null);
            }
            catch (Exception e)
            {
                ScenarioContext.Current["Error"] = e.InnerException.Message;
            }

            return null;
        }
    }
}
