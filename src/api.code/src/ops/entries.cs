//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        [Op]
        public static MethodEntryPoint entries(MethodInfo src)
            => new (ClrJit.jit(src), src.Uri(), src.DisplaySig().Format());

        [Op]
        public static MethodEntryPoint entries(ApiMember src)
            => new (src.BaseAddress, src.Method.Uri(), src.Method.DisplaySig().Format());

        [Op]
        public static Index<MethodEntryPoint> entries(ApiMembers src)
        {
            var count = src.Length;
            var buffer = alloc<MethodEntryPoint>(count);
            ref var dst = ref first(buffer);
            var view = src.View;
            for(var i=0; i<count; i++)
                seek(dst,i) = entries(skip(view,i));
            return buffer;
        }
    }
}