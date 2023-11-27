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
        /// Returns 1 if the left and right spans contain identical content and 0 otherwise
        /// </summary>
        /// <param name="xs">The left span</param>
        /// <param name="ys">The right span</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit identical<T>(Span<T> xs, Span<T> ys)
            where T : unmanaged
        {
            if(xs.Length != ys.Length)
                return false;
            return identical(first(xs), first(ys), (uint)xs.Length);
        }

        /// <summary>
        /// Returns 1 if the left and right spans contain identical content and 0 otherwise
        /// </summary>
        /// <param name="xs">The left span</param>
        /// <param name="ys">The right span</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit identical<T>(ReadOnlySpan<T> xs, ReadOnlySpan<T> ys)
            where T : unmanaged
        {
            if(xs.Length != ys.Length)
                return false;
            return identical(first(xs), first(ys), (uint)xs.Length);
        }

        /// <summary>
        ///  Adapted from corefx repo
        /// </summary>
        [Op, Closures(Closure)]
        public static bit identical<T>(in T first, in T second, uint count)
            where T : unmanaged
        {
            if (same(first, second))
                return true;

            var offset = 0;
            T x;
            T y;
            while (count >= 8)
            {
                count -= 8;

                x = add<T>(first, offset + 0);
                y = add<T>(second, offset + 0);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 1);
                y = add<T>(second, offset + 1);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 2);
                y = add<T>(second, offset + 2);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 3);
                y = add<T>(second, offset + 3);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 4);
                y = add<T>(second, offset + 4);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 5);
                y = add<T>(second, offset + 5);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 6);
                y = add<T>(second, offset + 6);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 7);
                y = add<T>(second, offset + 7);
                if(gmath.neq(x, y))
                    return false;

                offset += 8;
            }

            if (count >= 4)
            {
                count -= 4;

                x = add<T>(first, offset);
                y = add<T>(second, offset);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 1);
                y = add<T>(second, offset + 1);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 2);
                y = add<T>(second, offset + 2);
                if(gmath.neq(x, y))
                    return false;
                x = add<T>(first, offset + 3);
                y = add<T>(second, offset + 3);
                if(gmath.neq(x, y))
                    return false;

                offset += 4;
            }

            while (count > 0)
            {
                x = add<T>(first, offset);
                y = add<T>(second, offset);
                if(gmath.neq(x, y))
                    return false;
                offset += 1;
                count--;
            }

            return true;
        }
    }
}