//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmOcTokens;
    /// <summary>
    /// [Index:[00000] | Token:[000]]
    /// </summary>
    public struct RexB
    {
        readonly byte Value;

        [MethodImpl(Inline)]
        public RexB(RexBToken token, RegIndexCode r, bit gpHi)
        {
            Value = math.or((byte)token, math.sll((byte)r,2), math.sll((byte)gpHi, 7));
        }

        public bit Enabled
        {
            [MethodImpl(Inline)]
            get => math.lteq((byte)Token, (byte)RexBToken.ro);
        }

        public bit Hi
        {
            [MethodImpl(Inline)]
            get => bit.test(Value,7);
        }

        public RexBToken Token
        {
            [MethodImpl(Inline)]
            get => (RexBToken)((byte)Value & 0b11);
        }

        public RegIndex Reg
        {
            [MethodImpl(Inline)]
            get => (math.srl((byte)Value,2) & 0b11111);
        }

        public NativeSize RegSize
        {
            [MethodImpl(Inline)]
            get => (NativeSizeCode)Token;
        }
    }
}