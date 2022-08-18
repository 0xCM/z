//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcalc
    {
        /// <summary>
        /// Finds a numeric cell of minimal value
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Min, Closures(AllNumeric)]
        public static T min<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var count = src.Length;
            if(count == 0)
                return default;

            ref readonly var a = ref first(src);
            var result = a;
            for(var i = 1; i<count; i++)
            {
                ref readonly var test = ref skip(a, i);
                if(gmath.lt(test, result))
                    result = test;
            }

            return result;
        }
    }
}