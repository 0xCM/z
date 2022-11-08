//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class ClrStructs
    {
        [MethodImpl(Inline), Op]
        public static ClrStructAdapter adapt(Type src)
            => new ClrStructAdapter(src);
    }
}