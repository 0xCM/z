//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [Free]
    public class CharBlock
    {
        [MethodImpl(Inline)]
        public static CharBlock<N> init<N>(ReadOnlySpan<char> src, out CharBlock<N> dst)
            where N : unmanaged, ITypeNat
        {
            dst = new(src);
            return dst;
        }

        [MethodImpl(Inline)]
        public static int length<N>(CharBlock<N> src)
            where N : unmanaged, ITypeNat
        {
            var data = src.Data;
            var counter = 0;
            var max = data.Length;
            for(var i=0; i<max; i++)
            {
                if(skip(data,i) == 0)
                    break;
                counter++;
            }
            return counter;
        }

        public static string format<N>(CharBlock<N> src)
            where N : unmanaged, ITypeNat
        {
            var length = (int)src.Capacity;
            var data = src.Data;
            Span<char> dst = stackalloc char[length];
            for(var i=0; i<length; i++)
                seek(dst,i) = Chars.Space;

            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(c != 0)
                    seek(dst,i) = c;
                else
                    break;
            }

            return text.trim(new string(dst));
        }
    }
}