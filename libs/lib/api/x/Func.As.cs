//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        [MethodImpl(Inline)]
        public static BinaryOperatorClass<T> As<T>(this BinaryOperatorClass src)
             where T : unmanaged => default;
    }
}