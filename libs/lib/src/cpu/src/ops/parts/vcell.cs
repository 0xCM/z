//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct cpu
    {
        [MethodImpl(Inline)]
        public static T vcell<T>(Vector128<T> src, byte index)
            where T : unmanaged
                => gcpu.vcell(src,index);

        [MethodImpl(Inline)]
        public static Vector128<T> vcell<T>(Vector128<T> src, byte index, T value)
            where T : unmanaged
                => gcpu.vcell(src,index,value);

        [MethodImpl(Inline)]
        public static Vector256<T> vcell<T>(Vector256<T> src, byte index, T value)
            where T : unmanaged
                => gcpu.vcell(src,index,value);

        [MethodImpl(Inline)]
        public static T vcell<T>(Vector256<T> src, byte index)
            where T : unmanaged
                => gcpu.vcell(src,index);

        [MethodImpl(Inline)]
        public static T vcell<T>(Vector256<T> src, N0 index)
            where T : unmanaged
                => gcpu.vcell(src,index);

        [MethodImpl(Inline)]
        public static T vcell<T>(Vector256<T> src, N1 index)
            where T : unmanaged
                => gcpu.vcell(src,index);

        [MethodImpl(Inline)]
        public static T vcell<T>(Vector256<T> src, N2 index)
            where T : unmanaged
                => gcpu.vcell(src,index);

        [MethodImpl(Inline)]
        public static T vcell<T>(Vector256<T> src, N3 index)
            where T : unmanaged
                => gcpu.vcell(src,index);

        [MethodImpl(Inline)]
        public static T vcell<T>(Vector256<T> src, N4 index)
            where T : unmanaged
                => gcpu.vcell(src,index);

        [MethodImpl(Inline)]
        public static T vcell<S,T>(Vector128<S> src, byte index)
            where S : unmanaged
            where T : unmanaged
                => src.As<S,T>().GetElement(index);
    }
}