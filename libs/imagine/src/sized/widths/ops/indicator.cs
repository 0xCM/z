//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Widths
    {
        [MethodImpl(Inline)]
        public static string indicator<W>(W w = default)
            where W : unmanaged, IDataWidth
                => indicator_a<W>();

        [MethodImpl(Inline)]
        static string indicator_a<W>(W w = default)
            where W : unmanaged, IDataWidth
        {
            if(typeof(W) == typeof(W1))
                return W1.Identifier;
            else if(typeof(W) == typeof(W2))
                return W2.Identifier;
            else if(typeof(W) == typeof(W3))
                return W3.Identifier;
            else if(typeof(W) == typeof(W4))
                return W4.Identifier;
            else if(typeof(W) == typeof(W5))
                return W5.Identifier;
            else if(typeof(W) == typeof(W6))
                return W6.Identifier;
            else if(typeof(W) == typeof(W7))
                return W7.Identifier;
            else
                return indicator_b<W>();
        }

        [MethodImpl(Inline)]
        static string indicator_b<W>(W w = default)
            where W : unmanaged, IDataWidth
        {
            if(typeof(W) == typeof(W8))
                return W8.Identifier;
            else if(typeof(W) == typeof(W16))
                return W16.Identifier;
            else if(typeof(W) == typeof(W32))
                return W32.Identifier;
            else if(typeof(W) == typeof(W64))
                return W64.Identifier;
            else if(typeof(W) == typeof(W128))
                return W128.Identifier;
            else if(typeof(W) == typeof(W256))
                return W256.Identifier;
            else if(typeof(W) == typeof(W512))
                return W512.Identifier;
            else
                return EmptyString;
        }

        [MethodImpl(Inline), Op]
        public static string indicator(W8 w)
            => indicator_a(w);

        [MethodImpl(Inline), Op]
        public static string indicator(W16 w)
            => indicator_a(w);

        [MethodImpl(Inline), Op]
        public static string indicator(W32 w)
            => indicator_a(w);
    }
}