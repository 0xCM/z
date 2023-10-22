//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using P = PrimalType;

partial class NativeTypes
{
    /// <summary>
    /// Defines either an intrinsic numeric type or a refinement of such
    /// </summary>
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct NumericType : IDataType<NumericType>
    {
        public readonly @string TypeName;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public NumericType(string name, DataSize size)
        {
            TypeName = name;
            Size = size;
        }

        [MethodImpl(Inline)]
        public NumericType(string name, byte packed)
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
            public static NumericType None => new(EmptyString, 0);
        }
    }
}