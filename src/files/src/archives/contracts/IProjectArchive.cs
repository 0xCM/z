//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectArchive
    {
        IDbArchive Root {get;}
                
        IProjectType ProjectType {get;}

        IEnumerable<FilePath> Files()
            => Root.Enumerate("*", true);

        IEnumerable<FilePath> Files(params FileKind[] kinds)
            => Root.Enumerate(true, kinds);

        IEnumerable<FilePath> Files(params FileExt[] ext)
            => Root.Enumerate(true, ext);

        IEnumerable<FilePath> Files(string match)
            => Root.Enumerate(match, true);
    }

    public interface IProjectArchive<K> : IProjectType
        where K : IProjectType, new()
    {
        @string IProjectType.Name  
            => new K().Name;
    }
}