//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct TypedLiteral : IDataType<TypedLiteral>
    {
        public readonly asci64 LiteralName;

        public readonly TypeKey Base;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public TypedLiteral(asci64 literal, TypeKey @base, DataSize size)
        {
            LiteralName = literal;
            Base = @base;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => LiteralName.IsNull;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !LiteralName.IsNull;
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