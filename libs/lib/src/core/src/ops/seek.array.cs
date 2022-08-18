//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, byte count)
            => ref seek(src, (ulong)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, ushort count)
            => ref seek(src, (ulong)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, int count)
            => ref seek(src, (ulong)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, uint count)
            => ref seek(src, (ulong)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, long count)
            => ref seek(src, (ulong)count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>Approach taken from https://github.com/windows-toolkit/WindowsCommunityToolkit/blob/81a23809c1fc2df912a4687487cae22581695064/Microsoft.Toolkit.HighPerformance%2FExtensions%2FArrayExtensions.1D.cs
        /// See <see cref ='RawArrayData'/> for details
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(T[] src, ulong count)
        {
            var arrayData = Unsafe.As<RawArrayData>(src);
            ref T r0 = ref Unsafe.As<byte,T>(ref arrayData.Data);
            ref T ri = ref Unsafe.Add(ref r0, (nint)count);
            return ref ri;
        }

        // https://github.com/windows-toolkit/WindowsCommunityToolkit/blob/81a23809c1fc2df912a4687487cae22581695064/Microsoft.Toolkit.HighPerformance%2FExtensions%2FArrayExtensions.1D.cs
        // Description taken from CoreCLR: see https://source.dot.net/#System.Private.CoreLib/src/System/Runtime/CompilerServices/RuntimeHelpers.CoreCLR.cs,285.
        // CLR arrays are laid out in memory as follows (multidimensional array bounds are optional):
        // [ sync block || pMethodTable || num components || MD array bounds || array data .. ]
        //                 ^                                 ^                  ^ returned reference
        //                 |                                 \-- ref Unsafe.As<RawArrayData>(array).Data
        //                 \-- array
        // The base size of an array includes all the fields before the array data,
        // including the sync block and method table. The reference to RawData.Data
        // points at the number of components, skipping over these two pointer-sized fields.
        [StructLayout(LayoutKind.Sequential)]
        sealed class RawArrayData
        {
            public IntPtr Length;

            public byte Data;
        }
    }
}