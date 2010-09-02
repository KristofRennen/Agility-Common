using System;

namespace Agility.Common.Infrastructure
{
    /// <summary>
    /// The exception which is thrown when component registration or resolution fails.
    /// </summary>
    public class ComponentRegistrationException : ApplicationException
    {
        /// <summary>
        /// Initializes a new ComponentRegistrationException with a specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public ComponentRegistrationException(string message) : base(message) { }
    }
}