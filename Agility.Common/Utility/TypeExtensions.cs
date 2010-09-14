using System;

namespace Agility.Common.Utility
{
    /// <summary>
    /// Custom behaviour for <see cref="System.Type" />
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns a nice name for the given type in the format Namespace.Class&lt;Namespace.Class&gt;.
        /// </summary>
        /// <param name="type">The type to get the nice name for.</param>
        /// <returns>The nice name for the given type.</returns>
        public static string NiceName(this Type type)
        {
            if (type == null)
            {
                return "";
            }

            var name = "";

            if (!string.IsNullOrEmpty(type.Namespace))
            {
                name += type.Namespace;
                name += ".";
            }

            if (type.IsGenericType)
            {
                name += type.Name.Substring(0, type.Name.IndexOf("`"));
                name += "<";

                foreach (var genericArgument in type.GetGenericArguments())
                {
                    name += NiceName(genericArgument);
                    name += ", ";
                }

                name += ">";

                name = name.Replace(", >", ">");
            }
            else
            {
                name += type.Name;
            }

            return name;
        }
    }
}