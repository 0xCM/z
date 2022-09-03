//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class BinaryDigits : Seq<BinaryDigits,BinaryDigit>
    {
        public BinaryDigits()
        {

        }

        [MethodImpl(Inline)]
        public BinaryDigits(BinaryDigit[] src)
            : base(src)
        {

        }

        public override string Format()
            => Digital.format(Data.Storage);
    }
}