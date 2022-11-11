//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct CapturedAccessor
    {
        public readonly ApiEncoded Member;

        public readonly MemorySeg DataSegment;

        public readonly SpanResKind ResKind;

        [MethodImpl(Inline)]
        public CapturedAccessor(ApiEncoded member, MemorySeg data, SpanResKind kind)
        {
            Member = member;
            DataSegment = data;
            ResKind = kind;
        }

        public BinaryCode MemberCode
        {
            [MethodImpl(Inline)]
            get => Member.Code;
        }
    }
}