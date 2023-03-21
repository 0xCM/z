//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SpanResAccessor
    {
        public readonly MethodEntryPoint Member;

        public readonly SpanResKind Kind;

        [MethodImpl(Inline)]
        public SpanResAccessor(MethodEntryPoint entry, SpanResKind format)
        {
            Member = entry;
            Kind = format;
        }

        public PartName Part
        {
            [MethodImpl(Inline)]
            get => Member.Uri.Part;
        }

        public ApiHostUri Host
        {
            [MethodImpl(Inline)]
            get => Member.Uri.Host;
        }

        public OpIdentity OpId
        {
            [MethodImpl(Inline)]
            get => Member.Uri.OpId;
        }

        public string OpName
        {
            [MethodImpl(Inline)]
            get => OpId.Name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Member.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }
    }
}