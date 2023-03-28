// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Internal.Runtime
{
    public enum EETypeKind : uint
    {
        /// <summary>
        /// Represents a standard ECMA type
        /// </summary>
        CanonicalEEType = 0x00000000,

        /// <summary>
        /// Represents a type cloned from another MethodTable
        /// </summary>
        ClonedEEType = 0x00010000,

        /// <summary>
        /// Represents a parameterized type. For example a single dimensional array or pointer type
        /// </summary>
        ParameterizedEEType = 0x00020000,

        /// <summary>
        /// Represents an uninstantiated generic type definition
        /// </summary>
        GenericTypeDefEEType = 0x00030000,
    }
}
