// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-getprocessworkingsetsizeex
    /// </summary>
    [Flags]
    public enum WorkingSetFlags : uint
    {
        None = 0,

        /// <summary>
        /// The working set may fall below the minimum working set limit if memory demands are high.
        /// QUOTA_LIMITS_HARDWS_MIN_DISABLE
        /// </summary>
        MinDisable = 0x00000002,

        /// <summary>
        /// The working set will not fall below the minimum working set limit.
        /// QUOTA_LIMITS_HARDWS_MIN_ENABLE
        /// </summary>
        MinEnable = 0x00000001,

        /// <summary>
        /// The working set may exceed the maximum working set limit if there is abundant memory.
        /// QUOTA_LIMITS_HARDWS_MAX_DISABLE
        /// </summary>
        MaxDisable = 0x00000008,

        /// <summary>
        /// The working set will not exceed the maximum working set limit.
        /// QUOTA_LIMITS_HARDWS_MAX_ENABLE
        /// </summary>
        MaxEnable = 0x00000004,
    }
}