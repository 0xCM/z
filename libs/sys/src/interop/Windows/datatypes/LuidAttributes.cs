// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    public enum LuidAttributes : uint
    {
        Disabled = 0x00000000,
        
        EnabledByDefault = 0x00000001,
        
        Enabled = 0x00000002,
        
        PrivelegedUsedForAccess = 0x80000000
    }
}