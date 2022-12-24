//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct Tables
    {
        public static FilePath path(FolderPath dir, Type t)
            => t.Tag<RecordAttribute>().MapValueOrElse(a => dir + FS.file(a.TableId, FS.Csv), () => dir + FS.file(t.Name, FS.Csv));

        public static FilePath path(FolderPath dir, Type t, string subject)
            => t.Tag<RecordAttribute>().MapValueOrElse(
                    a => dir + FS.file(string.Format("{0}.{1}", a.TableId, subject), FS.Csv),
                    () => dir + FS.file(string.Format("{0}.{1}", t.Name, subject), FS.Csv));

        public static FilePath path<T>(FolderPath dir)
            where T : struct
                => path(dir, typeof(T));

        public static FilePath path<T>(FolderPath dir, string subject)
            where T : struct
                => path(dir, typeof(T), subject);

        public static FolderPath subdir(FolderPath dir, string subject)
            => dir + FS.folder(subject);

        public static FolderPath subdir(FolderPath dir, FolderName subject)
            => dir + subject;

        public static FolderPath subdir(FolderPath dir, TableId id)
            => dir + FS.folder(id.Format());

        public static FolderPath subdir(FolderPath dir, Type t)
            => t.Tag<RecordAttribute>().MapValueOrElse(a => dir + FS.folder(a.TableId), () => dir + FS.folder(t.Name));

        public static FolderPath subdir<T>(FolderPath dir)
            where T : struct
                => subdir(dir, typeof(T));

        public static FilePath subpath<T>(FolderPath dir, string subject)
            where T : struct
                => subpath(dir, identify<T>(), subject);

        public static FilePath subpath<S>(FolderPath dir, TableId id, S subject)
            => dir + FS.folder(id.Format()) + FS.file(string.Format(EnvFolders.qualified, id, subject), FS.Csv);
    }
}