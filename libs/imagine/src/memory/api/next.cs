//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct memory
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref Ptr<T> next<T>(in Ptr<T> src)
            where T : unmanaged
        {
            ref var dst = ref sys.edit(src);
            dst.P++;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static bool next<T>(ref IndexPtr<T> ptr)
            where T : unmanaged
        {
            if(ptr.Position < ptr.Count)
            {
                ptr.Position++;
                return true;
            }
            else
                return false;
        }

        [MethodImpl(Inline)]
        public static bool next<T>(ref IndexPtr<T> ptr, out T dst)
            where T : unmanaged
        {
            if(next(ref ptr))
            {
                dst = ptr.Cell;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        /// <summary>
        /// Advances the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr8 next(in Ptr8 src)
        {
            ref var dst = ref sys.edit(src);
            dst.P++;
            return ref dst;
        }

        /// <summary>
        /// Advances the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref PChar next(in PChar src)
        {
            ref var dst = ref sys.edit(src);
            dst.P++;
            return ref dst;
        }

        /// <summary>
        /// Advances the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr16 next(in Ptr16 src)
        {
            ref var dst = ref sys.edit(src);
            dst.P++;
            return ref dst;
        }

        /// <summary>
        /// Advances the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr32 next(in Ptr32 src)
        {
            ref var dst = ref sys.edit(src);
            dst.P++;
            return ref dst;
        }

        /// <summary>
        /// Advances the source by a uint
        /// </summary>
        /// <param name="src">The source pointer</param>
        [MethodImpl(Inline), Op]
        public static ref Ptr64 next(in Ptr64 src)
        {
            ref var dst = ref sys.edit(src);
            dst.P++;
            return ref dst;
        }
    }
}