//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public struct RegGrid16x64
    {
        ByteBlock128 Names;

        RegStore16x64 Values;

        [MethodImpl(Inline)]
        public ref AsmRegName RegName(byte index)
            => ref seek(recover<AsmRegName>(Names.Bytes), index);

        [MethodImpl(Inline)]
        public ref ulong RegVal(byte index)
            => ref Values[index];
    }
}