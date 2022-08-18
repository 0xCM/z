//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a file system repository
    /// </summary>
    [Free]
    public interface IFileArchive : ITablePaths, IExpr
    {
        FS.FolderPath Root {get;}

        bool INullity.IsEmpty
            => Root.IsEmpty;

        bool INullity.IsNonEmpty
            => Root.IsNonEmpty;
            
        FS.FolderPath Subdir(string scope)
            => Root + FS.folder(scope);

        string IExpr.Format()
            => Root.Format();

        FS.FilePath TablePath<T>(string scope)
            where T : struct
                => Subdir(scope) + TableFile<T>();
    }
}