//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {                
        [MethodImpl(Inline)]
        public static unsafe T* ToPointer<T>(this IntPtr src)
            where T : unmanaged
                => sys.gptr<T>(src);

        [MethodImpl(Inline)]
        public static unsafe T* ToPointer<T>(this SafeHandle src)
            where T : unmanaged
                => sys.gptr<T>(src);

        [MethodImpl(Inline)]
        public static unsafe T* ToPointer<T>(this RuntimeFieldHandle src)
            where T : unmanaged
                => sys.gptr<T>(src);
    }
}