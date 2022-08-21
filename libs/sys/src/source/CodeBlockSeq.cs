//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct CodeBlockSeq
    {
        public readonly uint LibSeq;

        public readonly uint TypeSeq;

        public readonly uint BlockSeq;

        [MethodImpl(Inline)]
        public CodeBlockSeq(uint lib, uint type, uint block)
        {
            LibSeq = lib;
            TypeSeq = type;
            BlockSeq = block;
        }

        public string Format()
            => string.Format("{0:D3}:{1:D4}:{2:D6}", LibSeq, TypeSeq, BlockSeq);

        public override string ToString()
            => Format();

        public static CodeBlockSeq Empty => default;
    }
}