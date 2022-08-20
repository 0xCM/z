//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Widths
    {
        [MethodImpl(Inline)]
        public static uint mul<A,B>(A a = default, B b = default)
            where A : unmanaged, IDataWidth
            where B : unmanaged, IDataWidth
        {
            if(typeof(A) == typeof(W1))
                return 1;
            else if(typeof(B) == typeof(W1))
                return 1;
            else
                return mul_lo(a,b);
        }

        [MethodImpl(Inline)]
        static uint mul_lo<A,B>(A a = default, B b = default)
            where A : unmanaged,IDataWidth
            where B : unmanaged, IDataWidth
        {
            if(typeof(A) == typeof(W8))
                return mul8(b);
            else if(typeof(A) == typeof(W16))
                return mul16(b);
            else if(typeof(A) == typeof(W32))
                return mul32(b);
            else if(typeof(A) == typeof(W64))
                return mul64(b);
            else
                return mul_hi(a,b);
        }

        [MethodImpl(Inline)]
        static uint mul_hi<A,B>(A a = default, B b = default)
            where A : unmanaged,IDataWidth
            where B : unmanaged, IDataWidth
        {
            if(typeof(A) == typeof(W128))
                return mul128(b);
            else if(typeof(A) == typeof(W256))
                return mul256(b);
            else if(typeof(A) == typeof(W512))
                return mul512(b);
            else if(typeof(A) == typeof(W1024))
                return mul1024(b);
            else
                return 0;
        }

        [MethodImpl(Inline)]
        static uint mul8<W>(W w = default)
            where W : unmanaged,IDataWidth
        {
            const uint a = 8;
            if(typeof(W) == typeof(W8))
                return a*8;
            else if(typeof(W) == typeof(W16))
                return a*16;
            else if(typeof(W) == typeof(W32))
                return a*32;
            else if(typeof(W) == typeof(W64))
                return a*64;
            else if(typeof(W) == typeof(W128))
                return a*128;
            else if(typeof(W) == typeof(W256))
                return a*256;
            else if(typeof(W) == typeof(W512))
                return a*512;
            else
                return a*1024;
        }

        [MethodImpl(Inline)]
        static uint mul16<W>(W w = default)
            where W : unmanaged,IDataWidth
        {
            const uint a = 16;
            if(typeof(W) == typeof(W8))
                return a*8;
            else if(typeof(W) == typeof(W16))
                return a*16;
            else if(typeof(W) == typeof(W32))
                return a*32;
            else if(typeof(W) == typeof(W64))
                return a*64;
            else if(typeof(W) == typeof(W128))
                return a*128;
            else if(typeof(W) == typeof(W256))
                return a*256;
            else if(typeof(W) == typeof(W512))
                return a*512;
            else
                return a*1024;
        }

        [MethodImpl(Inline)]
        static uint mul32<W>(W w = default)
            where W : unmanaged,IDataWidth
        {
            const uint a = 32;
            if(typeof(W) == typeof(W8))
                return a*8;
            else if(typeof(W) == typeof(W16))
                return a*16;
            else if(typeof(W) == typeof(W32))
                return a*32;
            else if(typeof(W) == typeof(W64))
                return a*64;
            else if(typeof(W) == typeof(W128))
                return a*128;
            else if(typeof(W) == typeof(W256))
                return a*256;
            else if(typeof(W) == typeof(W512))
                return a*512;
            else
                return a*1024;
        }

        [MethodImpl(Inline)]
        static uint mul64<W>(W w = default)
            where W : unmanaged,IDataWidth
        {
            const uint a = 64;
            if(typeof(W) == typeof(W8))
                return a*8;
            else if(typeof(W) == typeof(W16))
                return a*16;
            else if(typeof(W) == typeof(W32))
                return a*32;
            else if(typeof(W) == typeof(W64))
                return a*64;
            else if(typeof(W) == typeof(W128))
                return a*128;
            else if(typeof(W) == typeof(W256))
                return a*256;
            else if(typeof(W) == typeof(W512))
                return a*512;
            else
                return a*1024;
        }

        [MethodImpl(Inline)]
        static uint mul128<W>(W w = default)
            where W : unmanaged,IDataWidth
        {
            const uint a = 128;
            if(typeof(W) == typeof(W8))
                return a*8;
            else if(typeof(W) == typeof(W16))
                return a*16;
            else if(typeof(W) == typeof(W32))
                return a*32;
            else if(typeof(W) == typeof(W64))
                return a*64;
            else if(typeof(W) == typeof(W128))
                return a*128;
            else if(typeof(W) == typeof(W256))
                return a*256;
            else if(typeof(W) == typeof(W512))
                return a*512;
            else
                return a*1024;
        }

        [MethodImpl(Inline)]
        static uint mul256<W>(W w = default)
            where W : unmanaged,IDataWidth
        {
            const uint a = 256;
            if(typeof(W) == typeof(W8))
                return a*8;
            else if(typeof(W) == typeof(W16))
                return a*16;
            else if(typeof(W) == typeof(W32))
                return a*32;
            else if(typeof(W) == typeof(W64))
                return a*64;
            else if(typeof(W) == typeof(W128))
                return a*128;
            else if(typeof(W) == typeof(W256))
                return a*256;
            else if(typeof(W) == typeof(W512))
                return a*512;
            else
                return a*1024;
        }

        [MethodImpl(Inline)]
        static uint mul512<W>(W w = default)
            where W : unmanaged,IDataWidth
        {
            const uint a = 512;
            if(typeof(W) == typeof(W8))
                return a*8;
            else if(typeof(W) == typeof(W16))
                return a*16;
            else if(typeof(W) == typeof(W32))
                return a*32;
            else if(typeof(W) == typeof(W64))
                return a*64;
            else if(typeof(W) == typeof(W128))
                return a*128;
            else if(typeof(W) == typeof(W256))
                return a*256;
            else if(typeof(W) == typeof(W512))
                return a*512;
            else
                return a*1024;
        }

        [MethodImpl(Inline)]
        static uint mul1024<W>(W w = default)
            where W : unmanaged,IDataWidth
        {
            const uint a = 1024;
            if(typeof(W) == typeof(W8))
                return a*8;
            else if(typeof(W) == typeof(W16))
                return a*16;
            else if(typeof(W) == typeof(W32))
                return a*32;
            else if(typeof(W) == typeof(W64))
                return a*64;
            else if(typeof(W) == typeof(W128))
                return a*128;
            else if(typeof(W) == typeof(W256))
                return a*256;
            else if(typeof(W) == typeof(W512))
                return a*512;
            else
                return a*1024;
        }
    }
}