//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    [SymSource(ecma)]
    public enum EcmaStringKind : byte
    {
        None = 0,

        System = 1,

        User = 2
    }
}