//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        /// <summary>
        /// Projects and transforms source elements that satisfy a specified predicate into a supplied target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="f">The predicate</param>
        /// <param name="dst">The target buffer</param>
        /// <typeparam name="S">The source element type</typeparam>
        /// <typeparam name="T">The target element type</typeparam>
        /// <typeparam name="P">The predicate</typeparam>
        [MethodImpl(Inline)]
        public static uint filter<S,T,P>(ReadOnlySpan<S> src, P f, Span<T> dst)
            where P : struct, IUnaryPred<P,S>
        {
            var counter = 0u;
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref skip(src,i);
                if(f.Invoke(item))
                    seek(dst, counter++) = @as<S,T>(item);
            }
            return counter;
        }
    }
}