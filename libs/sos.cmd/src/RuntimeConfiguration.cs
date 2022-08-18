// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace SOS
{
    /// <summary>
    /// Matches the IRuntime::RuntimeConfiguration in runtime.h
    /// </summary>
    public enum RuntimeConfiguration
    {
        WindowsDesktop = 0,

        WindowsCore = 1,

        UnixCore = 2,

        OSXCore = 3
    }
}