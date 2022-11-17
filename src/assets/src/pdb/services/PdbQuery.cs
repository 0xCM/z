//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using Microsoft.DiaSymReader;

    using static sys;

    [ApiHost]
    public unsafe readonly struct PdbQuery
    {
        public static Index<PdbSeqPoint> points(ISymUnmanagedMethod src)
            => src.GetSequencePoints().Array().Select(PdbDocs.point);

        [MethodImpl(Inline), Op]
        public static PdbKind pdbkind(in byte src)
            => portable(src) ? PdbKind.Portable : PdbKind.Legacy;

        [Op]
        public static PdbDocument[] documents(ISymUnmanagedMethod src)
            => src.GetDocumentsForMethod().Select(PdbDocs.doc);

        [MethodImpl(Inline), Op]
        public static PdbKind pdbkind(ReadOnlySpan<byte> src)
            => portable(src) ? PdbKind.Portable : PdbKind.Legacy;

        [MethodImpl(Inline), Op]
        public static unsafe PdbKind pdbkind(byte* pSrc)
            => portable(pSrc) ? PdbKind.Portable : PdbKind.Legacy;

        [MethodImpl(Inline), Op]
        public static PdbKind pdbkind(Stream src)
            => portable(src) ? PdbKind.Portable : PdbKind.Legacy;

        [MethodImpl(Inline),Op]
        public static bit portable(in byte src)
        {
            var result = bit.On;
            var j=0;
            result &= (skip(src, j++) == 'B');
            result &= (skip(src, j++) == 'S');
            result &= (skip(src, j++) == 'J');
            result &= (skip(src, j++) == 'B');
            return result;
        }

        [MethodImpl(Inline),Op]
        public static bit portable(ReadOnlySpan<byte> src)
            => portable(first(src));

        [MethodImpl(Inline),Op]
        public static unsafe bit portable(byte* pSrc)
            => portable(@ref(pSrc));

        [Op]
        public static bit portable(Stream pdb)
        {
            pdb.Position = 0;
            var test = pdb.ReadByte() == 'B' && pdb.ReadByte() == 'S' && pdb.ReadByte() == 'J' && pdb.ReadByte() == 'B';
            pdb.Position = 0;
            return test;
        }
    }
}