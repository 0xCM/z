//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    /// <summary>
    /// Defines a cli signature
    /// </summary>
    public readonly record struct CliSig : IDataString<CliSig>, IDataType<CliSig>
    {
        [Op]
        public static string format(CliSig src)
            => CliSigFormat.format(src);

        public BinaryCode Data {get;}

        [MethodImpl(Inline)]
        public CliSig(BinaryCode src)
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

        public bool Equals(CliSig src)
            => Data.Equals(src.Data);

        public int CompareTo(CliSig src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator CliSig(byte[] src)
            => new CliSig(src);

        [MethodImpl(Inline)]
        public static implicit operator CliSig(BinaryCode src)
            => new CliSig(src);

        [MethodImpl(Inline)]
        public static implicit operator byte[](CliSig src)
            => src.Data;

        public static CliSig Empty
        {
            [MethodImpl(Inline)]
            get => new CliSig(BinaryCode.Empty);
        }
    }
}