//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmHostRoutines : IIndex<AsmMemberRoutine>
    {
        readonly Index<AsmMemberRoutine> Data;

        [MethodImpl(Inline)]
        public AsmHostRoutines(AsmMemberRoutine[] src)
            => Data = src;

        public Index<AsmRoutine> AsmRoutines
        {
            [MethodImpl(Inline)]
            get => Data.Select(x => x.Routine);
        }

        public Index<ApiMember> Members
        {
            [MethodImpl(Inline)]
            get => Data.Select(x => x.Member);
        }

        public _ApiHostUri Host
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty ? Data.First.Member.Host : _ApiHostUri.Empty;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref AsmMemberRoutine First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ReadOnlySpan<AsmMemberRoutine> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<AsmMemberRoutine> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public AsmMemberRoutine[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmHostRoutines(AsmMemberRoutine[] src)
            => new AsmHostRoutines(src);

        public static AsmHostRoutines Empty
        {
            [MethodImpl(Inline)]
            get => new AsmHostRoutines(sys.empty<AsmMemberRoutine>());
        }
    }
}