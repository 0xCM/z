//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static bit hash(byte src)
            => (C)src == C.Hash;

        [MethodImpl(Inline), Op]
        public static bit hash(char src)
            => src == (char)C.Hash;

        [MethodImpl(Inline), Op]
        public static bit hash(AsciSymbol src)
            => src == (char)C.Hash;
    }
}