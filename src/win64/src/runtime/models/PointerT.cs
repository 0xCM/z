// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime
{
    // Wrapper around pointers
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Pointer<T> where T : unmanaged
    {
        readonly T* _value;

        public T* Value
        {
            get
            {
                return _value;
            }
        }
    }
}
