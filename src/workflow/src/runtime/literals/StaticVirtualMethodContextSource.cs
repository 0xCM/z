// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Internal.Runtime
{
    internal static class StaticVirtualMethodContextSource
    {
        public const ushort None = 0;

        public const ushort ContextFromThisClass = 1;

        public const ushort ContextFromFirstInterface = 2;
    }
}
