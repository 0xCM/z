//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        /// <summary>
        /// Adapts a <see cref='ClrTableCells'/> sequence to a <typeparamref name='T'/> parametric row
        /// </summary>
        /// <param name="fields">The record fields</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static RowAdapter<T> adapter<T>(in ClrTableCells fields)
            => new RowAdapter<T>(fields);

        /// <summary>
        /// Creates a <see cref='RowAdapter{T}'/> predicated a specified <typeparamref name='T'/>
        /// </summary>
        /// <typeparam name="T">The row type</typeparam>
        [Op, Closures(Closure)]
        public static RowAdapter<T> adapter<T>()
            => adapter<T>(cells<T>());
    }
}