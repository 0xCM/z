//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Stateless polytype that implicitly converts to the asci null defined for a reified asci sequence
    /// </summary>
    public readonly struct AsciNull
    {
        public const char Literal = '\0';

        [MethodImpl(Inline)]
        public static implicit operator asci2(AsciNull src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator asci4(AsciNull src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator asci8(AsciNull src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator asci16(AsciNull src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator asci32(AsciNull src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator asci64(AsciNull src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator Null(AsciNull src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator AsciNull(Null src)
            => default;
    }
}