//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public class CharBlocks
    {
        [MethodImpl(Inline)]
        public static ref T init<T>(ReadOnlySpan<char> src, out T dst)
            where T : unmanaged, ICharBlock<T>
        {
            dst = default;
            return ref Z0.text.copy(src, ref dst);
        }

        [MethodImpl(Inline)]
        public static int length<T>(in T src)
            where T : unmanaged, ICharBlock<T>
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

        public static string format<T>(T src)
            where T : unmanaged, ICharBlock<T>
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