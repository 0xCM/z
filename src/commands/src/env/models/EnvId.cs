//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct EnvId : IDataType<EnvId>, IDataString
    {
        public static EnvId Current => Env.var(EnvVarKind.Process, nameof(EnvId), x => new EnvId(x));

        public readonly asci32 Data;

        [MethodImpl(Inline)]
        public EnvId(asci32 data)
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

        // public ReadOnlySpan<AsciSymbol> Cells 
        //     => sys.recover<byte,AsciSymbol>(sys.bytes(Data));
 
        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(EnvId src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(EnvId src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EnvId(string src)
            => new EnvId(src);

        [MethodImpl(Inline)]
        public static implicit operator EnvId(@string src)
            => new EnvId(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator EnvId(Identifier src)
            => new EnvId(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator EnvId(asci32 src)
            => new EnvId(src);

        [MethodImpl(Inline)]
        public static implicit operator string(EnvId src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator EnvId(AsciNull src)
            => new EnvId(asci32.Null);

        public static EnvId Empty => default;
    }
}