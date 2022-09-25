//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a cli signature
    /// </summary>
    public readonly record struct EcmaSig : IDataString<EcmaSig>, IDataType<EcmaSig>
    {
        [Op]
        public static string format(EcmaSig src)
            => EcmaSigFormat.format(src);

        public BinaryCode Data {get;}

        [MethodImpl(Inline)]
        public EcmaSig(BinaryCode src)
            => Data = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Data);
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public bool Equals(EcmaSig src)
            => Data.Equals(src.Data);

        public int CompareTo(EcmaSig src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator EcmaSig(byte[] src)
            => new EcmaSig(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaSig(BinaryCode src)
            => new EcmaSig(src);

        [MethodImpl(Inline)]
        public static implicit operator byte[](EcmaSig src)
            => src.Data;

        public static EcmaSig Empty
        {
            [MethodImpl(Inline)]
            get => new EcmaSig(BinaryCode.Empty);
        }
    }
}