//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a classification
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public readonly record struct ValueClass<K,T>
        where K : unmanaged
    {
        const string TableId = "api.classes";

        [Render(8)]
        public readonly uint Index;

        [Render(16)]
        public readonly Label Class;

        [Render(16)]
        public readonly Label Name;

        [Render(16)]
        public readonly Label Symbol;

        [Render(16)]
        public readonly K Kind;

        [Render(16)]
        public readonly T Value;

        [MethodImpl(Inline)]
        public ValueClass(uint index, Label @class, Label ident, Label symbol, K kind, T value)
        {
            Index = index;
            Class = @class;
            Name = ident;
            Symbol = symbol;
            Kind = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator ValueClass<T>(ValueClass<K,T> src)
            => src;
    }
}