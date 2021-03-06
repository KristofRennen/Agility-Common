﻿Feature: Inversion Of Control
	In order to manage dynamic components and dependencies
	As an application
	I want to be able to register, resolve and unregister components

Background: 
	Given Provider has no registered components

Scenario: Register an unexisting component as transient
	Given Component Agility.Common.Specs.IComponent is not registered
	When  I try to register component Agility.Common.Specs.IComponent as a transient
	Then  Component Agility.Common.Specs.IComponent is registered

Scenario: Register an unexisting component as singleton
	Given Component Agility.Common.Specs.IComponent is not registered
	When  I try to register component Agility.Common.Specs.IComponent as a singleton
	Then  Component Agility.Common.Specs.IComponent is registered

Scenario: Register an existing transient component as transient
	Given Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to register component Agility.Common.Specs.IComponent as a transient
	Then  The system shows the error message "There is already a component registered for Agility.Common.Specs.IComponent"

Scenario: Register an existing singleton component as singleton
	Given Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to register component Agility.Common.Specs.IComponent as a singleton
	Then  The system shows the error message "There is already a component registered for Agility.Common.Specs.IComponent"

Scenario: Register an existing singleon component as transient
	Given Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to register component Agility.Common.Specs.IComponent as a transient
	Then  The system shows the error message "There is already a component registered for Agility.Common.Specs.IComponent"

Scenario: Register an existing transient component as singleton
	Given Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to register component Agility.Common.Specs.IComponent as a singleton
	Then  The system shows the error message "There is already a component registered for Agility.Common.Specs.IComponent"

Scenario: Register an unexisting generic component as transient
	Given Component Agility.Common.Specs.IGenericComponent is not registered
	When  I try to register component Agility.Common.Specs.IGenericComponent as a transient
	Then  Component Agility.Common.Specs.IGenericComponent is registered

Scenario: Register an unexisting generic component as singleton
	Given Component Agility.Common.Specs.IGenericComponent is not registered
	When  I try to register component Agility.Common.Specs.IGenericComponent as a singleton
	Then  Component Agility.Common.Specs.IGenericComponent is registered

Scenario: Register an existing generic component as transient
	Given Component Agility.Common.Specs.IGenericComponent is registered as a transient
	When  I try to register component Agility.Common.Specs.IGenericComponent as a transient
	Then  The system shows the error message "There is already a component registered for Agility.Common.Specs.IGenericComponent<Agility.Common.Specs.IComponent>"

Scenario: Register an existing generic component as singleton
	Given Component Agility.Common.Specs.IGenericComponent is registered as a singleton
	When  I try to register component Agility.Common.Specs.IGenericComponent as a singleton
	Then  The system shows the error message "There is already a component registered for Agility.Common.Specs.IGenericComponent<Agility.Common.Specs.IComponent>"

Scenario: Resolve an unexisting component
	Given Component Agility.Common.Specs.IComponent is not registered
	When  I try to resolve component Agility.Common.Specs.IComponent 1 time
	Then  The system shows the error message "There is no component registered for Agility.Common.Specs.IComponent"

Scenario: Resolve an existing transient component
	Given Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponent 1 time
	Then  An instance of component Agility.Common.Specs.IComponent is returned

Scenario: Resolve an existing singleton component
	Given Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponent 1 time
	Then  An instance of component Agility.Common.Specs.IComponent is returned

Scenario: Resolve an unexisting generic component
	Given Component Agility.Common.Specs.IGenericComponent is not registered
	When  I try to resolve component Agility.Common.Specs.IGenericComponent 1 time
	Then  The system shows the error message "There is no component registered for Agility.Common.Specs.IGenericComponent<Agility.Common.Specs.IComponent>"

Scenario: Resolve an existing generic component
	Given Component Agility.Common.Specs.IGenericComponent is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IGenericComponent 1 time
	Then  An instance of component Agility.Common.Specs.IGenericComponent is returned

Scenario: Transient components always return new instances
	Given Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponent 2 times
	Then  A new instance of component Agility.Common.Specs.IComponent is returned each time

Scenario: Singleton components always return the same instance
	Given Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponent 2 times
	Then  The same instance of component Agility.Common.Specs.IComponent is returned each time

Scenario: Resolve a component with registered transient constructor dependencies
	Given Component Agility.Common.Specs.IComponentWithConstructorDependency is registered as a transient
	And   Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponentWithConstructorDependency 1 time
	Then  An instance of component Agility.Common.Specs.IComponentWithConstructorDependency is returned
	And   Component Agility.Common.Specs.IComponentWithConstructorDependency has 1 dependency
	And   All Agility.Common.Specs.IComponent dependencies are new instances

Scenario: Resolve a component with registered singleton constructor dependencies
	Given Component Agility.Common.Specs.IComponentWithConstructorDependency is registered as a transient
	And   Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponentWithConstructorDependency 1 time
	Then  An instance of component Agility.Common.Specs.IComponentWithConstructorDependency is returned
	And   Component Agility.Common.Specs.IComponentWithConstructorDependency has 1 dependency
	And   All Agility.Common.Specs.IComponent dependencies are the same instances

Scenario: Resolve a component with registered transient property dependencies
	Given Component Agility.Common.Specs.IComponentWithPropertyDependency is registered as a transient
	And   Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponentWithPropertyDependency 1 time
	Then  An instance of component Agility.Common.Specs.IComponentWithPropertyDependency is returned
	And   Component Agility.Common.Specs.IComponentWithPropertyDependency has 1 dependency
	And   All Agility.Common.Specs.IComponent dependencies are new instances

