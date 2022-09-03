//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed class ApiPacks : WfSvc<ApiPacks>
    {
        public static IApiPack create()
            => create(AppDb.Ts);

        public static IApiPack create(Timestamp ts)
            => new ApiPack(Archives.archive(ts, AppDb.Service.Capture()).Root, ts);
            
        public static ReadOnlySeq<IApiPack> discover()
        {
            var src = AppDb.Service.Capture().Root.SubDirs(false);
            var dst = Lists.list<IApiPack>();
            var counter = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var source = ref src[i];
                if(parse(source, out ApiPack pack))
                {
                    dst.Add(pack);
                    counter++;
                }
            }

            return slice(@readonly(dst.Seal()),0,counter).ToArray();
        }

        public static bool parse(FolderPath src, out Timestamp ts)
        {
            ts = default;
            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;
            return Time.parse(fmt.RightOfIndex(idx), out ts);
        }

        public static bool parse(FolderPath src, out ApiPack dst)
        {
            dst = default;
            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;
            var result = Time.parse(fmt.RightOfIndex(idx), out var ts);
            if(result)
                dst = new ApiPack(src,ts);
            else
                dst = new ApiPack(FolderPath.Empty, Timestamp.Zero);
            return result;
        }

        public IApiPack Current()
            => discover().Last;

        Arrow<FolderPath,FolderPath> Link(Timestamp ts)
        {
            var capture = AppDb.Capture();
            var src = capture.Root + FS.folder(current);
            var dst = discover().Last.Root;
            FS.symlink(src,dst,true).Require();
            Status($"symlink:{src} -> {dst}");
            return (src,dst);
        }

        public Arrow<FolderPath,FolderPath> Link(IApiPack dst)
            => Link(dst.Timestamp);
    }
}