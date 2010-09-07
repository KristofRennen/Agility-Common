namespace Agility.Common.Specs
{
    public interface IComponent { }
    public class Component : IComponent { }

    public interface IComponentWithConstructorDependency
    {
        
    }

    public class ComponentWithConstructorDependency : IComponentWithConstructorDependency
    {
        
    }

    public interface IComponentWithPropertyDependency
    {
        
    }

    public class ComponentWithPropertyDependency : IComponentWithPropertyDependency
    {
        
    }

    public interface IComponentWithDependencies
    {
        
    }

    public class ComponentWithDependencies : IComponentWithDependencies
    {
        
    }
}