//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static DataTypes;

using P = PrimalType.Intrinsic;

/// <summary>
/// Defines a type that can produce anonymous or named <see cref='PrimalType'/> values
/// </summary>
[StructLayout(StructLayout,Pack=1)]
public readonly record struct LiteralType : IDataType<LiteralType>
{
    public readonly Label TypeName;

    public readonly PrimalType Base;

    public readonly DataSize Size;

    [MethodImpl(Inline)]
    public LiteralType(Label name, PrimalType @base, DataSize size)
    {
        TypeName = name;
        Base = @base;
        Size = size;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => TypeName.Hash | Size.Hash | Base.Hash;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => TypeName.IsEmpty;
    }

    public int CompareTo(LiteralType src)
        => TypeName.CompareTo(src.TypeName);

    public string Format()
        => TypeName.Format();

    public override string ToString()
        => Format();

    public readonly struct Intrinsic
    {
        /// <summary>
        /// Specifies runtime literal types that are considered intrinsic and which correspond to the
        /// sorts defined byte <see cref='NativeKind'/>
        /// </summary>
        public static Type[] ClrIntrinsic => new Type[]{
            typeof(Null),
            typeof(bit),
            typeof(byte),
            typeof(ushort),
            typeof(uint),
            typeof(long),
            typeof(void),
        };

        public static LiteralType Null => literal(Label.Empty, P.Empty, DataSize.Zero);

        public static LiteralType U1 => literal(P.U1.TypeName, P.U1, (1,8));

        public static LiteralType U8 => literal(P.U8.TypeName, P.U8, 8);

        public static LiteralType U16 => literal(P.U16.TypeName, P.U16, 16);

        public static LiteralType U32 => literal(P.U32.TypeName, P.U32, 32);

        public static LiteralType U64 => literal(P.U64.TypeName, P.U64, 64);

        public static LiteralType Void => literal(P.Void.TypeName, P.Void, DataSize.Zero);

        public static Intrinsic Types => new();

        public static implicit operator Index<NativeKind,LiteralType>(Intrinsic src)
            => _Types;

        static LiteralType[] _Types = new LiteralType[]
        {
            Null,
            U1,
            U8,
            U16,
            U32,
            U64,
            Void,
        };
    }
}
