using System;

namespace UITK.CodeBehind
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class HeaderNameAttribute : Attribute
    {
        public string HeaderName { get; }

        public HeaderNameAttribute(string headerName)
        {
            HeaderName = headerName;
        }
    }
}
