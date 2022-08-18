//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Pairs a symbol with it's hash
    /// </summary>
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct HashedSymbol
    {
        public readonly StringRef Symbol;

        public readonly Hash32 HashCode;

        [MethodImpl(Inline)]
        public HashedSymbol(StringRef symbol, Hash32 hash)
        {
            Symbol = symbol;
            HashCode = hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Symbol.IsEmpty || HashCode == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Symbol.IsNonEmpty && HashCode != 0;
        }

        public string Format()
            => Symbol.Format();

        public override string ToString()
            => Format();

        public static HashedSymbol Empty
        {
            [MethodImpl(Inline)]
            get => new HashedSymbol(StringRef.Empty, 0);
        }
    }
}