//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial struct Enums
    {
        [MethodImpl(Inline)]
        public static T store<E,T>(in E e, out T dst)
            where E : unmanaged
            where T : unmanaged
        {
            dst = @as<E,T>(e);
            return dst;
        }

        /// <summary>
        /// Stores an enum value of any primal kind to a u64 target
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="dst">The storage target</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static ulong store<E>(in E src, out ulong dst)
            where E : unmanaged
        {
            dst = 0ul;
            if(size<E>() == 1)
                store(w8, src, ref dst);
            else if(size<E>() == 2)
                store(w16, src, ref dst);
            else if(size<E>() == 4)
                store(w32, src, ref dst);
            else
                store(w64, src, ref dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public static byte store<E>(W8 w, in E src, ref ulong dst)
            where E : unmanaged
        {
            ref var u8 = ref @as<E,byte>(src);
            dst = u8;
            return u8;
        }

        [MethodImpl(Inline)]
        public static ushort store<E>(W16 w, in E src, ref ulong dst)
            where E : unmanaged
        {
            ref var tVal = ref @as<E,ushort>(src);
            dst = tVal;
            return tVal;
        }

        [MethodImpl(Inline)]
        public static uint store<E>(W32 w, in E src, ref ulong dst)
            where E : unmanaged
        {
            ref var tVal = ref @as<E,uint>(src);
            dst = tVal;
            return tVal;
        }

        [MethodImpl(Inline)]
        public static ulong store<E>(W64 w, in E src, ref ulong dst)
            where E : unmanaged
        {
            ref var tVal = ref @as<E,ulong>(src);
            dst = tVal;
            return tVal;
        }
    }
}