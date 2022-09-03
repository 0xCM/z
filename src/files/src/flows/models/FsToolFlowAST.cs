//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class FsToolFlow<A,S,T>  : FsFlow<S,T>
        where S : IFsEntry
        where T : IFsEntry
        where A : ITool
    {
        public readonly A Actor;

        [MethodImpl(Inline)]
        public FsToolFlow(A actor, S src, T dst)
            : base(src,dst)
        {
            Actor = actor;
        }
    }
}