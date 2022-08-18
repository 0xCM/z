//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CreditModel;

    using E = DocRef;
    using S = System.UInt64;
    using api = CreditBits;

    /// <summary>
    /// Defines a reference to document content
    /// </summary>
    [ApiComplete]
    public readonly struct DocRef : ITextual, IEquatable<DocRef>
    {
        readonly S State;

        public Vendor Vendor
        {
            [MethodImpl(Inline)]
            get => api.vendor(this);
        }

        public Volume Volume
        {
            [MethodImpl(Inline)]
            get => api.volume(this);
        }

        public Division Division
        {
            [MethodImpl(Inline)]
            get => api.division(this);
        }

        public Chapter Chapter
        {
            [MethodImpl(Inline)]
            get => api.chapter(this);
        }

        public Appendix Appendix
        {
            [MethodImpl(Inline)]
            get => api.appendix(this);
        }

        public Section Section
        {
            [MethodImpl(Inline)]
            get => api.section(this);
        }

        public Topic Topic
        {
            [MethodImpl(Inline)]
            get => api.topic(this);
        }

        public ContentRef Content
        {
            [MethodImpl(Inline)]
            get => api.content(this);
        }

        public E Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => State == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => State != 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(E src)
            => State == src.State;

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => State.GetHashCode();

        public override bool Equals(object src)
            => src is E entity && Equals(entity);

        [MethodImpl(Inline)]
        public DocRef(S data)
            => State = data;

        [MethodImpl(Inline)]
        public static implicit operator E(S src)
            => new DocRef(src);

        [MethodImpl(Inline)]
        public static implicit operator S(E src)
            => src.State;

        public static E Empty => new E(0);
    }
}