//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;
    
    [SymSource(ecma)]
    public enum EcmaHeapKind : byte
    {
        None,

        UserString = 0x70,

        Blob = 0x71,

        Guid = 0x72,

        String = 0x78,
    }
}