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

        readonly WfEmit Channel;

        internal readonly ICompositeDispenser Dispenser;

        public CaptureTransport(ICompositeDispenser dispenser, WfEmit channel)        
        {
            Dispenser = dispenser;
            Channel = channel;
            Disposables.Add(dispenser);
        }

        public ref readonly EncodedMembers Transmit(in EncodedMembers src)
        {
            return ref src;
        }

        public ref readonly Seq<CollectedHost> Transmit(in Seq<CollectedHost> src)
        {
            return ref src;
        }

        public ref readonly ApiMembers TransmitResolved(in ApiMembers src)
        {
            return ref src;
        }

        public ref readonly ReadOnlySeq<ApiCatalogEntry> TransmitRebased(in ReadOnlySeq<ApiCatalogEntry> src)
        {
            return ref src;
        }

        public ref readonly ReadOnlySeq<ApiCatalogEntry> TransmitReloaded(in ReadOnlySeq<ApiCatalogEntry> src)
        {
            return ref src;
        }

        public ref readonly ApiMemberCode TransmitReloaded(in ApiMemberCode src)
        {
            Disposables.Add(src);
            return ref src;
        }

        public ref readonly ReadOnlySeq<ApiEncoded> Transmit(in ReadOnlySeq<ApiEncoded> src)
        {
            _Encoded = src;
            return ref src;
        }

        public ref readonly Assembly Transmit(in Assembly src)
        {
            _Parts.Add(src);
            return ref src;
        }

        public void Captured(IApiPartCatalog src)
        {

        }

        public ref readonly ReadOnlySeq<ApiEncoded> Encoded
        {
            [MethodImpl(Inline)]
            get => ref _Encoded;
        }

        void IDisposable.Dispose()
        {
            Disposables.Iter(d => d?.Dispose());
        }
    }
}