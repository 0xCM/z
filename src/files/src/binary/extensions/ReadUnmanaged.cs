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
        public static T ReadUnmanaged<T>(this BinaryReader src)
            where T : unmanaged
                => @as<T>(span(src.ReadBytes((int)size<T>())));
    }
}