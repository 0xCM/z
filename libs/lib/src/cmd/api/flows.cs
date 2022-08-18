//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    partial class Cmd
    {
        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);

        public static void parse(ReadOnlySpan<TextLine> src, out ReadOnlySpan<CmdFlow> dst)
            => dst = flows(src);

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
    }
}