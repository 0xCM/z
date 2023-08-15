//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using P = PrimalType.Intrinsic;

/// <summary>
/// Defines either an intrinsic numeric type or a refinement of such
/// </summary>
[StructLayout(StructLayout,Pack=1)]
public readonly record struct NumericType : IDataType<NumericType>
{
    public readonly Label TypeName;

    public readonly DataSize Size;

    [MethodImpl(Inline)]
    public NumericType(Label name, DataSize size)
    {
        TypeName = name;
        Size = size;
    }

    [MethodImpl(Inline)]
    public NumericType(Label name, byte packed)
    {
        TypeName = name;
        var x = (uint)packed;
        Size = new DataSize((uint)packed, x % 8 == 0 ? x/8 : (x/8) + 1);
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => TypeName.Hash | Size.Hash;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => TypeName.IsEmpty;
    }

    [MethodImpl(Inline)]
    public bool Equals(NumericType src)
        => TypeName == src.TypeName && Size == src.Size;
    public override int GetHashCode()
        => Hash;

    public int CompareTo(NumericType src)
        => TypeName.CompareTo(src.TypeName);

    public string Format()
        => TypeName.Format();

    public override string ToString()
        => Format();

    public static NumericType Empty => Intrinsic.None;

    public readonly struct Intrinsic
    {
        public static NumericType None => new(P.Empty.TypeName, 0);

        public static NumericType U1 => new(P.U1.TypeName, (1,8));

        public static NumericType U8 => new(P.U8.TypeName, 8);

        public static NumericType U16 => new(P.U16.TypeName, 16);

        public static NumericType U32 => new(P.U32.TypeName, 32);

        public static NumericType U64 => new(P.U64.TypeName, 64);

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
        };
    }
}
