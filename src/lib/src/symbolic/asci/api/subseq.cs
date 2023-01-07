//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Asci
    {
        [Op]
        public static AsciSeq subseq<T>(T src, int i0, int i1)
            where T : unmanaged, IAsciSeq
                => new AsciSeq(sys.segment(sys.bytes(src), i0, i1).ToArray());
    }
}