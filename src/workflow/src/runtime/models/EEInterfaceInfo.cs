// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct EEInterfaceInfo
    {
        [StructLayout(LayoutKind.Explicit)]
        unsafe struct InterfaceTypeUnion
        {
            [FieldOffset(0)]
            public MethodTable* _pInterfaceEEType;

            [FieldOffset(0)]
            public MethodTable** _ppInterfaceEETypeViaIAT;
        }

        InterfaceTypeUnion _interfaceType;

        public MethodTable* InterfaceType
        {
            get
            {
                if ((unchecked((uint)_interfaceType._pInterfaceEEType) & IndirectionConstants.IndirectionCellPointer) != 0)
                {
                    MethodTable** ppInterfaceEETypeViaIAT = (MethodTable**)(((ulong)_interfaceType._ppInterfaceEETypeViaIAT) - IndirectionConstants.IndirectionCellPointer);
                    return *ppInterfaceEETypeViaIAT;
                }

                return _interfaceType._pInterfaceEEType;
            }
            set
            {
                _interfaceType._pInterfaceEEType = value;
            }
        }
    }
}
