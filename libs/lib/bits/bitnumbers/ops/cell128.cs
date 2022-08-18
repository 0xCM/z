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
        /// Seeks an index-identified <see cref='Cell128'/> value from a specified <see cref='Cell256'/> source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="part">The identifying index</param>
        [MethodImpl(Inline), Op]
        public static ref Cell128 cell128(in Cell256 src, uint1 part)
            => ref seek(@as<Cell256,Cell128>(src), part);

        /// <summary>
        /// Seeks an index-identified <see cref='Cell128'/> value from a specified <see cref='Cell256'/> source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="part">The identifying index</param>
        [MethodImpl(Inline), Op]
        public static ref Cell128 cell128(in Cell512 src, uint2 part)
            => ref seek(@as<Cell512,Cell128>(src), part);
    }
}