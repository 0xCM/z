// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime
{
    // Wrapper around pointers
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Pointer
    {
        readonly IntPtr _value;

        public IntPtr Value
        {
            get
            {
                return _value;
            }
        }
    }
}
