// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime
{
    // Wrapper around relative pointers
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct RelativePointer<T> 
        where T : unmanaged
    {
        readonly int _value;

        public T* Value
        {
            get
            {
                return (T*)((byte*)Unsafe.AsPointer(ref Unsafe.AsRef(in _value)) + _value);
            }
        }
    }
}