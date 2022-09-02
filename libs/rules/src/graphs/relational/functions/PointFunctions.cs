//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly partial struct PointFunctions
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static Fx8 fx(N8 n, MemoryAddress src, MemoryAddress dst)
            => new Fx8(src, dst);

        [Op, Closures(Closure)]
        public static Fx8<byte,T> fx<T>(N8 n, MemoryAddress src, MemoryAddress dst)
            where T : unmanaged
                => new Fx8<byte,T>(src, dst);

        public static Fx8<S,T> fx<S,T>(N8 n, MemoryAddress src, MemoryAddress dst)
            where T : unmanaged
            where S : unmanaged
                => new Fx8<S,T>(src, dst);

        /// <summary>
        /// Defines a function fx8:u8->T
        /// </summary>
        /// <param name="f">The function under specification</param>
        /// <param name="src">The source domain points</param>
        /// <param name="dst">The target domain points</param>
        /// <typeparam name="T">The target domain</typeparam>
        [Op, Closures(Closure)]
        public static ref Fx8<byte,T> fx<T>(N8 n, ref Fx8<byte,T> f, ReadOnlySpan<byte> src, ReadOnlySpan<T> dst)
            where T : unmanaged
        {
            f.SrcMap.Clear();
            var count = min(min(src.Length, dst.Length), PointFunctions.Fx8.Capacity);
            f.Size = (uint)count;
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(src,i);
                ref readonly var y = ref skip(dst,i);
                f.SrcMap[x] = (byte)i;
            }
            return ref f;
        }

        [Op, Closures(Closure)]
        public static ref Fx8<byte,T> fx<T>(N8 n, ReadOnlySpan<byte> src, ReadOnlySpan<T> dst, out Fx8<byte,T> f)
            where T : unmanaged
        {
            f = fx<T>(n, address(first(src)), address(first(dst)));
            return ref fx(n, ref f, src, dst);
        }

        /// <summary>
        /// Defines a function fx8:u8->T
        /// </summary>
        /// <param name="f">The function under specification</param>
        /// <param name="src">The source domain points</param>
        /// <param name="dst">The target domain points</param>
        /// <typeparam name="T">The target domain</typeparam>
        [Op, Closures(Closure)]
        public static ref Fx16<ushort,T> fx<T>(N16 n, ref Fx16<ushort,T> f, ReadOnlySpan<ushort> src, ReadOnlySpan<T> dst)
            where T : unmanaged
        {
            f.SrcMap.Clear();
            var count = min(min(src.Length, dst.Length), PointFunctions.Fx16<ushort,T>.Capacity);
            f.Size = (uint)count;
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(src,i);
                ref readonly var y = ref skip(dst,i);
                f.SrcMap[x] = (ushort)i;
            }
            return ref f;
        }

        [Op, Closures(Closure)]
        public static Fx16<ushort,T> fx<T>(N16 n, MemoryAddress src, MemoryAddress dst)
            where T : unmanaged
                => new Fx16<ushort,T>(src, dst);

        [Op, Closures(Closure)]
        public static ref Fx16<ushort,T> fx<T>(N16 n, ReadOnlySpan<ushort> src, ReadOnlySpan<T> dst, out Fx16<ushort,T> f)
            where T : unmanaged
        {
            f = fx<T>(n, address(first(src)), address(first(dst)));
            return ref fx(n,ref f, src, dst);
        }
    }
}