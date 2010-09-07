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
}