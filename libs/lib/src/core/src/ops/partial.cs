//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
        /// <summary>
        /// Reads a partial value if there aren't a sufficient number of bytes to comprise a target value
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T partial<T>(Span<byte> src)
            where T : struct
        {
            if(src.Length == 0)
                return default;

            var tSize = size<T>();
            var srclen = src.Length;
            if(srclen >= tSize)
                return first<T>((ReadOnlySpan<byte>)src);
            else
            {
                var remaining = tSize - srclen;
                var storage = default(T);
                ref var dst = ref @as<T,byte>(storage);
                for(var i=0u; i<srclen; i++)
                    seek(dst,i) = skip(src,i);
                return storage;
            }
        }

        /// <summary>
        /// Reads a partial value if there aren't a sufficient number of bytes to comprise a target value
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T partial<T>(ReadOnlySpan<bit> src)
            where T : struct
        {
            if(src.Length == 0)
                return default;

            var tSize = size<T>();
            var srclen = src.Length;
            if(srclen >= tSize)
                return first<T>(recover<bit,T>(src));
            else
            {
                var remaining = tSize - srclen;
                var storage = default(T);
                ref var dst = ref @as<T,byte>(storage);
                for(var i=0u; i<srclen; i++)
                    seek(dst,i) = skip(src,i);
                return storage;
            }
        }
    }
}