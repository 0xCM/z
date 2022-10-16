//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{        
    using static sys;

    public class CmdFlows : WfSvc<CmdFlows>, ICmdRouter
    {
        public static ReadOnlySpan<CmdFlow> flows(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<CmdFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                if(line.IsEmpty)
                    continue;

                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j >= 0)
                {
                    Tool tool = text.left(content, j);
                    var flow = Fenced.unfence(text.right(content,j), Fenced.Bracketed);

                    j = text.index(flow, "--");
                    if(j == NotFound)
                        j = text.index(flow, "->");

                    if(j>=0)
                    {
                        var a = text.left(flow,j).Trim();
                        var b = text.right(flow,j+2).Trim();
                        if(nonempty(a) && nonempty(b))
                            seek(dst,counter++) = new CmdFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }

        [Op]
        public static void parse(ReadOnlySpan<TextLine> src, out ReadOnlySpan<CmdFlow> dst)
            => dst = flows(src);


        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);        

        ICmdRouter Router;

        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        [Op]
        public static ICmd[] reify(Assembly src)
            => CmdTypes.tagged(src).Select(reify);

        public static CmdFlows flows(IWfRuntime wf, ICmdReactor[] reactors)
        {
            var dst = create(wf);
            var router = new CmdRouter(wf);
            router.Enlist(reactors);
            dst.Router = router;
            return dst;
        }

        public Task<CmdResult> Start<T>(T cmd)
            where T : struct, ICmd
                => Router.Start(cmd);

        public CmdResult Run<T>(T cmd)
            where T : struct, ICmd
                => Start(cmd).Result;

        void ICmdRouter.Enlist(Index<ICmdReactor> reactors)
            => Router.Enlist(reactors);

        ReadOnlySpan<CmdId> ICmdRouter.SupportedCommands
            => Router.SupportedCommands;

        Task<CmdResult> ICmdRouter.Dispatch(ICmd cmd)
            => Router.Dispatch(cmd);

        Task<CmdResult> ICmdRouter.Dispatch(ICmd cmd, string msg)
            => Router.Dispatch(cmd, msg);
    }
}