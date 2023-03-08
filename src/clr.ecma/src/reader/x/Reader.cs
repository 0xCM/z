//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static EcmaReader EcmaReader(this EcmaFile src)
            => Ecma.reader(src);

        public static ReadOnlySeq<uint> Terminators(this EcmaStringHeap src)
            => EcmaHeaps.terminators(src);
    }
}