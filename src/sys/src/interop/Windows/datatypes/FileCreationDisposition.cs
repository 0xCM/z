// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    // Value used for CreateFile to determine how to behave in the presence (or absence) of a
    // file with the requested name.  Used only for CreateFile.
    public enum FileCreationDisposition : uint
    {
        CREATE_NEW = 1,

        CREATE_ALWAYS = 2,

        OPEN_EXISTING = 3,

        OPEN_ALWAYS = 4,

        TRUNCATE_EXISTING = 5
    }
}