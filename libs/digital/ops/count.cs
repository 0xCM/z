//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using NBK = NumericBaseKind;
    using C = AsciCode;

    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static uint count(Base16 @base, ReadOnlySpan<C> src)
        {
            var length = src.Length;
            var counter = 0u;
            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(SQ.whitespace(c))
                {
                    if(counter == 0)
                        continue;
                }
                else
                    return counter;

                if(Digital.test(base16, c))
                    counter++;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Counts the number of consecutive digits relative to a specified base
        /// </summary>
        /// <param name="base">The digit base</param>
        /// <param name="src">The input sequence</param>
        [Op]
        public static uint count(NBK @base, ReadOnlySpan<char> src)
        {
            var result = 0u;
            switch(@base)
            {
                case NBK.Base2:
                    result = count(base2,src);
                break;
                case NBK.Base10:
                    result = count(base10,src);
                break;
                case NBK.Base16:
                    result = count(base16,src);
                break;
            }
            return result;
        }

        /// <summary>
        /// Counts the number of consecutive hex digits
        /// </summary>
        /// <param name="base"></param>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static uint count(Base2 @base, ReadOnlySpan<char> src)
        {
            var length = src.Length;
            var counter = 0u;
            for(var i=0; i<length; i++)
            {
                if(test(@base, skip(src,i)))
                    counter++;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Counts the number of consecutive hex digits
        /// </summary>
        /// <param name="base"></param>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static uint count(Base10 @base, ReadOnlySpan<char> src)
        {
            var length = src.Length;
            var counter = 0u;
            for(var i=0; i<length; i++)
            {
                if(test(@base, skip(src,i)))
                    counter++;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Counts the number of consecutive hex digits
        /// </summary>
        /// <param name="base"></param>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static uint count(Base16 @base, ReadOnlySpan<char> src)
        {
            var length = src.Length;
            var counter = 0u;
            for(var i=0; i<length; i++)
            {
                if(test(@base, skip(src,i)))
                    counter++;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Counts the number of contiguous binary digits begining at a specified offset
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The search offset</param>
        [MethodImpl(Inline), Op]
        public static uint count(Base2 @base, ReadOnlySpan<char> src, uint offset)
        {
            var limit = src.Length - offset;
            var counter = 0u;
            for(var i=offset; i<limit; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!Digital.test(@base, c))
                    break;
                counter++;
            }

            return counter;
        }

        /// <summary>
        /// Counts the number of contiguous binary digits begining at a specified offset
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The search offset</param>
        [MethodImpl(Inline), Op]
        public static uint count(Base2 @base, ReadOnlySpan<C> src, uint offset)
        {
            var limit = src.Length - offset;
            var counter = 0u;
            for(var i=offset; i<limit; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!Digital.test(@base, c))
                    break;
                counter++;
            }

            return counter;
        }
    }
}