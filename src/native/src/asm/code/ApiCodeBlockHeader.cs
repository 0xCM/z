//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct ApiCodeBlockHeader
    {
        public readonly _OpUri Uri;

        public readonly @string DisplaySig;

        public readonly CodeBlock CodeBlock;

        public readonly ExtractTermCode TermCode;

        [MethodImpl(Inline)]
        public ApiCodeBlockHeader(_OpUri uri, string sig, CodeBlock code, ExtractTermCode term)
        {
            Uri = uri;
            DisplaySig = sig;
            CodeBlock = code;
            TermCode = term;
        }
    }
}