//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITableArchive : IFileArchive
    {
        string TableId<T>()
            where T : struct
                => Z0.TableId.identify<T>().Identifier.Format();

        FileName TableFile<T>()
            where T : struct
                => FS.file(TableId<T>(), FileKind.Csv);

        FilePath TablePath<T>(string scope)
            where T : struct
                => Subdir(scope) + TableFile<T>();        
    }
}