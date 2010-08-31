using System;

namespace Agility.Common.Infrastructure
{
    public class ComponentRegistrationException : ApplicationException
    {
        public ComponentRegistrationException(string message) : base(message) { }
    }
}