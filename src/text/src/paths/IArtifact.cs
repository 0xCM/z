//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IArtifact
    {
        dynamic Location {get;}

        string Classifier {get;}
    }

    public interface IArtifact<K> : IArtifact
        where K : unmanaged
    {
        K Kind {get;}

        string IArtifact.Classifier
            => Kind.ToString();
    }

    public interface IArtifact<K,T> : IArtifact<K>
        where K : unmanaged
    {
        new T Location {get;}

        dynamic IArtifact.Location
            => Location;
    }

    public interface IFileArtifact<H,K> : IArtifact<K,FileUri>, IFsEntry<H>
        where K : unmanaged
        where H : struct, IFileArtifact<H,K>
    {

    }
}