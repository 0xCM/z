//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct PdbMethod : IAppSymAdapter<PdbMethod, ISymUnmanagedMethod>
    {
        internal readonly ISymUnmanagedMethod Source;

        [MethodImpl(Inline)]
        internal PdbMethod(ISymUnmanagedMethod src)
        {
            Source = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source != null;
        }

        public EcmaToken Token
        {
            [MethodImpl(Inline)]
            get => PdbDocs.token(this);
        }

        public ReadOnlySpan<PdbSeqPoint> SequencePoints
        {
            [MethodImpl(Inline)]
            get => PdbQuery.points(Source);
        }

        public ReadOnlySpan<PdbDocument> Documents
        {
            [MethodImpl(Inline)]
            get => PdbQuery.documents(Source);
        }

        public PdbMethodInfo Describe()
        {
            var dst = new PdbMethodInfo();
            dst.Token = Token;
            dst.SequencePoints = PdbQuery.points(Source);
            dst.Documents = PdbQuery.documents(Source);
            return dst;
        }

        [MethodImpl(Inline)]
        public static bool operator true(PdbMethod src)
            => src.IsNonEmpty;

        [MethodImpl(Inline)]
        public static bool operator false(PdbMethod src)
            => src.IsEmpty;
    }
}