//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ExtractTermInfo
    {
        public readonly ExtractTermKind Kind;

        public readonly int Offset;

        public readonly sbyte Modifier;

        [MethodImpl(Inline)]
        public ExtractTermInfo(ExtractTermKind kind, int offset, sbyte modifier)
        {
            Offset = offset;
            Kind = kind;
            Modifier = modifier;
        }

        public bool TerminalFound
        {
            [MethodImpl(Inline)]
            get => (sbyte)Kind >= 0;
        }

        public static ExtractTermInfo Empty
        {
            [MethodImpl(Inline)]
            get => new ExtractTermInfo(ExtractTermKind.None, 0, 0);
        }
    }
}