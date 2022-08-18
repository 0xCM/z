//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numeric
    {
        [MethodImpl(Inline), Op]
        public static byte hi(byte src)
            => (byte)((byte)src >> 4);

        [MethodImpl(Inline), Op]
        public static byte hi(ushort src)
            => (byte)(src >> 8);

        [MethodImpl(Inline), Op]
        public static ushort hi(uint src)
            => (ushort)(src >> 16);

        [MethodImpl(Inline), Op]
        public static uint hi(ulong src)
            => (uint)(src >> 32);

        [MethodImpl(Inline), Op]
        public static byte lo(byte src)
            => (byte)((byte)src & 0xF);

        [MethodImpl(Inline), Op]
        public static byte lo(ushort src)
            => (byte)src;

        [MethodImpl(Inline), Op]
        public static ushort lo(uint src)
            => (ushort)src;

        [MethodImpl(Inline), Op]
        public static uint lo(ulong src)
            => (uint)src;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T one<T>()
            where T : unmanaged
                => force<T>(1);

        /// <summary>
        /// Ones all bits each and every ... one
        /// </summary>
        /// <param name="t">A primal type representative</param>
        /// <typeparam name="T">The primal source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T ones<T>()
            where T : unmanaged
                => ones_u<T>();

        [MethodImpl(Inline)]
        static T ones_u<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(Ones8u);
            else if(typeof(T) == typeof(ushort))
                return force<T>(Ones16u);
            else if(typeof(T) == typeof(uint))
                return force<T>(Ones32u);
            else if(typeof(T) == typeof(ulong))
                return force<T>(Ones64u);
            else
                return ones_i<T>();
        }

        [MethodImpl(Inline)]
        static T ones_i<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(Ones8i);
            else if(typeof(T) == typeof(short))
                return force<T>(Ones16i);
            else if(typeof(T) == typeof(int))
                return force<T>(Ones32i);
            else if(typeof(T) == typeof(long))
                return force<T>(Ones64i);
            else
                 return ones_f<T>();
       }

        [MethodImpl(Inline)]
        static T ones_f<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return force<T>((float)Ones32u);
            else if(typeof(T) == typeof(double))
                return force<T>((double)Ones64u);
            else
                 throw no<T>();
       }

        const byte Ones8u = byte.MaxValue;

        const sbyte Ones8i = -1;

        const ushort Ones16u = ushort.MaxValue;

        const short Ones16i = -1;

        const uint Ones32u = uint.MaxValue;

        const int Ones32i = -1;

        const ulong Ones64u = ulong.MaxValue;

        const long Ones64i = -1;
    }
}