//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.DiaSymReader;
    using static Algs;

    public class PdbDocs
    {
        [MethodImpl(Inline), Op]        
        public static SymbolArchives symbols(IDbArchive root)
            => SymbolArchives.create(root);

        [MethodImpl(Inline), Op]        
        public static FS.Files pdbfiles(FS.FolderPath src)
            => src.Files(FS.Pdb, true);

        [MethodImpl(Inline), Op]
        public static PdbMethod method(ISymUnmanagedMethod src)
            => new PdbMethod(src);

        [MethodImpl(Inline), Op]
        public static PdbSeqPoint point(SymUnmanagedSequencePoint src)
            => new PdbSeqPoint((uint)src.Offset,
                ((uint)src.StartLine, (uint)src.StartColumn),
                ((uint)src.EndLine, (uint)src.EndColumn));

        [MethodImpl(Inline), Op]
        public static PdbDocument doc(ISymUnmanagedDocument src)
            => new PdbDocument(src, src.GetName(), src.GetDocumentType());

        [MethodImpl(Inline), Op]
        public static HResult<PdbMethod> method(PdbReader reader, CliToken token)
        {
            HResult result = reader.Provider.GetMethod((int)token, out var accessor);
            if(result)
                return PdbDocs.method(accessor);
            else
                return result;
        }

    }
}