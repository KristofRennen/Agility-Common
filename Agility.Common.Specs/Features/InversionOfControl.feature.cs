// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.3.5.2
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace Agility.Common.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Inversion Of Control")]
    public partial class InversionOfControlFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "InversionOfControl.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Inversion Of Control", "In order to manage dynamic components and dependencies\r\nAs an application\r\nI want" +
                    " to be able to register and resolve components", ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            this.FeatureBackground();
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
testRunner.Given("Provider has no registered components");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register an unexisting component as transient")]
        public virtual void RegisterAnUnexistingComponentAsTransient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register an unexisting component as transient", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.Given("Component Agility.Common.Specs.IComponent is not registered");
#line 11
testRunner.When("I try to register component Agility.Common.Specs.IComponent as a transient");
#line 12
testRunner.Then("Component Agility.Common.Specs.IComponent is registered");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register an unexisting component as singleton")]
        public virtual void RegisterAnUnexistingComponentAsSingleton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register an unexisting component as singleton", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
testRunner.Given("Component Agility.Common.Specs.IComponent is not registered");
#line 16
testRunner.When("I try to register component Agility.Common.Specs.IComponent as a singleton");
#line 17
testRunner.Then("Component Agility.Common.Specs.IComponent is registered");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register an existing transient component as transient")]
        public virtual void RegisterAnExistingTransientComponentAsTransient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register an existing transient component as transient", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
testRunner.Given("Component Agility.Common.Specs.IComponent is registered as a transient");
#line 21
testRunner.When("I try to register component Agility.Common.Specs.IComponent as a transient");
#line 22
testRunner.Then("The system shows the error message \"There is already a component registered for A" +
                    "gility.Common.Specs.IComponent\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register an existing singleton component as singleton")]
        public virtual void RegisterAnExistingSingletonComponentAsSingleton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register an existing singleton component as singleton", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
testRunner.Given("Component Agility.Common.Specs.IComponent is registered as a singleton");
#line 26
testRunner.When("I try to register component Agility.Common.Specs.IComponent as a singleton");
#line 27
testRunner.Then("The system shows the error message \"There is already a component registered for A" +
                    "gility.Common.Specs.IComponent\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register an existing singleon component as transient")]
        public virtual void RegisterAnExistingSingleonComponentAsTransient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register an existing singleon component as transient", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
testRunner.Given("Component Agility.Common.Specs.IComponent is registered as a singleton");
#line 31
testRunner.When("I try to register component Agility.Common.Specs.IComponent as a transient");
#line 32
testRunner.Then("The system shows the error message \"There is already a component registered for A" +
                    "gility.Common.Specs.IComponent\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register an existing transient component as singleton")]
        public virtual void RegisterAnExistingTransientComponentAsSingleton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register an existing transient component as singleton", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
testRunner.Given("Component Agility.Common.Specs.IComponent is registered as a transient");
#line 36
testRunner.When("I try to register component Agility.Common.Specs.IComponent as a singleton");
#line 37
testRunner.Then("The system shows the error message \"There is already a component registered for A" +
                    "gility.Common.Specs.IComponent\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve an unexisting component")]
        public virtual void ResolveAnUnexistingComponent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve an unexisting component", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
testRunner.Given("Component Agility.Common.Specs.IComponent is not registered");
#line 41
testRunner.When("I try to resolve component Agility.Common.Specs.IComponent 1 time");
#line 42
testRunner.Then("The system shows the error message \"There is no component registered for Agility." +
                    "Common.Specs.IComponent\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve an existing transient component")]
        public virtual void ResolveAnExistingTransientComponent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve an existing transient component", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
testRunner.Given("Component Agility.Common.Specs.IComponent is registered as a transient");
#line 46
testRunner.When("I try to resolve component Agility.Common.Specs.IComponent 1 time");
#line 47
testRunner.Then("An instance of component Agility.Common.Specs.IComponent is returned");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve an existing singleton component")]
        public virtual void ResolveAnExistingSingletonComponent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve an existing singleton component", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
testRunner.Given("Component Agility.Common.Specs.IComponent is registered as a singleton");
#line 51
testRunner.When("I try to resolve component Agility.Common.Specs.IComponent 1 time");
#line 52
testRunner.Then("An instance of component Agility.Common.Specs.IComponent is returned");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Transient components always return new instances")]
        public virtual void TransientComponentsAlwaysReturnNewInstances()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Transient components always return new instances", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
testRunner.Given("Component Agility.Common.Specs.IComponent is registered as a transient");
#line 56
testRunner.When("I try to resolve component Agility.Common.Specs.IComponent 2 times");
#line 57
testRunner.Then("A new instance of component Agility.Common.Specs.IComponent is returned each time" +
                    "");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Singleton components always return the same instance")]
        public virtual void SingletonComponentsAlwaysReturnTheSameInstance()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Singleton components always return the same instance", ((string[])(null)));
