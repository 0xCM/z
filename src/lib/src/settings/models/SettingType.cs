//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    public readonly struct SettingType<T> : IKinded<SettingType>
    {
        public readonly SettingType Kind;

        [MethodImpl(Inline)]
        public SettingType(SettingType kind)
        {
            Kind = kind;
        }


        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public string Format()
            => Symbols.format(Kind);


        public override string ToString()
            => Format();


        SettingType IKinded<SettingType>.Kind
            => Kind;

        public ClrTypeAdapter<T> RuntimeType => default;

        [MethodImpl(Inline)]
        public static implicit operator SettingType(SettingType<T> src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator Type(SettingType<T> src)
            => typeof(T);

        [MethodImpl(Inline)]
        public static implicit operator SettingType<T>(SettingType src)
            => new SettingType<T>(src);
    }

    [SymSource(settings)]
    public enum SettingType : byte
    {
        None,

        [Symbol("asci16")]
        Asci16,

        [Symbol("asci32")]
        Asci32,

        [Symbol("asci64")]
        Asci64,

        [Symbol("bit")]
        Bit,

        [Symbol("bool")]
        Bool,

        [Symbol("string")]
        String,

        [Symbol("folder")]
        Folder,

        [Symbol("file")]
        File,

        [Symbol("int")]
        Integer,

        [Symbol("version")]
        Version,

        [Symbol("enum")]
        Enum,

        [Symbol("char")]
        Char,
    }
}