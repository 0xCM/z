// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Z0
{
    partial class ClrQuery
    {
        const NumericKind Closure = NumericKind.UnsignedInts;

        public static string GetILSig(this FieldInfo field)
            => field.DeclaringType.GetILSig() + "::" + field.Name;
    }
}