//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiQuery
    {
        [MethodImpl(Inline), Op]
        public static ApiHostMethods methods(IApiHost src)
            => new (src, src.Methods);

        [MethodImpl(Inline), Op]
        public static ApiHostMethods methods(IApiHost host, MethodInfo[] methods)
            => new ApiHostMethods(host, methods);
    }
}