//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    unsafe partial struct memory
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Ptr<T> prior<T>(in Ptr<T> src)
            where T : unmanaged
        {
            ref var dst = ref edit(src);
            dst.P--;
            return ref dst;
        }

        /// <summary>
        /// Decrements the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr8 prior(in Ptr8 src)
        {
            ref var dst = ref edit(src);
            dst.P--;
            return ref dst;
        }

        /// <summary>
        /// Decrements the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr16 prior(in Ptr16 src)
        {
            ref var dst = ref edit(src);
            dst.P--;
            return ref dst;
        }

        /// <summary>
        /// Decrements the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref PChar prior(in PChar src)
        {
            ref var dst = ref edit(src);
            dst.P--;
            return ref dst;
        }

        /// <summary>
        /// Decrements the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr32 prior(in Ptr32 src)
        {
            ref var dst = ref edit(src);
            dst.P--;
            return ref dst;
        }

        /// <summary>
        /// Decrements the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr64 prior(in Ptr64 src)
        {
            ref var dst = ref edit(src);
            dst.P--;
            return ref dst;
        }
    }
}