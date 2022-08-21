//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct StringBuffers
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Computes the total length of the source strings
        /// </summary>
        /// <param name="src">The source strings</param>
        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<string> src)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(src,i);
                counter += (uint)s.Length;
            }
            return counter;
        }

        [Op, Closures(Closure)]
        public static StringBuffer<S> buffer<S>(uint length)
            where S : unmanaged
                => new StringBuffer<S>(length);

        [Op, Closures(Closure)]
        public static StringBuffer buffer(uint length)
            => new StringBuffer(length);

        /// <summary>
        /// Deposits a character sequence into a caller-supplied buffer and returns a reference to the input
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="offset">The buffer offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static StringRef stringref(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
        {
            var length = src.Length;
            if(length <= byte.MaxValue && store(src, offset, dst))
                return new StringRef(dst.Address(offset), (byte)length);
            else
                return StringRef.Empty;
        }

        /// <summary>
        /// Deposits a character sequence into a caller-supplied buffer and returns the label representation of the input
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="offset">The buffer offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static Label label(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
        {
            var length = src.Length;
            if(length <= byte.MaxValue && store(src, offset, dst))
                return new Label(dst.Address(offset), (byte)length);
            else
                return Label.Empty;
        }

        [MethodImpl(Inline), Op]
        public static bool store(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
        {
            var available = (long)dst.Length - (long)offset;
            var requested = src.Length;
            if(requested <= available)
            {
                var j = offset;
                for(var i=0; i<requested; i++)
                    dst[j++] = skip(src,i);
                return true;
            }
            return false;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool store<S>(ReadOnlySpan<S> src, uint offset, StringBuffer<S> dst)
            where S : unmanaged
        {
            var available = (long)dst.Length - (long)offset;
            var requested = src.Length;
            if(requested <= available)
            {
                var j = offset;
                for(var i=0; i<requested; i++)
                    dst[j++] = skip(src,i);
                return true;
            }
            return false;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool store<S>(ReadOnlySpan<S> src, int offset, StringBuffer<S> dst)
            where S : unmanaged
                => store(src, (uint)offset, dst);
    }
}