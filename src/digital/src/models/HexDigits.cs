//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class HexDigits : Seq<HexDigits,HexDigit>
    {
        public HexDigits()
        {

        }

        [MethodImpl(Inline)]
        public HexDigits(HexDigit[] src)
            : base(src)
        {

        }

        public override string Format()
            => Digital.format(Data.Storage);
    }
}