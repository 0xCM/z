//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.DiaSymReader;

    public class PdbDocs
    {
        [MethodImpl(Inline), Op]        
        public static SymbolArchives symbols(FolderPath root)
            => SymbolArchives.create(root);

        [MethodImpl(Inline), Op]        
        public static Files pdbfiles(FolderPath src)
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
        public static HResult<PdbMethod> method(PdbReader reader, EcmaToken token)
        {
            HResult result = reader.Provider.GetMethod((int)token, out var accessor);
            if(result)
                return PdbDocs.method(accessor);
            else
                return result;
        }

    }
}