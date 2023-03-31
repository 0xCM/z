// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime
{
    // Wrapper around relative pointers
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct RelativePointer
    {
        readonly int _value;

        public unsafe IntPtr Value
        {
            get
            {
                return (IntPtr)((byte*)Unsafe.AsPointer(ref Unsafe.AsRef(in _value)) + _value);
            }
        }
    }
}
