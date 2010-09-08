using System;

namespace Agility.Common.Utility
{
    public static class TypeExtensions
    {
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