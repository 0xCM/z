//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Name : IDataType<Name>, IExpr, IUnmanaged<Name>
    {
        public readonly asci64 Data;

        [MethodImpl(Inline)]
        public Name(asci64 data)
        {
            Data = data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNull;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Data.IsNull;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(Name src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(Name src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Name(string src)
            => new Name(src);

        [MethodImpl(Inline)]
        public static implicit operator Name(@string src)
            => new Name(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Name(Identifier src)
            => new Name(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator Name(asci64 src)
            => new Name(src);

        [MethodImpl(Inline)]
        public static implicit operator string(Name src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Name(AsciNull src)
            => new Name(asci64.Null);

        public static Name Empty => default;
    }
}