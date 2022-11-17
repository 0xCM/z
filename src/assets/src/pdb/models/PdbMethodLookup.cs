//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class PdbMethodLookup : Dictionary<ISymUnmanagedDocument,Index<ISymUnmanagedMethod>>
    {
        public static PdbMethodLookup create(ISymUnmanagedReader5 src)
        {
            var documents = src.GetDocuments().ToReadOnlySpan();
            var count = documents.Length;
            var dst = new PdbMethodLookup();
            for(var i=0; i<count; i++)
            {
                ref readonly var doc = ref skip(documents,i);
                dst[doc] = src.GetMethodsInDocument(doc);
            }
            return dst;
        }
    }
}