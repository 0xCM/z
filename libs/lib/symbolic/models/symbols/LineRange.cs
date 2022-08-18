//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct LineRange
    {
        public uint MinLineNumber {get;}

        public uint MaxLineNumber {get;}

        readonly Index<TextLine> Data;

        [MethodImpl(Inline), Op]
        public LineRange(uint min, uint max, TextLine[] src)
        {
            MinLineNumber = min;
            MaxLineNumber = max;
            Data = src;
        }

        public Span<TextLine> Edit
        {
            [MethodImpl(Inline), Op]
            get => Data.Edit;
        }

        public ReadOnlySpan<TextLine> View
        {
            [MethodImpl(Inline), Op]
            get => Data.View;
        }

        public void Render(ITextBuffer dst)
        {
            var lines = Data.View;
            for(var i=0; i<lines.Length; i++)
                dst.AppendLine(skip(lines,i));
        }
    }
}