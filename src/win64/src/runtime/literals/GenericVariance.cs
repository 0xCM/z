// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Internal.Runtime
{
    // Keep this synchronized with GenericVarianceType in rhbinder.h.
    public enum GenericVariance : byte
    {
        NonVariant = 0,

        Covariant = 1,

        Contravariant = 2,

        ArrayCovariant = 0x20,
    }
}
