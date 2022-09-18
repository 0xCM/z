//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    [ApiHost]
    public class Flows
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Flow<T,T> flow<T>(T src, T dst)
            => new (src,dst);

        [MethodImpl(Inline)]
        public static Flow<A,B> flow<A,B>(A src, B dst)
            => new (src,dst);

        [MethodImpl(Inline), Op]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);

        [MethodImpl(Inline), Op]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        [Parser]
        public static Outcome parse(string src, out Tool dst)
        {
            dst = text.trim(src);
            return true;
        }
    }
}