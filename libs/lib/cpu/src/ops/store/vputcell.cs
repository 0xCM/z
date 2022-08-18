//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        /// <summary>
        /// Inserts a cell into the target at an index-identified location of a target vector
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <param name="index">The 0-based component index</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vputcell<T>(T src, int index, Vector128<T> dst)
            where T : unmanaged
                => dst.WithElement(index, src);

        /// <summary>
        /// Inserts a cell into the target at an index-identified location of a target vector
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <param name="index">The 0-based component index</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector256<T> vputcell<T>(T src, int index, Vector256<T> dst)
            where T : unmanaged
                => dst.WithElement(index, src);
     }
}