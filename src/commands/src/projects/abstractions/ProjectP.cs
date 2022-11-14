//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Project<P>
        where P : Project<P>,new()
    {
        public readonly ReadOnlySeq<IDbArchive> Roots;

        protected Project()
        {
            Roots = sys.empty<IDbArchive>();
        }

        protected Project(IDbArchive[] src)
        {
            Roots = src;
        }

        protected ref readonly IDbArchive Root(uint index)
            => ref Roots[index];
    }   
}