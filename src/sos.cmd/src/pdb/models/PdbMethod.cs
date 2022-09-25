//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.DiaSymReader;

    public readonly record struct PdbMethod : IAppSymAdapter<PdbMethod, ISymUnmanagedMethod>
    {
        [Op]
        public static uint SeqPointCount(PdbMethod src)
        {
            HResult result = src.Source.GetSequencePointCount(out var count);
            return result ? (uint)count : 0;
        }

        [Op]
        public static EcmaToken token(PdbMethod src)
        {
            HResult result = src.Source.GetToken(out var token);
            return result ? token : EcmaToken.Empty;
        }

        readonly ISymUnmanagedMethod Source;

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
            get => PdbMethod.token(this);
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