//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static DataTypes;

    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct PrimalType : IDataType<PrimalType>
    {
        public readonly NativeKind PrimalKind;

        public readonly Label TypeName;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public PrimalType(NativeKind kind, Label name, AlignedWidth width)
        {
            PrimalKind = kind;
            TypeName = name;
            Size = new ((uint)width,(uint)width);
        }

        public TypeKey Key
        {
            [MethodImpl(Inline)]
            get => (byte)PrimalKind;
        }

        public string Format()
            => TypeName.Format();

        public override string ToString()
            => Format();

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => PrimalKind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => PrimalKind != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Key.Hash;
        }

        public int CompareTo(PrimalType src)
            => TypeName.CompareTo(src.TypeName);

        [MethodImpl(Inline)]
        public static ref readonly PrimalType type(NativeKind kind)
            => ref Intrinsic.type(kind);

        public static PrimalType Empty => Intrinsic.Empty;

        public const NativeKind LastKind = NativeKind.Void;

        public readonly struct Intrinsic
        {
            const byte W0 = 0;

            const byte W1 = 8;

            const byte W8 = 8;

            const byte W16 = 16;

            const byte W32 = 32;

            const byte W64 = 64;

            public static PrimalType Empty => primitive(NativeKind.None, EmptyString, W0);

            public static PrimalType U1 => primitive(NativeKind.U1, "bit", W1);

            public static PrimalType U8 => primitive(NativeKind.U8, "byte", W8);

            public static PrimalType U16 => primitive(NativeKind.U16, "ushort", W16);

            public static PrimalType U32 => primitive(NativeKind.U32, "uint", W32);

            public static PrimalType U64 => primitive(NativeKind.U64, "ulong", W64);

            public static PrimalType Void => primitive(NativeKind.Void, "void", W0);

            public static Intrinsic Types => new();

            [MethodImpl(Inline)]
            public static ref readonly PrimalType type(NativeKind kind)
            {
                if(kind <= LastKind)
                    return ref core.skip(_Types,(byte)kind);
                else
                    return ref core.first(_Types);
            }

            public static implicit operator Index<NativeKind,PrimalType>(Intrinsic src)
                => _Types;

            static PrimalType[] _Types = new PrimalType[]{
                Empty,
                U1,
                U8,
                U16,
                U32,
                U64,
                Void,
            };
        }
    }
}