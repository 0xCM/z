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
        public readonly _PrimalKind PrimalKind;

        public readonly asci64 TypeName;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public PrimalType(_PrimalKind kind, asci64 name, AlignedWidth width)
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
            => TypeName;

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
        public static ref readonly PrimalType type(_PrimalKind kind)
            => ref Intrinsic.type(kind);

        public static PrimalType Empty => Intrinsic.Empty;

        public const _PrimalKind LastKind = _PrimalKind.Void;

        public readonly struct Intrinsic
        {
            const byte W0 = 0;

            const byte W1 = 8;

            const byte W8 = 8;

            const byte W16 = 16;

            const byte W32 = 32;

            const byte W64 = 64;

            public static PrimalType Empty => primitive(_PrimalKind.None, EmptyString, W0);

            public static PrimalType U1 => primitive(_PrimalKind.U1, "bit", W1);

            public static PrimalType U8 => primitive(_PrimalKind.U8, "byte", W8);

            public static PrimalType U16 => primitive(_PrimalKind.U16, "ushort", W16);

            public static PrimalType U32 => primitive(_PrimalKind.U32, "uint", W32);

            public static PrimalType U64 => primitive(_PrimalKind.U64, "ulong", W64);

            public static PrimalType Void => primitive(_PrimalKind.Void, "void", W0);

            public static Intrinsic Types => new();

            [MethodImpl(Inline)]
            public static ref readonly PrimalType type(_PrimalKind kind)
            {
                if(kind <= LastKind)
                    return ref core.skip(_Types,(byte)kind);
                else
                    return ref core.first(_Types);
            }

            public static implicit operator Index<_PrimalKind,PrimalType>(Intrinsic src)
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