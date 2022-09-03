//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    public readonly struct CaSymbolKey
    {
        public readonly CaSymbol Symbol;

        public readonly ulong Key;

        [MethodImpl(Inline)]
        public CaSymbolKey(CaSymbol symbol, ulong key)
        {
            Symbol = symbol;
            Key = key;
        }

        public string Format()
            => string.Format("{0:x} {1}", Key, Symbol.Format());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CaSymbolKey((CaSymbol symbol, ulong key) src)
            => new CaSymbolKey(src.symbol, src.key);
    }
}