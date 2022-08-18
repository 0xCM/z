//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public struct EvexPrefix
    {
        readonly uint Data;

        [MethodImpl(Inline)]
        internal EvexPrefix(uint data)
        {
            Data = data;
        }

        public string Format()
            => Data == 0 ? EmptyString : bytes(Data).FormatHex();

        public override string ToString()
            => Format();
    }
}