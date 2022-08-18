//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NasmListLine : ITextual
    {
        public TextLine Text {get;}

        [MethodImpl(Inline)]
        public NasmListLine(TextLine text)
        {
            Text = text;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Text.Data;
        }

        public string Content
        {
            [MethodImpl(Inline)]
            get => Text.Content;
        }

        public uint LineNumber
        {
            [MethodImpl(Inline)]
            get => Text.LineNumber;
        }
        public string Format()
            => Text.Format();

        public override string ToString()
            => Format();
    }
}