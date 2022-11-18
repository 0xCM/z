//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.DiaSymReader;

    public ref struct PdbReader
    {
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
            _DocumentMethods = UnmanagedDocs.Storage.Map(doc => PdbDocs.methods(provider,doc));
            _Methods = Index<PdbMethod>.Empty;
        }

        public void Dispose()
        {
            Source.Dispose();
        }

        public HResult<PdbMethod> Method(EcmaToken token)
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