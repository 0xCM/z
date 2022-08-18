//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies a metadata element
    /// </summary>
    [ApiComplete]
    public readonly record struct CliToken : IDataType<CliToken>
    {
        readonly uint Data;

        [MethodImpl(Inline)]
        public CliToken(Type src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public CliToken(Assembly src)
            : this(src.GetHashCode())
        {

        }

        [MethodImpl(Inline)]
        public CliToken(FieldInfo src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public CliToken(PropertyInfo src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public CliToken(ParameterInfo src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public CliToken(MethodInfo src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public CliToken(Module src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public CliToken(int token)
            => Data = (uint)token;

        [MethodImpl(Inline)]
        public CliToken(uint token)
            => Data = token;

        [MethodImpl(Inline)]
        public CliToken(CliTableKind table, uint row)
        {
            Data = (uint)table << 24 | (row & 0xFFFFFF);
        }

        public CliTableKind Table
        {
            [MethodImpl(Inline)]
            get => (CliTableKind)(Data >> 24);
        }

        public uint Row
        {
            [MethodImpl(Inline)]
            get => Data & 0xFFFFFF;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public string Format()
            => IsEmpty ? EmptyString : string.Format("{0:X2}:{1:x6}", (byte)Table, Row);

        [MethodImpl(Inline)]
        public int CompareTo(CliToken src)
            => Data.CompareTo(src.Data);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(CliToken src)
            => Data == src.Data;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator CliToken(int src)
            => new CliToken(src);

        [MethodImpl(Inline)]
        public static implicit operator CliToken(uint src)
            => new CliToken(src);

        [MethodImpl(Inline)]
        public static implicit operator CliToken(Type src)
            => new CliToken(src);

        [MethodImpl(Inline)]
        public static implicit operator CliToken(FieldInfo src)
            => new CliToken(src);

        [MethodImpl(Inline)]
        public static implicit operator CliToken(PropertyInfo src)
            => new CliToken(src);

        [MethodImpl(Inline)]
        public static implicit operator CliToken(MethodInfo src)
            => new CliToken(src);

        [MethodImpl(Inline)]
        public static implicit operator CliToken(ParameterInfo src)
            => new CliToken(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(CliToken src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator int(CliToken src)
            => (int)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator CliToken(Handle src)
            => MetadataTokens.GetToken(src);

        [MethodImpl(Inline)]
        public static implicit operator CliToken(EntityHandle src)
            => MetadataTokens.GetToken(src);

        public static CliToken Empty
            => default;
    }
}