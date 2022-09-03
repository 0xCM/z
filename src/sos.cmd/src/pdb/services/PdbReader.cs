//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.DiaSymReader;
    //using Microsoft.DiaSymReader.PortablePdb;

    public ref struct PdbReader
    {
        public static PdbReader create(PdbSymbolSource src)
        {
            var reader = default(PdbReader);
            if(src.IsPortable)
                reader = new PdbReader(src, portable(src));
            else
                reader = new PdbReader(src, legacy(src));
            return reader;
        }

        static object importer(in PdbSymbolSource src)
            => SymUnmanagedReaderFactory.CreateSymReaderMetadataImport(PdbSymbols.metadata(src));

        static ISymUnmanagedReader5 portable(in PdbSymbolSource src)
            =>default; 
            //(ISymUnmanagedReader5)new  SymBinder().GetReaderFromStream(src.PdbStream, importer(src));

        static ISymUnmanagedReader5 legacy(in PdbSymbolSource src)
            => SymUnmanagedReaderFactory.CreateReader<ISymUnmanagedReader5>(src.PdbStream, PdbSymbols.metadata(src));

        Index<PdbDocument> _Documents;

        Index<ISymUnmanagedDocument> UnmanagedDocs;

        Index<PdbMethods> _DocumentMethods;

        public readonly PdbSymbolSource Source;

        internal readonly ISymUnmanagedReader5 Provider;

        Index<PdbMethod> _Methods;

        [MethodImpl(Inline)]
        internal PdbReader(PdbSymbolSource src, ISymUnmanagedReader5 provider)
        {
            Source = src;
            Provider = provider;
            UnmanagedDocs = provider.GetDocuments();
            _Documents = provider.GetDocuments().Select(PdbDocs.doc);
            _DocumentMethods = UnmanagedDocs.Storage.Map(doc => PdbMethods.load(provider,doc));
            _Methods = Index<PdbMethod>.Empty;
        }

        public void Dispose()
        {
            Source.Dispose();
        }

        public HResult<PdbMethod> Method(CliToken token)
            => PdbDocs.method(this, token);

        public ReadOnlySpan<PdbMethod> Methods
        {
            get
            {
                if(_Methods.IsEmpty)
                    _Methods = _DocumentMethods.SelectMany(x => x.Methods).Select(PdbDocs.method);
                return _Methods;
            }
        }

        public ReadOnlySpan<PdbDocument> Documents
        {
            [MethodImpl(Inline)]
            get => _Documents.View;
        }
    }
}