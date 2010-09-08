using System;
using System.Collections.Generic;
using System.Linq;
using Agility.Common.Infrastructure;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Agility.Common.Specs.Steps
{
    [Binding]
    public class InversionOfControl
    {
        private readonly InversionOfControlContext context;

        public InversionOfControl(InversionOfControlContext context)
        {
            this.context = context;
        }

        [Given(@"Provider has no registered components")]
        public void GivenProviderHasNoRegisteredComponents()
        {
            ComponentProvider.ReBuild();
        }

        [Given(@"Component (.*) is registered as a transient")]
        public void GivenComponentAsATransient(string componentContract)
        {
            ExecuteMethod("Register", context.Contracts[componentContract], context.Implementations[componentContract]);
        }

        [Given(@"Component (.*) is registered as a singleton")]
        public void GivenComponentIsRegisteredAsASingleton(string componentContract)
        {
            ExecuteMethod("RegisterSingleton", context.Contracts[componentContract], context.Implementations[componentContract]);
        }

        [Given(@"Component (.*) is not registered")]
        public void GivenComponentIsNotRegistered(string componentContract)
        {
            
        }
        
        [When(@"I try to register component (.*) as a transient")]
        public void WhenITryToRegisterComponentAsATransient(string componentContract)
        {
            ExecuteMethod("Register", context.Contracts[componentContract], context.Implementations[componentContract]);
        }

        [When(@"I try to register component (.*) as a singleton")]
        public void WhenITryToRegisterComponentAsASingleton(string componentContract)
        {
            ExecuteMethod("RegisterSingleton", context.Contracts[componentContract], context.Implementations[componentContract]);
        }

        [When(@"I try to resolve component (.*) (\d+) (?:time|times)")]
        public void WhenITryToResolveComponentNTimes(string componentContract, int numberOfTimes)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                context.ResolvedComponents.Add(ExecuteMethod("Resolve", context.Contracts[componentContract]));
            }
        }
        
        [Then(@"The system shows the error message ""(.*)""")]
        public void ThenTheSystemShowsTheErrorMessage(string errorMessage)
        {
            Assert.AreEqual(errorMessage, context.Error.Message);
        }

        [Then(@"Component (.*) is registered")]
        public void ThenComponentIsRegistered(string componentContract)
        {
            Assert.IsTrue((bool)ExecuteMethod("HasRegisteredComponentFor", context.Contracts[componentContract]));
        }

        [Then(@"An instance of component (.*) is returned")]
        public void ThenAnInstanceOfComponentIsReturned(string componentContract)
        {
            Assert.IsTrue(context.ResolvedComponents.Any(c => c.GetType() == context.Implementations[componentContract]));
        }

        [Then(@"Component (.*) has (\d+) (?:dependency|dependencies)")]
        public void ThenComponentHasNDependencies(string componentContract, int numberOfDependencies)
        {
            var component = (IComponentWithDependencies) context.ResolvedComponents.First(c => c.GetType() == context.Implementations[componentContract]);
            Assert.AreEqual(numberOfDependencies, component.Dependencies.Count);
        }

        [Then(@"The same instance of component (.*) is returned each time")]
        public void ThenTheSameInstanceOfComponentIsReturnedEachTime(string componentContract)
        {
            var components = context.ResolvedComponents.Where(c => c.GetType() == context.Implementations[componentContract]);
            Assert.Greater(components.Count(), 1);

            object previousComponent = null;
            foreach (var resolvedComponent in components)
            {
                if (previousComponent == null)
                {
                    previousComponent = resolvedComponent;
                }

                Assert.AreSame(previousComponent, resolvedComponent);
            }
        }

        [Then(@"A new instance of component (.*) is returned each time")]
        public void ThenANewInstanceOfComponentIsReturnedEachTime(string componentContract)
        {
            var components = context.ResolvedComponents.Where(c => c.GetType() == context.Implementations[componentContract]);
            Assert.Greater(components.Count(), 1);

            object previousComponent = null;
            foreach (var resolvedComponent in components)
            {
                if (previousComponent == null)
                {
                    previousComponent = resolvedComponent;
                }
                else
                {
                    Assert.AreNotSame(previousComponent, resolvedComponent);
                }
            }
        }

        [Then(@"All (.*) dependencies are new instances")]
        public void ThenAllDependenciesAreNewInstances(string componentContract)
        {
            var component = ExecuteMethod("Resolve", context.Contracts[componentContract]);

            foreach (var dependency in context.ResolvedComponents.Select(c => ((IComponentWithDependencies)c).Dependencies))
            {
                Assert.AreNotSame(component, dependency);
            }
        }

        [Then(@"All (.*) dependencies are the same instances")]
        public void ThenAllDependenciesAreTheSameInstances(string componentContract)
        {
            var component = ExecuteMethod("Resolve", context.Contracts[componentContract]);

            foreach (var dependency in context.ResolvedComponents.SelectMany(c => ((IComponentWithDependencies)c).Dependencies))
            {
                Assert.AreSame(component, dependency);
            }
        }

        private object ExecuteMethod(string methodName, params Type[] typeArguments)
        {
            try
            {
                var method = typeof(ComponentProvider).GetMethod(methodName);
                method = method.MakeGenericMethod(typeArguments);
                var returnValue = method.Invoke(null, null);
                return returnValue;
            } 
            catch (Exception e)
            {
                context.Error = e.InnerException;
            }

            return null;
        }
    }

    public class InversionOfControlContext
    {
        public readonly List<object> ResolvedComponents = new List<object>();
        public readonly IDictionary<string, Type> Contracts = new Dictionary<string, Type>();
        public readonly IDictionary<string, Type> Implementations = new Dictionary<string, Type>();
        
        public Exception Error { get; set; }

        public InversionOfControlContext()
        {
            Contracts.Add("Agility.Common.Specs.IComponent", typeof(IComponent));
            Implementations.Add("Agility.Common.Specs.IComponent", typeof(Component));

            Contracts.Add("Agility.Common.Specs.IComponentWithConstructorDependency", typeof(IComponentWithConstructorDependency));
            Implementations.Add("Agility.Common.Specs.IComponentWithConstructorDependency", typeof(ComponentWithConstructorDependency));

            Contracts.Add("Agility.Common.Specs.IComponentWithPropertyDependency", typeof(IComponentWithPropertyDependency));
            Implementations.Add("Agility.Common.Specs.IComponentWithPropertyDependency", typeof(ComponentWithPropertyDependency));

            Contracts.Add("Agility.Common.Specs.IComponentWithDependencies", typeof(IComponentWithDependencies));
            Implementations.Add("Agility.Common.Specs.IComponentWithDependencies", typeof(ComponentWithDependencies));

            Error = new Exception("");
        }
    }
}
