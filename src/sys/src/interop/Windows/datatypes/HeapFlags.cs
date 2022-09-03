// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    public enum HeapFlags : uint
    {
        None = 0x00000000,

        NoSerialize = 0x00000001,

        GenerateExceptions = 0x00000004,

        ZeroMemory = 0x00000008
    }
}