#line 59
this.ScenarioSetup(scenarioInfo);
#line 60
testRunner.Given("Component Agility.Common.Specs.IComponent is registered as a singleton");
#line 61
testRunner.When("I try to resolve component Agility.Common.Specs.IComponent 2 times");
#line 62
testRunner.Then("The same instance of component Agility.Common.Specs.IComponent is returned each t" +
                    "ime");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with registered transient constructor dependencies")]
        public virtual void ResolveAComponentWithRegisteredTransientConstructorDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with registered transient constructor dependencies", ((string[])(null)));
#line 64
this.ScenarioSetup(scenarioInfo);
#line 65
testRunner.Given("Component Agility.Common.Specs.IComponentWithConstructorDependency is registered " +
                    "as a transient");
#line 66
testRunner.And("Component Agility.Common.Specs.IComponent is registered as a transient");
#line 67
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithConstructorDependen" +
                    "cy 1 time");
#line 68
testRunner.Then("An instance of component Agility.Common.Specs.IComponentWithConstructorDependency" +
                    " is returned");
#line 69
testRunner.And("Component Agility.Common.Specs.IComponentWithConstructorDependency has 1 dependen" +
                    "cy");
#line 70
testRunner.And("All Agility.Common.Specs.IComponent dependencies are new instances");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with registered singleton constructor dependencies")]
        public virtual void ResolveAComponentWithRegisteredSingletonConstructorDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with registered singleton constructor dependencies", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
testRunner.Given("Component Agility.Common.Specs.IComponentWithConstructorDependency is registered " +
                    "as a transient");
#line 74
testRunner.And("Component Agility.Common.Specs.IComponent is registered as a singleton");
#line 75
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithConstructorDependen" +
                    "cy 1 time");
#line 76
testRunner.Then("An instance of component Agility.Common.Specs.IComponentWithConstructorDependency" +
                    " is returned");
#line 77
testRunner.And("Component Agility.Common.Specs.IComponentWithConstructorDependency has 1 dependen" +
                    "cy");
#line 78
testRunner.And("All Agility.Common.Specs.IComponent dependencies are the same instances");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with registered transient property dependencies")]
        public virtual void ResolveAComponentWithRegisteredTransientPropertyDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with registered transient property dependencies", ((string[])(null)));
#line 80
this.ScenarioSetup(scenarioInfo);
#line 81
testRunner.Given("Component Agility.Common.Specs.IComponentWithPropertyDependency is registered as " +
                    "a transient");
#line 82
testRunner.And("Component Agility.Common.Specs.IComponent is registered as a transient");
#line 83
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithPropertyDependency " +
                    "1 time");
#line 84
testRunner.Then("An instance of component Agility.Common.Specs.IComponentWithPropertyDependency is" +
                    " returned");
#line 85
testRunner.And("Component Agility.Common.Specs.IComponentWithPropertyDependency has 1 dependency");
#line 86
testRunner.And("All Agility.Common.Specs.IComponent dependencies are new instances");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with registered singleton property dependencies")]
        public virtual void ResolveAComponentWithRegisteredSingletonPropertyDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with registered singleton property dependencies", ((string[])(null)));
#line 88
this.ScenarioSetup(scenarioInfo);
#line 89
testRunner.Given("Component Agility.Common.Specs.IComponentWithPropertyDependency is registered as " +
                    "a transient");
#line 90
testRunner.And("Component Agility.Common.Specs.IComponent is registered as a singleton");
#line 91
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithPropertyDependency " +
                    "1 time");
#line 92
testRunner.Then("An instance of component Agility.Common.Specs.IComponentWithPropertyDependency is" +
                    " returned");
#line 93
testRunner.And("Component Agility.Common.Specs.IComponentWithPropertyDependency has 1 dependency");
#line 94
testRunner.And("All Agility.Common.Specs.IComponent dependencies are the same instances");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with registered transient dependencies")]
        public virtual void ResolveAComponentWithRegisteredTransientDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with registered transient dependencies", ((string[])(null)));
#line 96
this.ScenarioSetup(scenarioInfo);
#line 97
testRunner.Given("Component Agility.Common.Specs.IComponentWithDependencies is registered as a tran" +
                    "sient");
#line 98
testRunner.And("Component Agility.Common.Specs.IComponent is registered as a transient");
#line 99
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithDependencies 1 time" +
                    "");
#line 100
testRunner.Then("An instance of component Agility.Common.Specs.IComponentWithDependencies is retur" +
                    "ned");
#line 101
testRunner.And("Component Agility.Common.Specs.IComponentWithDependencies has 2 dependencies");
#line 102
testRunner.And("All Agility.Common.Specs.IComponent dependencies are new instances");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with registered singleton dependencies")]
        public virtual void ResolveAComponentWithRegisteredSingletonDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with registered singleton dependencies", ((string[])(null)));
