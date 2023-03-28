// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Internal.Runtime
{
    /// <summary>
    /// Represents the extra flags stored in the <c>_usComponentSize</c> field of a <c>System.Runtime.MethodTable</c>
    /// when <c>_usComponentSize</c> does not represent ComponentSize. (i.e. when the type is not an array, string or typedef)
    /// </summary>
    [Flags]
    public enum EETypeFlagsEx : ushort
    {
        HasEagerFinalizerFlag = 0x0001,
     
        HasCriticalFinalizerFlag = 0x0002,
     
        IsTrackedReferenceWithFinalizerFlag = 0x0004,
    }
}
