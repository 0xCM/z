//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TextEncodingKind<T> : ITextEncodingKind<T>
        where T : unmanaged, ITextEncodingKind<T>
    {
        public TextEncodingKind Kind
        {
            [MethodImpl(Inline)]
            get => default(T).Kind;
        }

        [MethodImpl(Inline)]
        public static implicit operator TextEncodingKind<T>(T src)
            => default;
    }
}
