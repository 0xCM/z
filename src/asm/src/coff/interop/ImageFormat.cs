// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    // Represents the image format of a DLL or executable.
    [SymSource("images")]
    public enum ImageFormat : byte
    {
        Native,

        Managed,

        Unknown
    }
}