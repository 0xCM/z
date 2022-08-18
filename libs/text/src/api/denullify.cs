//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string denullify<T>(T src)
            => src is null ? RP.Null : src.ToString();
     }
}