using System;
using System.Collections.Generic;

namespace Agility.Common.Specs
{
    public interface IComponent { }
    public class Component : IComponent { }

    public interface IComponentWithConstructorDependency : IComponentWithDependencies { }
    public class ComponentWithConstructorDependency : ComponentWithDependencies, IComponentWithConstructorDependency { }

    public interface IComponentWithPropertyDependency : IComponentWithDependencies { }
    public class ComponentWithPropertyDependency : ComponentWithDependencies, IComponentWithPropertyDependency { }

    public interface IComponentWithDependencies
    {
        List<IComponent> Dependencies { get; set; }
    }

    public class ComponentWithDependencies : IComponentWithDependencies
    {
        protected ComponentWithDependencies()
        {
            Dependencies = new List<IComponent>();
        }

        public ComponentWithDependencies(IComponent component)
        {
            Dependencies = new List<IComponent>();
            Dependencies.Add(component);
        }

        public List<IComponent> Dependencies { get; set; }
        
        public IComponent Component
        {
            get
            {
                return null;
            } 
            set
            {
                Dependencies.Add(value);
            }
        }
    }

    public interface IGenericComponent<TArgument> { }

    public class GenericComponent<TArgument> : IGenericComponent<TArgument> { }

    public interface IComponentWithGenericDependencies { }

    public class ComponentWithGenericDependencies : IComponentWithGenericDependencies
    {
        private readonly IGenericComponent<IComponent> component;

        public ComponentWithGenericDependencies(IGenericComponent<IComponent> component)
        {
            this.component = component;
        }
    }
}