//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public struct AsmBroadcast
    {
        [MethodImpl(Inline)]
        public static AsmBroadcast define(byte id, BroadcastClass @class, asci16 symbol, byte src, byte dst)
            => new AsmBroadcast(id,@class,symbol, src, dst);

        const string TableId = "asm.broadcasts";

        [Render(8)]
        public byte Id;

        [Render(8)]
        public Ratio<byte> Ratio;

        [Render(8)]
        public asci16 Symbol;

        [MethodImpl(Inline)]
        public AsmBroadcast(byte id, BroadcastClass @class, asci16 symbol, byte src, byte dst)
        {
            Id = id;
            Symbol = symbol;
            Ratio = (src,dst);
        }

        public string Format()
            => Symbol.Format();

        public override string ToString()
            => Format();

        public static AsmBroadcast Empty => default;
    }
}