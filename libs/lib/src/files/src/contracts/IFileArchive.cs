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
    public interface IFileArchive : IExpr
    {

        FolderPath Root {get;}

        string TableId<T>()
            where T : struct
                => Z0.TableId.identify<T>().Identifier.Format();

        FileName TableFile<T>()
            where T : struct
                => FS.file(TableId<T>(), FileKind.Csv);
        bool INullity.IsEmpty
            => Root.IsEmpty;

        bool INullity.IsNonEmpty
            => Root.IsNonEmpty;
            
        FolderPath Subdir(string scope)
            => Root + FS.folder(scope);

        string IExpr.Format()
            => Root.Format();

        FilePath TablePath<T>(string scope)
            where T : struct
                => Subdir(scope) + TableFile<T>();
    }
}