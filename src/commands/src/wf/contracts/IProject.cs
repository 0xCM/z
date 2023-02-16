//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProject
    {
        @string Name {get;}

        IDbArchive Root {get;}
    }

    // public interface IProject<K> : IProject, IKinded<K>
    //     where K : unmanaged
    //  {

    // }

    // public interface IProject<P,K> : IProject<K>
    //     where P : IProject<P,K>,new()
    //     where K : unmanaged
    // {

    // }
}