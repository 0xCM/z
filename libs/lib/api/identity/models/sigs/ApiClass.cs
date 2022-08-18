//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ApiClass : IExpr
    {
        [MethodImpl(Inline), Op]
        public static ApiClass from(MethodInfo src)
        {
            if(src.Tag<OpKindAttribute>(out var dst))
                return new ApiClass(dst.ApiClass);
            else
                return ApiClass.Empty;
        }

        public readonly ApiClassKind Kind;

        [MethodImpl(Inline)]
        public ApiClass(ApiClassKind kind)
            => Kind = kind;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public string Format()
            => Kind.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ApiClass(ApiClassKind kind)
            => new ApiClass(kind);

        [MethodImpl(Inline)]
        public static implicit operator ApiClassKind(ApiClass src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator ushort(ApiClass src)
            => (ushort)src.Kind;

        public static ApiClass Empty
        {
            [MethodImpl(Inline)]
            get => new ApiClass(0);
        }
    }
}