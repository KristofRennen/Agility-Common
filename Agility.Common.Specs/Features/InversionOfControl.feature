Feature: Inversion Of Control
	In order to manage dynamic components and dependencies
	As an application
	I want to be able to register and resolve components

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

Scenario: Resolve an unexisting component
	Given Component Agility.Common.Specs.IComponent is not registered
	When  I try to resolve component Agility.Common.Specs.IComponent
	Then  The system shows the error message "There is no component registered for Agility.Common.Specs.IComponent"

Scenario: Resolve an existing transient component
	Given Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponent
	Then  An instance of component Agility.Common.Specs.IComponent is returned

Scenario: Resolve an existing singleton component
	Given Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponent
	Then  An instance of component Agility.Common.Specs.IComponent is returned

Scenario: Transient components always return new instances
	Given Component Agility.Common.Specs.IComponent is registered as a transient
	When  I try to resolve component Agility.Common.Specs.IComponent multiple times
	Then  A new instance of component Agility.Common.Specs.IComponent is returned each time

Scenario: Singleton components always return the same instance
	Given Component Agility.Common.Specs.IComponent is registered as a singleton
	When  I try to resolve component Agility.Common.Specs.IComponent multiple times
	Then  The same instance of component Agility.Common.Specs.IComponent is returned each time