//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    public readonly struct CaSymbolKey<T>
        where T : ICaSymbol
    {
        public readonly T Symbol;

        public readonly ulong Key;

        [MethodImpl(Inline)]
        public CaSymbolKey(T symbol, ulong key)
        {
            Symbol = symbol;
            Key = key;
        }

        public string Format()
            => string.Format("{0:x} {1}", Key, Symbol.Format());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CaSymbolKey(CaSymbolKey<T> src)
            => new CaSymbolKey(new CaSymbol(src.Symbol.Source), src.Key);

        [MethodImpl(Inline)]
        public static implicit operator CaSymbolKey<T>((T symbol, ulong key) src)
            => new CaSymbolKey<T>(src.symbol, src.key);
    }
}