//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public readonly record struct ValueClass<T>
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

        [Render(1)]
        public readonly T Value;

        [MethodImpl(Inline)]
        public ValueClass(uint ordinal, Label @class, Label kind, Label symbol, T value)
        {
            Index = ordinal;
            Class = @class;
            Name = kind;
            Symbol = symbol;
            Value = value;
        }
    }
}