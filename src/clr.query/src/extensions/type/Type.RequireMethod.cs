// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Z0
{
    partial class ClrQuery
    {
        public static MethodInfo RequireMethod(this Type type, string name)
        {
            MethodInfo method = type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            Debug.Assert(method != null, $"Expected method '{name}' on type '{type.Name}'.");
            return method;
        }
    }
}