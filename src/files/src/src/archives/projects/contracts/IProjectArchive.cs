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

        IEnumerable<FileUri> Files()
            => Root.Enumerate("*", true);

        IEnumerable<FileUri> Files(params FileKind[] kinds)
            => Root.Enumerate(true, kinds);

        IEnumerable<FileUri> Files(params FileExt[] ext)
            => Root.Enumerate(true, ext);

        IEnumerable<FileUri> Files(string match)
            => Root.Enumerate(match, true);
    }

    public interface IProjectArchive<K> : IProjectType
        where K : IProjectType, new()
    {
        @string IProjectType.Name  
            => new K().Name;
    }
}