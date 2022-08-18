//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline)]
        public static T[] alloc<T>(uint count)
            => sys.alloc<T>(count);

        [MethodImpl(Inline)]
        public static T[] alloc<T>(long count)
            => sys.alloc<T>(count);

        [MethodImpl(Inline)]
        public static T[] alloc<T>(ulong count)
            => sys.alloc<T>(count);
    }
}