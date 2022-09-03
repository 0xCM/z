//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public unsafe readonly struct MemorySeq
    {
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(ulong src)
            => src;

        [MethodImpl(Inline), Op]
        public static MemoryAddress address(long src)
            => (ulong)src;

        [MethodImpl(Inline), Op]
        public static Address8 address8(byte src)
            => new Address8(src);

        [MethodImpl(Inline), Op]
        public static Address16 address16(ushort src)
            => new Address16(src);

        [MethodImpl(Inline), Op]
        public static Address32 address32(uint src)
            => new Address32(src);

        [MethodImpl(Inline), Op]
        public static Address64 address64(ulong src)
            => new Address64(src);

        [MethodImpl(Inline), Op]
        public static Address<W8,byte> address(W8 w, byte src)
            => new Address<W8,byte>(src);

        [MethodImpl(Inline), Op]
        public static Address<W16,ushort> address(W16 w, ushort src)
            => new Address<W16,ushort>(src);

        [MethodImpl(Inline), Op]
        public static Address<W32,uint> address(W32 w, uint src)
            => new Address<W32,uint>(src);

        [MethodImpl(Inline), Op]
        public static Address<W64,ulong> address(W64 w, ulong src)
            => new Address<W64,ulong>(src);

        const NumericKind Closure = UInt64k;


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool next<T>(ref SeqReader<T> src, out T dst)
            where T : unmanaged
                => src.Next(out dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T next<T>(ref SeqReader<T> src)
            where T : unmanaged
                => ref src.Next();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static void read<T>(Span<T> src, Action<T> dst)
            where T : unmanaged
        {
            fixed(T* pSrc = src)
            {
                var it = reader(pSrc, src.Length);
                while(it.Next(out T current))
                    dst(current);
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqEditor<T> editor<T>(T* pSrc, long count)
            where T : unmanaged
                => new SeqEditor<T>(pSrc, count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqEditor<T> editor<T>(NativeBuffer<T> src)
            where T : unmanaged
                => new SeqEditor<T>(gptr(first(src.Edit)), src.Count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqReader<T> reader<T>(T* pSrc, long count)
            where T : unmanaged
                => new SeqReader<T>(pSrc, count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqReader<T> reader<T>(NativeBuffer<T> src)
            where T : unmanaged
                => new SeqReader<T>(gptr(first(src.Edit)), src.Count);

        /// <summary>
        /// Derives a reader(r0,r1) from readers r0 and r1
        /// </summary>
        /// <param name="r0"></param>
        /// <param name="r1"></param>
        /// <typeparam name="A0"></typeparam>
        /// <typeparam name="A1"></typeparam>
        [MethodImpl(Inline)]
        public static SeqReader<A0,A1> reader<A0,A1>(SeqReader<A0> r0, SeqReader<A1> r1)
            where A0 : unmanaged
            where A1 : unmanaged
                => new SeqReader<A0,A1>(r0,r1);
    }
}