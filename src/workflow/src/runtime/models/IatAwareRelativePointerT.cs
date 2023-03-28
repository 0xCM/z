// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime
{
    // Wrapper around relative pointers that might be indirected through IAT
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct IatAwareRelativePointer<T> where T : unmanaged
    {
        readonly int _value;

        public T* Value
        {
            get
            {
                if ((_value & IndirectionConstants.IndirectionCellPointer) == 0)
                {
                    return (T*)((byte*)Unsafe.AsPointer(ref Unsafe.AsRef(in _value)) + _value);
                }
                else
                {
                    return *(T**)((byte*)Unsafe.AsPointer(ref Unsafe.AsRef(in _value)) + (_value & ~IndirectionConstants.IndirectionCellPointer));
                }
            }
        }
    }
}