Scenario: Resolve a component with registered singleton property dependencies
	Given Component Agility.Common.Specs.IComponentWithPropertyDependency is registered as a transient
	And   Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponentWithPropertyDependency 1 time
	Then  An instance of component Agility.Common.Specs.IComponentWithPropertyDependency is returned
	And   Component Agility.Common.Specs.IComponentWithPropertyDependency has 1 dependency
	And   All Agility.Common.Specs.IComponent dependencies are the same instances

Scenario: Resolve a component with registered transient dependencies
	Given Component Agility.Common.Specs.IComponentWithDependencies is registered as a transient
	And   Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponentWithDependencies 1 time
	Then  An instance of component Agility.Common.Specs.IComponentWithDependencies is returned
	And   Component Agility.Common.Specs.IComponentWithDependencies has 2 dependencies
	And   All Agility.Common.Specs.IComponent dependencies are new instances

Scenario: Resolve a component with registered singleton dependencies
	Given Component Agility.Common.Specs.IComponentWithDependencies is registered as a transient
	And   Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponentWithDependencies 1 time
	Then  An instance of component Agility.Common.Specs.IComponentWithDependencies is returned
	And   Component Agility.Common.Specs.IComponentWithDependencies has 2 dependencies
	And   All Agility.Common.Specs.IComponent dependencies are the same instances

Scenario: Resolve a component with registered generic dependencies
	Given Component Agility.Common.Specs.IComponentWithGenericDependencies is registered as a transient
	And   Component Agility.Common.Specs.IGenericComponent is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponentWithGenericDependencies 1 time
	Then  An instance of component Agility.Common.Specs.IComponentWithGenericDependencies is returned

Scenario: Resolve a component with unregistered transient constructor dependencies
	Given Component Agility.Common.Specs.IComponent is not registered
	But   Component Agility.Common.Specs.IComponentWithConstructorDependency is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponentWithConstructorDependency 1 time
	Then  The system shows the error message "There are unregistered dependencies for component Agility.Common.Specs.IComponentWithConstructorDependency"

Scenario: Resolve a component with unregistered singleton constructor dependencies
	Given Component Agility.Common.Specs.IComponent is not registered
	But   Component Agility.Common.Specs.IComponentWithConstructorDependency is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponentWithConstructorDependency 1 time
	Then  The system shows the error message "There are unregistered dependencies for component Agility.Common.Specs.IComponentWithConstructorDependency"

Scenario: Resolve a component with unregistered transient property dependencies
	Given Component Agility.Common.Specs.IComponent is not registered
	But   Component Agility.Common.Specs.IComponentWithPropertyDependency is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponentWithPropertyDependency 1 time
	Then  The system shows the error message "There are unregistered dependencies for component Agility.Common.Specs.IComponentWithPropertyDependency"

Scenario: Resolve a component with unregistered singleton property dependencies
	Given Component Agility.Common.Specs.IComponent is not registered
	But   Component Agility.Common.Specs.IComponentWithPropertyDependency is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponentWithPropertyDependency 1 time
	Then  The system shows the error message "There are unregistered dependencies for component Agility.Common.Specs.IComponentWithPropertyDependency"

Scenario: Resolve a component with unregistered transient dependencies
	Given Component Agility.Common.Specs.IComponent is not registered
	But   Component Agility.Common.Specs.IComponentWithDependencies is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponentWithDependencies 1 time
	Then  The system shows the error message "There are unregistered dependencies for component Agility.Common.Specs.IComponentWithDependencies"

Scenario: Resolve a component with unregistered singleton dependencies
	Given Component Agility.Common.Specs.IComponent is not registered
	But   Component Agility.Common.Specs.IComponentWithDependencies is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponentWithDependencies 1 time
	Then  The system shows the error message "There are unregistered dependencies for component Agility.Common.Specs.IComponentWithDependencies"

Scenario: Resolve a component with unregisterd generic dependencies
	Given Component Agility.Common.Specs.IGenericComponent is not registered
	But   Component Agility.Common.Specs.IComponentWithGenericDependencies is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponentWithGenericDependencies 1 time
	Then  The system shows the error message "There are unregistered dependencies for component Agility.Common.Specs.IComponentWithGenericDependencies"

Scenario: Unregister an unexisting component
	Given Component Agility.Common.Specs.IComponent is not registered
	When  I try to unregister component Agility.Common.Specs.IComponent
	Then  Component Agility.Common.Specs.IComponent is not registered

Scenario: Unregister a registered transient component
	Given Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to unregister component Agility.Common.Specs.IComponent
	Then  Component Agility.Common.Specs.IComponent is not registered

Scenario: Unregister a registered singleton component
	Given Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to unregister component Agility.Common.Specs.IComponent
	Then  Component Agility.Common.Specs.IComponent is not registered

Scenario: Unregister a registered transient component without touching other components
	Given Component Agility.Common.Specs.IComponent is registered as a transient
	And   Component Agility.Common.Specs.IGenericComponent is registered as a transient
	When  I try to unregister component Agility.Common.Specs.IComponent
	Then  Component Agility.Common.Specs.IComponent is not registered
	But   Component Agility.Common.Specs.IGenericComponent is registered

Scenario: Unregister a registered singleton component without touching other components
	Given Component Agility.Common.Specs.IComponent is registered as a singleton
	And   Component Agility.Common.Specs.IGenericComponent is registered as a singleton
	When  I try to unregister component Agility.Common.Specs.IComponent
	Then  Component Agility.Common.Specs.IComponent is not registered
	But   Component Agility.Common.Specs.IGenericComponent is registered