//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct RegGrid16x64
    {
        ByteBlock128 Names;

        RegStore16x64 Values;

        [MethodImpl(Inline), UnscopedRef]
        public ref AsmRegName RegName(byte index)
            => ref seek(recover<AsmRegName>(Names.Bytes), index);

        [MethodImpl(Inline), UnscopedRef]
        public ref ulong RegVal(byte index)
            => ref Values[index];
    }
}