//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CaptureTransport : IDisposable
    {
        ReadOnlySeq<ApiEncoded> _Encoded = sys.empty<ApiEncoded>();

        ConcurrentBag<Assembly> _Parts = new();

        ConcurrentBag<IDisposable> Disposables = new();

        readonly IWfChannel Channel;

        internal readonly ICompositeDispenser Dispenser;

        public CaptureTransport(ICompositeDispenser dispenser, IWfChannel channel)        
        {
            Dispenser = dispenser;
            Channel = channel;
            Disposables.Add(dispenser);
        }

        [MethodImpl(Inline)]
        public ref readonly EncodedMembers Transmit(in EncodedMembers src)
        {
            return ref src;
        }

        [MethodImpl(Inline)]
        public ref readonly Seq<CollectedHost> Transmit(in Seq<CollectedHost> src)
        {
            return ref src;
        }

        [MethodImpl(Inline)]
        public ref readonly ApiMembers Resolved(in ApiMembers src)
        {
            return ref src;
        }

        [MethodImpl(Inline)]
        public ref readonly ReadOnlySeq<ApiCatalogEntry> Rebased(in ReadOnlySeq<ApiCatalogEntry> src)
        {
            return ref src;
        }

        [MethodImpl(Inline)]
        public ref readonly ReadOnlySeq<ApiCatalogEntry> Reloaded(in ReadOnlySeq<ApiCatalogEntry> src)
        {
            return ref src;
        }

        [MethodImpl(Inline)]
        public ref readonly ApiMemberCode Reloaded(in ApiMemberCode src)
        {
            Disposables.Add(src);
            return ref src;
        }

        [MethodImpl(Inline)]
        public ref readonly ReadOnlySeq<ApiEncoded> Encoded(in ReadOnlySeq<ApiEncoded> src)
        {
            _Encoded = src;
            return ref src;
        }

        [MethodImpl(Inline)]
        public ref readonly Assembly Transmit(in Assembly src)
        {
            _Parts.Add(src);
            return ref src;
        }

        [MethodImpl(Inline)]
        public void Captured(IApiPartCatalog src)
        {

        }


        void IDisposable.Dispose()
        {
            Disposables.Iter(d => d?.Dispose());
        }
    }
}