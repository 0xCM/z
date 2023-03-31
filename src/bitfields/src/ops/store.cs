//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Bitfield<T> store<T>(T src, byte field, ref Bitfield<T> dst)
            where T : unmanaged
        {
            ref readonly var spec = ref skip(dst.SegSpecs,field);
            dst.Overwrite(gmath.or(dst.State, gmath.sll(dst.State, u8(spec.Width))));
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref Bitfield<T,K> store<T,K>(T src, byte field, ref Bitfield<T,K> dst)
            where T : unmanaged
            where K : unmanaged
        {
            ref readonly var spec = ref skip(dst.SegSpecs,field);
            dst.Overwrite(gmath.or(dst.State, gmath.sll(dst.State, u8(spec.Width))));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(T src, byte field, ref Bitfield256<T> dst)
            where T : unmanaged
                => dst.State = cpu.vcell(dst.State, field, gmath.and(src, dst.Mask(field)));

        [MethodImpl(Inline)]
        public static void store<E,T>(T src, E field, ref Bitfield256<E,T> dst)
            where E : unmanaged
            where T : unmanaged
                => dst.State = cpu.vcell(dst.State, bw8(field), gmath.and(src, dst.Mask(field)));
   }
}