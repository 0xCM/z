//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct TypedLiteral : IDataType<TypedLiteral>
    {
        public readonly Label LiteralName;

        public readonly TypeKey Base;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public TypedLiteral(Label literal, TypeKey @base, DataSize size)
        {
            LiteralName = literal;
            Base = @base;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => LiteralName.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => LiteralName.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => LiteralName.Hash;
        }

        public int CompareTo(TypedLiteral src)
            => LiteralName.CompareTo(src.LiteralName);

    }
}