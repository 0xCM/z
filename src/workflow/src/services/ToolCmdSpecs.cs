//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public class ToolCmdSpecs
    {
        const NumericKind Closure = UnsignedInts;
            
        [MethodImpl(Inline)]
        public static FlowRelation<K,S,T> relation<K,S,T>(K kind, S src, T dst)
            where K : unmanaged
            where S : unmanaged
            where T : unmanaged
                => new FlowRelation<K,S,T>(FlowId.identify(kind,src,dst), kind, src, dst);
    }
}