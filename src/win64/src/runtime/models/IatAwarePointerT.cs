// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime
{
    // Wrapper around pointers that might be indirected through IAT
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct IatAwarePointer<T> where T : unmanaged
    {
        readonly T* _value;

        public T* Value
        {
            get
            {
                if (((int)_value & IndirectionConstants.IndirectionCellPointer) == 0)
                    return _value;
                return *(T**)((byte*)_value - IndirectionConstants.IndirectionCellPointer);
            }
        }
    }
}
