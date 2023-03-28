// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime
{
    // Wrapper around MethodTable pointers that may be indirected through the IAT if their low bit is set.
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct EETypeRef
    {
        byte* _value;

        public MethodTable* Value
        {
            get
            {
                if (((int)_value & IndirectionConstants.IndirectionCellPointer) == 0)
                    return (MethodTable*)_value;
                return *(MethodTable**)(_value - IndirectionConstants.IndirectionCellPointer);
            }
            set
            {
                _value = (byte*)value;
            }
        }
    }
}
