//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static DataTypes;

    using P = PrimalType.Intrinsic;

    /// <summary>
    /// Defines either an intrinsic numeric type or a refinement of such
    /// </summary>
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct NumericType : IDataType<NumericType>
    {
        public readonly TypeKey Key;

        public readonly Label TypeName;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public NumericType(TypeKey key, Label name, DataSize size)
        {
            Key = key;
            TypeName = name;
            Size = size;
        }

        [MethodImpl(Inline)]
        public NumericType(TypeKey key, Label name, byte packed)
        {
            Key = key;
            TypeName = name;
            var x = (uint)packed;
            Size = new DataSize((uint)packed, x % 8 == 0 ? x/8 : (x/8) + 1);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Key.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => TypeName.IsEmpty;
        }

        public int CompareTo(NumericType src)
            => TypeName.CompareTo(src.TypeName);

        public string Format()
            => TypeName.Format();

        public override string ToString()
            => Format();


        public static NumericType Empty => Intrinsic.None;

        public readonly struct Intrinsic
        {
            public static NumericType None => numeric(NextKey(DataTypeKind.Numeric),  P.Empty.TypeName, 0);

            public static NumericType U1 => numeric(NextKey(DataTypeKind.Numeric),  P.U1.TypeName, (1,8));

            public static NumericType U8 => numeric(NextKey(DataTypeKind.Numeric),  P.U8.TypeName, 8);

            public static NumericType U16 => numeric(NextKey(DataTypeKind.Numeric), P.U16.TypeName, 16);

            public static NumericType U32 => numeric(NextKey(DataTypeKind.Numeric), P.U32.TypeName, 32);

            public static NumericType U64 => numeric(NextKey(DataTypeKind.Numeric),  P.U64.TypeName, 64);

            public static NumericType U2 => numeric(NextKey(DataTypeKind.Numeric),  "uint2", (2,8));

            public static NumericType U3 => numeric(NextKey(DataTypeKind.Numeric),  "uint3", (3,8));

            public static NumericType U4 => numeric(NextKey(DataTypeKind.Numeric),  "uint4", (4,8));

            public static NumericType U5 => numeric(NextKey(DataTypeKind.Numeric),  "uint5", (5,8));

            public static Intrinsic Types => new();

            public static implicit operator Index<NumericKind,NumericType>(Intrinsic src)
                => _Types;

            static NumericType[] _Types = new NumericType[]{
                None,
                U1,
                U8,
                U16,
                U32,
                U64,
                U2,
                U3,
                U4,
                U5
            };
        }
    }
}