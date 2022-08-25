//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class Algs
    {
        /// <summary>
        /// Computes the total number of cells covered by the source
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint cells<T>(T[][] src)
        {
            var members = sys.span(src);
            var terms = members.Length;
            var items = 0u;
            for(var i=0u; i<terms; i++)
                items += (uint)sys.skip(members,i).Length;
            return items;
        }

        /// <summary>
        /// Concatenates a sequence of arrays
        /// </summary>
        /// <param name="src">The source arrays</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] concat<T>(IEnumerable<T[]> src)
            => concat(array(src));

        /// <summary>
        /// Concatenates two arrays
        /// </summary>
        /// <param name="left">The first array</param>
        /// <param name="right">The second array</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] concat<T>(T[] left, T[] right)
        {
            var length = left.Length + right.Length;
            var dst = new T[length];
            left.CopyTo(dst,0);
            right.CopyTo(dst, left.Length);
            return dst;
        }

        /// <summary>
        /// Concatenates two byte arrays
        /// </summary>
        /// <param name="left">The first array</param>
        /// <param name="right">The second array</param>
        /// <remarks>See https://stackoverflow.com/questions/415291/best-way-to-combine-two-or-more-byte-arrays-in-c-sharp</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte[] concat(byte[] left, byte[] right)
        {
            var ret = new byte[left.Length + right.Length];
            Buffer.BlockCopy(left, 0, ret, 0, left.Length);
            Buffer.BlockCopy(right, 0, ret, left.Length, right.Length);
            return ret;
        }

        /// <summary>
        /// Concatenates a sequence of parameter arrays
        /// </summary>
        /// <param name="src">The source arrays</param>
        [Op, Closures(Closure)]
        public static T[] concat<T>(T[][] src)
        {
            var total = src.Sum(x => x.Length);
            var buffer = new T[total];
            ref var dst = ref sys.first(buffer);
            var counter = 0;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var arr = ref sys.skip(src,i);
                var len = arr.Length;
                for(var j = 0; j<len; j++)
                    sys.seek(dst, counter++) = sys.skip(arr,j);
            }
            return buffer;
        }
    }
}