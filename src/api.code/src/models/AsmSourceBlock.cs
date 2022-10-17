//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmSourceBlock
    {
        public readonly Index<TextLine> Code;

        [MethodImpl(Inline)]
        public AsmSourceBlock(Index<TextLine> lines)
        {
            Code  = lines;
        }

        public Span<TextLine> Edit
        {
            [MethodImpl(Inline)]
            get => Code.Edit;
        }

        public ReadOnlySpan<TextLine> View
        {
            [MethodImpl(Inline)]
            get => Code.View;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Code.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Code.IsNonEmpty;
        }
    }
}