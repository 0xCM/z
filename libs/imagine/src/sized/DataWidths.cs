//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = DataWidth;

    public class DataWidths
    {
        /// <summary>
        /// Computes the literal data width from a parametric width
        /// </summary>
        /// <typeparam name="W">The parametric width</typeparam>
        [MethodImpl(Inline)]
        public static K measure<W>(W w = default)
            where W : struct, IDataWidth
                => data_1<W>();

        [MethodImpl(Inline)]
        static K data_1<W>()
            where W : struct, IDataWidth
        {
            if(typeof(W) == typeof(W1))
                return K.W1;
            else if(typeof(W) == typeof(W2))
                return K.W2;
            else if(typeof(W) == typeof(W3))
                return K.W3;
            else if(typeof(W) == typeof(W4))
                return K.W4;
            else if(typeof(W) == typeof(W5))
                return K.W5;
            else
                return data_6<W>();
        }

        [MethodImpl(Inline)]
        static K data_6<W>()
            where W : struct, IDataWidth
        {
            if(typeof(W) == typeof(W6))
                return K.W6;
            else if(typeof(W) == typeof(W7))
                return K.W7;
            else if(typeof(W) == typeof(W8))
                return K.W8;
            else if(typeof(W) == typeof(W16))
                return K.W16;
            else if(typeof(W) == typeof(W32))
                return K.W32;
            else
                return data_64<W>();
        }

        [MethodImpl(Inline)]
        static K data_64<W>()
            where W : struct, IDataWidth
        {
            if(typeof(W) == typeof(W64))
                return K.W64;
            else if(typeof(W) == typeof(W128))
                return K.W128;
            else if(typeof(W) == typeof(W256))
                return K.W256;
            else if(typeof(W) == typeof(W512))
                return K.W512;
            else if(typeof(W) == typeof(W1024))
                return K.W1024;
            else
                return 0;
        }        
    }
}