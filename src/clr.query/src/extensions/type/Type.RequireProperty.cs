// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Z0
{
    partial class ClrQuery
    {
        public static PropertyInfo RequireProperty(this Type type, string name)
        {
            PropertyInfo property = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            Debug.Assert(property != null, $"Expected property '{name}' on type '{type.Name}'.");
            return property;
        }
    }
}
