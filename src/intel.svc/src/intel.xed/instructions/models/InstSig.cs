//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedRules
    {
        public readonly struct InstSig
        {
            public static InstSig init(byte n)
                => new InstSig(n);

            readonly Index<InstOperand> Ops;

            public readonly byte N;

            public readonly ushort PackedWidth;

            public InstSig(byte n)
            {
                N = n;
                Ops = alloc<InstOperand>(n);
                PackedWidth = (ushort)(n*InstOperand.Width);
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
}