#line 104
this.ScenarioSetup(scenarioInfo);
#line 105
testRunner.Given("Component Agility.Common.Specs.IComponentWithDependencies is registered as a tran" +
                    "sient");
#line 106
testRunner.And("Component Agility.Common.Specs.IComponent is registered as a singleton");
#line 107
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithDependencies 1 time" +
                    "");
#line 108
testRunner.Then("An instance of component Agility.Common.Specs.IComponentWithDependencies is retur" +
                    "ned");
#line 109
testRunner.And("Component Agility.Common.Specs.IComponentWithDependencies has 2 dependencies");
#line 110
testRunner.And("All Agility.Common.Specs.IComponent dependencies are the same instances");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with unregistered transient constructor dependencies")]
        public virtual void ResolveAComponentWithUnregisteredTransientConstructorDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with unregistered transient constructor dependencies", ((string[])(null)));
#line 112
this.ScenarioSetup(scenarioInfo);
#line 113
testRunner.Given("Component Agility.Common.Specs.IComponent is not registered");
#line 114
testRunner.But("Component Agility.Common.Specs.IComponentWithConstructorDependency is registered " +
                    "as a transient");
#line 115
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithConstructorDependen" +
                    "cy 1 time");
#line 116
testRunner.Then("The system shows the error message \"There are unregistered dependencies for compo" +
                    "nent Agility.Common.Specs.IComponentWithConstructorDependency\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with unregistered singleton constructor dependencies")]
        public virtual void ResolveAComponentWithUnregisteredSingletonConstructorDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with unregistered singleton constructor dependencies", ((string[])(null)));
#line 118
this.ScenarioSetup(scenarioInfo);
#line 119
testRunner.Given("Component Agility.Common.Specs.IComponent is not registered");
#line 120
testRunner.But("Component Agility.Common.Specs.IComponentWithConstructorDependency is registered " +
                    "as a singleton");
#line 121
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithConstructorDependen" +
                    "cy 1 time");
#line 122
testRunner.Then("The system shows the error message \"There are unregistered dependencies for compo" +
                    "nent Agility.Common.Specs.IComponentWithConstructorDependency\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with unregistered transient property dependencies")]
        public virtual void ResolveAComponentWithUnregisteredTransientPropertyDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with unregistered transient property dependencies", ((string[])(null)));
#line 124
this.ScenarioSetup(scenarioInfo);
#line 125
testRunner.Given("Component Agility.Common.Specs.IComponent is not registered");
#line 126
testRunner.But("Component Agility.Common.Specs.IComponentWithPropertyDependency is registered as " +
                    "a transient");
#line 127
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithPropertyDependency " +
                    "1 time");
#line 128
testRunner.Then("The system shows the error message \"There are unregistered dependencies for compo" +
                    "nent Agility.Common.Specs.IComponentWithPropertyDependency\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with unregistered singleton property dependencies")]
        public virtual void ResolveAComponentWithUnregisteredSingletonPropertyDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with unregistered singleton property dependencies", ((string[])(null)));
#line 130
this.ScenarioSetup(scenarioInfo);
#line 131
testRunner.Given("Component Agility.Common.Specs.IComponent is not registered");
#line 132
testRunner.But("Component Agility.Common.Specs.IComponentWithPropertyDependency is registered as " +
                    "a singleton");
#line 133
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithPropertyDependency " +
                    "1 time");
#line 134
testRunner.Then("The system shows the error message \"There are unregistered dependencies for compo" +
                    "nent Agility.Common.Specs.IComponentWithPropertyDependency\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with unregistered transient dependencies")]
        public virtual void ResolveAComponentWithUnregisteredTransientDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with unregistered transient dependencies", ((string[])(null)));
#line 136
this.ScenarioSetup(scenarioInfo);
#line 137
testRunner.Given("Component Agility.Common.Specs.IComponent is not registered");
#line 138
testRunner.But("Component Agility.Common.Specs.IComponentWithDependencies is registered as a tran" +
                    "sient");
#line 139
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithDependencies 1 time" +
                    "");
#line 140
testRunner.Then("The system shows the error message \"There are unregistered dependencies for compo" +
                    "nent Agility.Common.Specs.IComponentWithDependencies\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a component with unregistered singleton dependencies")]
        public virtual void ResolveAComponentWithUnregisteredSingletonDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a component with unregistered singleton dependencies", ((string[])(null)));
#line 142
this.ScenarioSetup(scenarioInfo);
#line 143
testRunner.Given("Component Agility.Common.Specs.IComponent is not registered");
#line 144
testRunner.But("Component Agility.Common.Specs.IComponentWithDependencies is registered as a sing" +
                    "leton");
#line 145
testRunner.When("I try to resolve component Agility.Common.Specs.IComponentWithDependencies 1 time" +
                    "");
#line 146
testRunner.Then("The system shows the error message \"There are unregistered dependencies for compo" +
                    "nent Agility.Common.Specs.IComponentWithDependencies\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
