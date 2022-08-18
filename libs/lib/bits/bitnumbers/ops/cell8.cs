//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BitNumbers
    {
        /// <summary>
        /// Seeks an index-identified <see cref='Cell8'/> value from a specified <see cref='Cell16'/> source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="part">The identifying index</param>
        [MethodImpl(Inline), Op]
        public static ref Cell8 cell8(in Cell16 src, uint1 part)
            => ref seek(@as<Cell16,Cell8>(src), part);

        /// <summary>
        /// Seeks an index-identified <see cref='Cell8'/> value from a specified <see cref='Cell32'/> source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="part">The identifying index</param>
        [MethodImpl(Inline), Op]
        public static ref Cell8 cell8(in Cell32 src, uint2 part)
            => ref seek(@as<Cell32,Cell8>(src), part);

        /// <summary>
        /// Seeks an index-identified <see cref='Cell8'/> value from a specified <see cref='Cell64'/> source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="part">The identifying index</param>
        [MethodImpl(Inline), Op]
        public static ref Cell8 cell8(in Cell64 src, uint3 part)
            => ref seek(@as<Cell64,Cell8>(src), part);

        /// <summary>
        /// Seeks an index-identified <see cref='Cell8'/> value from a specified <see cref='Cell128'/> source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="part">The identifying index</param>
        [MethodImpl(Inline), Op]
        public static ref Cell8 cell8(in Cell128 src, uint4 part)
            => ref seek(@as<Cell128,Cell8>(src), part);

        /// <summary>
        /// Seeks an index-identified <see cref='Cell8'/> value from a specified <see cref='Cell256'/> source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="part">The identifying index</param>
        [MethodImpl(Inline), Op]
        public static ref Cell8 cell8(in Cell256 src, uint5 part)
            => ref seek(@as<Cell256,Cell8>(src), part);

        /// <summary>
        /// Seeks an index-identified <see cref='Cell8'/> value from a specified <see cref='Cell256'/> source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="part">The identifying index</param>
        [MethodImpl(Inline), Op]
        public static ref Cell8 cell8(in Cell512 src, uint6 part)
            => ref seek(@as<Cell512,Cell8>(src), part);
    }
}