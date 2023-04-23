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
    public readonly record struct EcmaToken : IDataType<EcmaToken>
    {
        readonly uint Data;

        [MethodImpl(Inline)]
        public EcmaToken(Type src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public EcmaToken(Assembly src)
            : this(src.GetHashCode())
        {

        }

        [MethodImpl(Inline)]
        public EcmaToken(FieldInfo src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public EcmaToken(PropertyInfo src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public EcmaToken(ParameterInfo src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public EcmaToken(MethodInfo src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public EcmaToken(Module src)
            : this(src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        public EcmaToken(int token)
            => Data = (uint)token;

        [MethodImpl(Inline)]
        public EcmaToken(uint token)
            => Data = token;

        [MethodImpl(Inline)]
        public EcmaToken(TableIndex table, uint row)
        {
            Data = (uint)table << 24 | (row & 0xFFFFFF);
        }

        public TableIndex Table
        {
            [MethodImpl(Inline)]
            get => (TableIndex)(Data >> 24);
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
        public int CompareTo(EcmaToken src)
            => Data.CompareTo(src.Data);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(EcmaToken src)
            => Data == src.Data;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(int src)
            => new EcmaToken(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(uint src)
            => new EcmaToken(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(Type src)
            => new EcmaToken(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(FieldInfo src)
            => new EcmaToken(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(PropertyInfo src)
            => new EcmaToken(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(ConstantHandle src)
            => MetadataTokens.GetToken(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(MethodInfo src)
            => new EcmaToken(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(ParameterInfo src)
            => new EcmaToken(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(EcmaToken src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator int(EcmaToken src)
            => (int)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(Handle src)
            => MetadataTokens.GetToken(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(EntityHandle src)
            => MetadataTokens.GetToken(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(TypeDefinitionHandle src)
            => EcmaTokens.token(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(ModuleReferenceHandle src)
            => EcmaTokens.token(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(FieldDefinitionHandle src)
            => EcmaTokens.token(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(MethodDefinitionHandle src)
            => EcmaTokens.token(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(AssemblyReferenceHandle src)
            => EcmaTokens.token(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(AssemblyFileHandle src)
            => EcmaTokens.token(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaToken(TypeReferenceHandle src)
            => EcmaTokens.token(src);

        public static EcmaToken Empty
            => default;
    }
}