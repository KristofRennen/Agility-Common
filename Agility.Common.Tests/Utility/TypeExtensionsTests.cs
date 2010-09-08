using Agility.Common.Utility;
using NUnit.Framework;

namespace Agility.Common.Tests.Utility
{
    [TestFixture]
    public class TypeExtensionsTests
    {
        [Test]
        public void NiceName_Null_EmptyStringReturned()
        {
            Assert.AreSame("", TypeExtensions.NiceName(null));
        }

        [Test]
        public void NiceName_ClassWithoutNamespace_ClassNameReturned()
        {
            Assert.AreEqual("ClassWithoutNamespace", typeof (ClassWithoutNamespace).NiceName());
        }

        [Test]
        public void NiceName_ClassWithNamespace_ClassWithNamespaceReturned()
        {
            Assert.AreEqual("Agility.Common.Tests.Utility.ClassWithNamespace", typeof(ClassWithNamespace).NiceName());
        }

        [Test]
        public void NiceName_ClassWithGenericParameters_ClassWithSimpleParameterNamesReturned()
        {
            Assert.AreEqual("Agility.Common.Tests.Utility.ClassWithGenericParameters<Agility.Common.Tests.Utility.ClassWithNamespace, Agility.Common.Tests.Utility.ClassWithNamespace>", typeof(ClassWithGenericParameters<ClassWithNamespace, ClassWithNamespace>).NiceName());
        }
    }

    class ClassWithNamespace { }
    class ClassWithGenericParameters<TParam1, TParam2> { }
}

class ClassWithoutNamespace { }