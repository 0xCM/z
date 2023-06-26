//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitBlocks
    {
        /// <summary>
        /// Loads a bitblock from a <see cref='byte'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static BitBlock<N8,byte> load(byte src)
            => new BitBlock<N8,byte>(src);

        /// <summary>
        /// Loads a bitblock from a <see cref='ushort'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static BitBlock<N16,ushort> load(ushort src)
            => new BitBlock<N16,ushort>(src);

        /// <summary>
        /// Loads a bitblock from a <see cref='uint'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static BitBlock<N32,uint> load(uint src)
            => new BitBlock<N32,uint>(src);

        /// <summary>
        /// Loads a bitblock from a <see cref='ulong'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static BitBlock<N64,ulong> load(ulong src)
            => new BitBlock<N64,ulong>(src);

        /// <summary>
        /// Loads a bitblock from a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="n">The cell count</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitBlock<T> load<T>(Span<T> src, int n)
            where T : unmanaged
                => new BitBlock<T>(src, (uint)n);

        /// <summary>
        /// Creates a bitblock over an arbitrary number of segments
        /// </summary>
        /// <param name="src">The source segment</param>
        [MethodImpl(Inline)]
        public static BitBlock<T> load<T>(params T[] src)
            where T : unmanaged
                => new BitBlock<T>(src, width<T>()*(uint)src.Length);

        /// <summary>
        /// Loads a natural bitcell container from a span
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="n">The bitblock width representative</param>
        /// <typeparam name="N">The bitwidth type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitBlock<N,T> load<N,T>(Span<T> src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitBlock<N,T>(src);

        /// <summary>
        /// Loads a natural bitblock from a readonly span; allocation required
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <typeparam name="N">The bitwidth type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitBlock<N,T> load<N,T>(ReadOnlySpan<T> src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitBlock<N,T>(src.ToSpan());

        [MethodImpl(Inline)]
        public static BitBlock<N,T> load<N,T>(Span<byte> src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitBlock<N,T>(src.Recover<byte,T>());

        /// <summary>
        /// Creates a bitvector from a span of bytes
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="n">The bitvector length</param>
        public static BitBlock<T> load<T>(Span<byte> src, uint n)
            where T : unmanaged
        {
            var q = Math.DivRem(src.Length, (int)size<T>(), out int r);
            var cellcount = r == 0 ? q : q + 1;
            var capacity = (int)size<T>();
            var cells = new T[cellcount];
            for(int i=0, offset = 0; i<cellcount; i++, offset += capacity)
                cells[i] = src.Slice(offset).Take<T>();
            return new BitBlock<T>(cells, n);
        }
    }
}