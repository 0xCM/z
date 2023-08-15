//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(StructLayout,Pack=1)]
public readonly record struct PrimalType : IDataType<PrimalType>
{
    public readonly NativeKind PrimalKind;

    public readonly Label TypeName;

    public readonly DataSize Size;

    [MethodImpl(Inline)]
    public PrimalType(NativeKind kind, Label name, DataSize size)
    {
        PrimalKind = kind;
        TypeName = name;
        Size = size;
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

        public static PrimalType Empty => new(NativeKind.None, EmptyString, (W0,W0));

        public static PrimalType U1 => new(NativeKind.U1, "bit", (W1,W8));

        public static PrimalType U8 => new(NativeKind.U8, "byte", (W8,W8));

        public static PrimalType U16 => new(NativeKind.U16, "ushort", (W16,W16));

        public static PrimalType U32 => new(NativeKind.U32, "uint", (W32,W32));

        public static PrimalType U64 => new(NativeKind.U64, "ulong", (W64,W64));

        public static PrimalType Void => new(NativeKind.Void, "void", (W0,W0));

        public static Intrinsic Types => new();

        [MethodImpl(Inline)]
        public static ref readonly PrimalType type(NativeKind kind)
        {
            if(kind <= LastKind)
                return ref sys.skip(_Types,(byte)kind);
            else
                return ref sys.first(_Types);
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
