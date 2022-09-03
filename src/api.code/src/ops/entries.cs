//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCode
    {
        // [Op]
        // public static ReadOnlySeq<MethodEntryPoint> entries(IApiCatalog catalog, ApiHostUri src, IWfEventTarget log)
        // {
        //     var dst = sys.empty<MethodEntryPoint>();
        //     if(catalog.FindHost(src, out var host))
        //     dst = entries(ClrJit.members(host, log));
        //     return dst;
        // }

        // [Op]
        // public static ReadOnlySeq<MethodEntryPoint> entries(IApiCatalog catalog, PartId src, IWfEventTarget log)
        // {
        //     var dst = sys.empty<MethodEntryPoint>();
        //     if(catalog.FindPart(src, out var part))
        //         dst = entries(ClrJit.jit(part, log));
        //     return dst;
        // }

        [Op]
        public static MethodEntryPoint entries(MethodInfo src)
            => new MethodEntryPoint(ClrJit.jit(src), src.Uri(), src.DisplaySig().Format());

        [Op]
        public static MethodEntryPoint entries(ApiMember src)
            => new MethodEntryPoint(src.BaseAddress, src.Method.Uri(), src.Method.DisplaySig().Format());

        [Op]
        public static Index<MethodEntryPoint> entries(Identifier name, ReadOnlySpan<MethodInfo> src)
        {
            var count = src.Length;
            var buffer = alloc<MethodEntryPoint>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = entries(skip(src,i));
            return buffer;
        }

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