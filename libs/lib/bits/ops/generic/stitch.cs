//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        /// <summary>
        /// Computes z := (lhs << ldx |  rhs >> rdx) >> ldx
        /// </summary>
        /// <param name="a">The value that is displaced leftwards</param>
        /// <param name="i">The leftward displacement</param>
        /// <param name="b">The value that is displaced rightwards</param>
        /// <param name="j">The rightward displacement</param>
        /// <typeparam name="T">The primal type</typeparam>
        /// <remarks>
        /// The left value is displaced upwards, shifting in zeros, and is combined
        /// with the right value after it is displaced downwards.
        /// This composite is then displaced downwards the same amount by which the
        /// right value was displaced upwards, removing the zeros that were shifted in.
        /// </remarks>
        [MethodImpl(Inline), Stitch, Closures(Closure)]
        public static T stitch<T>(T a, int i, T b, int j)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.stitch(uint8(a), i, uint8(b), j));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.stitch(uint16(a), i, uint16(b), j));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.stitch(uint32(a), i, uint32(b), j));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.stitch(uint64(a), i, uint64(b), j));
            else
                throw no<T>();
        }
    }
}