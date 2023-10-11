//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedModels
{
    public readonly struct InstSig
    {
        public static InstSig init(byte n)
            => new (n);

        readonly Index<InstOperand> Ops;

        public readonly byte N;

        public InstSig(byte n)
        {
            N = n;
            Ops = alloc<InstOperand>(n);
        }

        public ref InstOperand this[byte i]
        {
            [MethodImpl(Inline)]
            get => ref Ops[i];
        }

        public string Format()
            => XedSigs.format(this);

        public override string ToString()
            => Format();

        public static InstSig Empty => default;
    }
}
