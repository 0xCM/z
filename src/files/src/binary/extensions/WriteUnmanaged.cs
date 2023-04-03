//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {        
        [MethodImpl(Inline)]
        public static void WriteUnmanaged<T>(this BinaryWriter dst, in T src)
            where T : unmanaged
                => dst.Write(recover<byte>(bytes(src)));
    }
}