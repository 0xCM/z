//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial class AsmCases
{
    public readonly struct MemOpCase<T>
        where T : unmanaged, IMemOp<T>
    {
        public readonly T Op;

        public readonly string Asm;

        [MethodImpl(Inline)]
        public MemOpCase(T op, string asm)
        {
            Op = op;
            Asm = asm;
        }

        public string Format()
            => Op.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MemOpCase(MemOpCase<T> src)
            => new MemOpCase(new MemOp(src.Op.Size, src.Op.Address), src.Asm);
    }
}
