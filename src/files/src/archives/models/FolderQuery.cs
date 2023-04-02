//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class FolderQuery: PathQuery<FolderQuery>
    {
        public static FolderQuery create(FolderPath path)
            => new FolderQuery(path, FolderPatterns.All);

        public static FolderQuery create(IDbArchive src)
            => new FolderQuery(src.Root, FolderPatterns.All);

        public static FolderQuery create(FolderPath path, string match)
            => new FolderQuery(path, match);

        public readonly string Match;
        
        public FolderQuery(FolderPath root, string match)
            : base(root)
        {
            Match = match;
        }

        public static FolderQuery Empty => new(FolderPath.Empty, EmptyString);
    }
}