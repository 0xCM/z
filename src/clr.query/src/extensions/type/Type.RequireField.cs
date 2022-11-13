// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Z0
{
    partial class ClrQuery
    {
        public static FieldInfo RequireField(this Type type, string name)
        {
            FieldInfo field = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            Debug.Assert(field != null, $"Expected field '{name}' on type '{type.Name}'.");
            return field;
        }
    }
}
